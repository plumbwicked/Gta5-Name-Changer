using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NameChanger
{
    public class MemoryBlock
    {
        private Scan scan;
        private long address = 0;
        private int size = 0;

        public List<long> results = new List<long>();

        public MemoryBlock(Scan scan, long address, long size)
        {
            this.address = address;
            this.size = (int)size;
            this.scan = scan;
        }

        public void Scan(byte[] target)
        {
            var buffer = new byte[this.size];

            if (!NativeMethods.ReadProcessMemory(scan.processHandle, new IntPtr(address), buffer, size, out var bytesRead))
            {
                if (bytesRead.ToInt32() > 0)
                {
                    this.size = bytesRead.ToInt32();
                }
                else
                {
                    return;
                }
            }

            for (int i = 0; i < this.size; i++)
            {
                if (i + target.Length > buffer.Length)
                    break;
                for (int j = 0; j < target.Length; j++)
                {
                    if (buffer[i + j] != target[j]) break;
                    if (j == target.Length - 1)
                    {
                        results.Add(this.address + i);
                        break;
                    }
                }
            }
        }
    }

    public class Scan
    {
        public static NativeMethods.AllocationProtect READABLEMEMORY { get; private set; } = NativeMethods.AllocationProtect.PAGE_EXECUTE_READ | NativeMethods.AllocationProtect.PAGE_READWRITE | NativeMethods.AllocationProtect.PAGE_EXECUTE_READWRITE;
        public static NativeMethods.AllocationProtect COPYONWRITEMEMORY { get; private set; } = NativeMethods.AllocationProtect.PAGE_EXECUTE_WRITECOPY | NativeMethods.AllocationProtect.PAGE_WRITECOPY;

        public static NativeMethods.AllocationProtect MemoryType { get; set; } = READABLEMEMORY | COPYONWRITEMEMORY;

        public List<MemoryBlock> memoryBlocks = null;

        public long blockSize = 256 * 1024;

        public IntPtr processHandle;

        public Scan(IntPtr handle)
        {
            this.processHandle = handle;
            this.memoryBlocks = new List<MemoryBlock>();
            this.Query();
        }

        public List<long> GetResults()
        {
            var results = new List<long>();
            foreach (var block in memoryBlocks)
            {
                results.AddRange(block.results);
            }
            return results;
        }

        public void Process(byte[] target, Action scanComplete = null)
        {
            NativeMethods.GetSystemInfo(out var systemInfo);
            Task.Factory.StartNew(() =>
            {
                object lockie = new object();

                try
                {
                    Parallel.ForEach(
                        this.memoryBlocks,
                        new ParallelOptions() { MaxDegreeOfParallelism = (int)systemInfo.NumberOfProcessors },
                        block =>
                        {
                            block.Scan(target);
                        });

                    if (scanComplete != null)
                    {
                        scanComplete.Invoke();
                    }
                }
                catch (OperationCanceledException)
                {
                    System.Diagnostics.Debug.Print("Scan aborted");
                }
            });
        }

        public void Query()
        {
            long address = 0;
            long maxAddress = long.MaxValue;
            int remainder = 0;

            long baseAddress = address;

            NativeMethods.GetSystemInfo(out var systemInfo);
            long maxPagesPerBlock = blockSize / systemInfo.PageSize;

            var mbi = default(NativeMethods.MEMORY_BASIC_INFORMATION64);
            uint size = (uint)Marshal.SizeOf(typeof(NativeMethods.MEMORY_BASIC_INFORMATION64));

            while (NativeMethods.VirtualQueryEx(processHandle, new IntPtr(address), out mbi, size) != 0)
            {
                if ((mbi.State & (int)NativeMethods.AllocationType.Commit) != 0 && (mbi.AllocationProtect & (int)MemoryType) != 0)
                {
                    baseAddress = (long)mbi.BaseAddress;
                    remainder = Convert.ToInt32((long)mbi.RegionSize / systemInfo.PageSize);

                    while (true)
                    {
                        if (remainder <= maxPagesPerBlock)
                        {
                            blockSize = remainder * systemInfo.PageSize;
                        }
                        else
                        {
                            blockSize = Convert.ToInt32(maxPagesPerBlock * systemInfo.PageSize);
                        }

                        this.memoryBlocks.Add(
                            new MemoryBlock(
                                this,
                                baseAddress,
                                blockSize));

                        baseAddress += blockSize;
                        remainder -= Convert.ToInt32(blockSize / systemInfo.PageSize);

                        if (remainder == 0)
                        {
                            break;
                        }
                    }
                }

                address = (long)mbi.BaseAddress + (long)mbi.RegionSize;
                if (address >= maxAddress)
                {
                    break;
                }
            }
        }
    }
}