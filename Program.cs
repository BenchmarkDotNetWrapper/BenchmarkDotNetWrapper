using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

namespace BenchmarkDotNetWrapper
{
    public class BenchmarkRunner
    {
        public static BenchmarkDotNetWrapperResult Run<T>(IConfig? config = null, string[]? args = null)
            where T : class
        {
            Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<T>(config, args);
            var type = typeof(T);
            return new BenchmarkDotNetWrapperResult(type, summary, config, args);
        }
    }

    public class BenchmarkDotNetWrapperResult
    {
        public Summary Summary { get; }
        public IConfig? Config { get; }
        public string[]? Args { get; }
        public Type Type { get; }

        public BenchmarkDotNetWrapperResult(Type type, Summary summary, IConfig? config, string[]? args)
        {
            Summary = summary;
            Config = config;
            Args = args;
            Type = type;

        }
    }

    public static class BenchmarkDotNetWrapperExtensions
    {
        public static Summary AsSummary(this BenchmarkDotNetWrapperResult benchmarkWrapperResult)
        {
            return benchmarkWrapperResult.Summary;
        }
    }
}