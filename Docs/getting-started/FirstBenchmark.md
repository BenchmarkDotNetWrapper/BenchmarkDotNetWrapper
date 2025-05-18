# Using BenchmarkDotNetWrapper with Your Benchmarks

This guide shows how to use BenchmarkDotNetWrapper to enhance your existing BenchmarkDotNet benchmarks with improved result handling and a streamlined API.

## Prerequisites

Before starting, ensure you have:

1. .NET SDK 8.0 or later installed
2. An existing project using BenchmarkDotNet
3. Added the BenchmarkDotNetWrapper package:

```bash
dotnet add package BenchmarkDotNetWrapper
```

## Using the Wrapper with Existing Benchmarks

If you have existing benchmark classes, you can immediately use the wrapper's enhanced runner:

```csharp
// Instead of:
// var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<MyBenchmarks>();

// Use:
using BenchmarkDotNetWrapper;
var result = BenchmarkRunner.Run<MyBenchmarks>();

// Access enhanced result properties
Console.WriteLine($"Benchmark type: {result.Type.Name}");

// Still access the original Summary when needed
var summary = result.AsSummary();
```

## Example Benchmark with the Wrapper

Here's how to run a benchmark using the wrapper:

```csharp
using BenchmarkDotNet.Attributes;
using BenchmarkDotNetWrapper;
using System;

namespace MyBenchmarkProject
{
    [MemoryDiagnoser] 
    public class StringBenchmarks
    {
        private const string TestString = "Hello, World!";
        
        [Benchmark(Baseline = true)]
        public string UsingStringConcat()
        {
            return TestString + " " + TestString;
        }
        
        [Benchmark]
        public string UsingInterpolation()
        {
            return $"{TestString} {TestString}";
        }
        
        [Benchmark]
        public string UsingStringFormat()
        {
            return string.Format("{0} {1}", TestString, TestString);
        }
    }
}
```

In your `Program.cs`, use the wrapper's runner:

```csharp
using BenchmarkDotNetWrapper;
using MyBenchmarkProject;
using System;

namespace MyBenchmarkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running benchmarks with enhanced result handling...");
            
            // Run with the wrapper for enhanced results
            var result = BenchmarkRunner.Run<StringBenchmarks>();
            
            // Access wrapper-specific properties
            Console.WriteLine($"Benchmark completed for type: {result.Type.Name}");
            
            // Access the underlying Summary when needed
            var summary = result.AsSummary();
            Console.WriteLine($"Total time: {summary.TotalTime}");
        }
    }
}
```

## Using with Custom Configurations

The wrapper fully supports all BenchmarkDotNet configurations:

```csharp
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNetWrapper;

// Create standard BenchmarkDotNet config
var config = DefaultConfig.Instance
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .AddJob(Job.ShortRun);

// Use with the wrapper
var result = BenchmarkRunner.Run<MyBenchmarks>(config);
```

## Accessing Enhanced Results

The main benefit of the wrapper is the enhanced result handling:

```csharp
var result = BenchmarkRunner.Run<StringBenchmarks>();

// Access the benchmark type information
Console.WriteLine($"Benchmark class: {result.Type.Name}");

// Access the original configuration
if (result.Config != null)
{
    // Work with config properties
}

// Access command line args if provided
if (result.Args != null && result.Args.Length > 0)
{
    Console.WriteLine($"First arg: {result.Args[0]}");
}

// Convert to original Summary when needed
var summary = result.AsSummary();
```

## Next Steps

Now that you're using the wrapper with your benchmarks, you can:

1. **Explore the wrapper's API** for additional functionality
2. **Use the AI extension** for advanced benchmark analysis:
   ```csharp
   using BenchmarkDotNetWrapper.AI;
   // AI-powered benchmark analysis
   ```
3. **Create custom result processors** that work with the enhanced result object

## Related Documentation

- [BenchmarkDotNetWrapperResult](../api/BenchmarkDotNetWrapperResult.md)
- [BenchmarkRunner](../api/BenchmarkRunner.md) 