# BenchmarkDotNetWrapperResult

The `BenchmarkDotNetWrapperResult` class enhances BenchmarkDotNet's standard `Summary` object with additional properties for improved programmatic access to benchmark results.

## Class Definition

```csharp
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
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Summary` | `BenchmarkDotNet.Reports.Summary` | The standard BenchmarkDotNet Summary object containing detailed benchmark results |
| `Config` | `BenchmarkDotNet.Configs.IConfig?` | The configuration used for the benchmark run |
| `Args` | `string[]?` | Any command-line arguments passed to the benchmark |
| `Type` | `System.Type` | The type of the benchmarked class (enhances standard Summary with class metadata) |

## Usage

### Basic Usage

```csharp
using BenchmarkDotNet.Attributes;
using BenchmarkDotNetWrapper;

[MemoryDiagnoser]
public class MyBenchmarks
{
    [Benchmark]
    public void Method1() { /* ... */ }
}

// Run benchmarks with enhanced results
var result = BenchmarkRunner.Run<MyBenchmarks>();

// Access the benchmark class metadata (not available in standard Summary)
Console.WriteLine($"Benchmarked type: {result.Type.Name}");
Console.WriteLine($"Type namespace: {result.Type.Namespace}");

// Access the standard BenchmarkDotNet Summary
var summary = result.Summary;
```

### Accessing Results Data

The wrapper preserves full access to the BenchmarkDotNet Summary while adding improved context:

```csharp
var result = BenchmarkRunner.Run<MyBenchmarks>();

// Access the benchmark reports table (standard Summary access)
var table = result.Summary.Table;

// Get the total number of reports
int reportCount = result.Summary.Reports.Length;

// Get mean execution time for a specific benchmark (standard Summary access)
var meanTime = result.Summary.Reports
    .FirstOrDefault(r => r.BenchmarkCase.Descriptor.DisplayInfo.Contains("Method1"))
    ?.ResultStatistics?.Mean;

if (meanTime.HasValue)
{
    Console.WriteLine($"Mean execution time: {meanTime.Value} ns");
}

// Enhanced wrapper functionality: Access class information
bool isPublic = result.Type.IsPublic;
bool hasAttributes = result.Type.CustomAttributes.Any();
```

### Using the Extension Method

The library provides an extension method for easy conversion to a BenchmarkDotNet Summary when needed:

```csharp
using BenchmarkDotNetWrapper;

var result = BenchmarkRunner.Run<MyBenchmarks>();

// Convert to Summary using the extension method when standard BenchmarkDotNet APIs are needed
var summary = result.AsSummary();
```

## Best Practices

1. **Use the Type property** to access benchmark class metadata not available in the standard Summary

2. **Access the Config property** to examine the configuration used for the benchmark

3. **Check command-line args** that were passed to the benchmark run

4. **Use AsSummary()** when interfacing with existing BenchmarkDotNet code

## Related Classes

- [BenchmarkRunner](BenchmarkRunner.md) - The class used to run benchmarks and generate enhanced results
- [Extensions](Extensions.md) - Extension methods for working with BenchmarkDotNetWrapperResult 