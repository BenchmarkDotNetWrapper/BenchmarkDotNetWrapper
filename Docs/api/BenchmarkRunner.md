# BenchmarkRunner

The `BenchmarkRunner` class is the main entry point for BenchmarkDotNetWrapper, providing enhanced result handling for your existing BenchmarkDotNet benchmarks.

## Class Definition

```csharp
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
```

## Methods

### Run\<T>

Runs benchmarks defined in class `T` and returns an enhanced wrapper result with improved programmatic access.

#### Parameters

| Parameter | Type | Description | Default Value |
|-----------|------|-------------|---------------|
| `config` | `BenchmarkDotNet.Configs.IConfig?` | Standard BenchmarkDotNet configuration | `null` (uses BenchmarkDotNet default) |
| `args` | `string[]?` | Command-line arguments for the benchmark | `null` |

#### Type Parameters

| Parameter | Constraint | Description |
|-----------|------------|-------------|
| `T` | `class` | The class containing benchmark methods marked with the `[Benchmark]` attribute |

#### Returns

A `BenchmarkDotNetWrapperResult` object that enhances the benchmark results with improved programmatic access.

## Usage Examples

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

// Run benchmarks with enhanced result handling
var result = BenchmarkRunner.Run<MyBenchmarks>();
```

### With Custom Configuration

```csharp
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNetWrapper;

[MemoryDiagnoser]
public class MyBenchmarks
{
    [Benchmark]
    public void Method1() { /* ... */ }
}

// Create standard BenchmarkDotNet configuration
var config = DefaultConfig.Instance
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .AddJob(Job.ShortRun);

// Run with the wrapper for enhanced results
var result = BenchmarkRunner.Run<MyBenchmarks>(config);
```

### With Command-Line Arguments

```csharp
// In Main method
static void Main(string[] args)
{
    var result = BenchmarkRunner.Run<MyBenchmarks>(args: args);
    // Process enhanced result
}
```

## How It Works

The `BenchmarkRunner.Run<T>` method enhances the standard BenchmarkDotNet runner by:

1. Executing the standard BenchmarkDotNet runner
2. Capturing the type information of the benchmark class
3. Wrapping the results in a `BenchmarkDotNetWrapperResult` for improved programmatic access

This approach maintains full compatibility with BenchmarkDotNet while providing enhanced result handling.

## Best Practices

1. **Use with existing BenchmarkDotNet attributes**:
   - All standard BenchmarkDotNet attributes work exactly the same

2. **Leverage the enhanced result object**:
   - Use the Type property to access benchmark class metadata
   - Access the original Summary when needed with AsSummary()

3. **Mix with standard BenchmarkDotNet features**:
   - All configurations, exporters, and diagnosers work as expected

## Related Classes

- [BenchmarkDotNetWrapperResult](BenchmarkDotNetWrapperResult.md) - The enhanced result class returned by BenchmarkRunner.Run
- [Extensions](Extensions.md) - Extension methods for working with BenchmarkDotNetWrapperResult 