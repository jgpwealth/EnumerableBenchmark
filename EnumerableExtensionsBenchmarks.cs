using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using EnumerableBenchmarks;

namespace EnumerableExtensionsBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmarks
    {
        private IEnumerable<int> bigGroup = Enumerable.Range(0, 99999);
        private int chunkSize = 77;

        [Benchmark]
        public void Divide()
        {
            bigGroup.Divide(chunkSize).ToList();
        }

        [Benchmark]
        public void Chunk()
        {
            bigGroup.Chunk(chunkSize).ToList();
        }
    }
}
