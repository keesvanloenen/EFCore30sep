using BenchmarkDotNet.Running;

namespace School.Benchmark;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<EFCoreBenchmarks>();
    }
}
