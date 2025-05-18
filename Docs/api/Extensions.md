# Extensions

BenchmarkDotNetWrapper provides extension methods that simplify working with the enhanced result wrapper and interfacing with standard BenchmarkDotNet APIs.

## BenchmarkDotNetWrapperExtensions

### AsSummary

Converts a `BenchmarkDotNetWrapperResult` to the standard BenchmarkDotNet `Summary` object for compatibility with existing BenchmarkDotNet code.

```csharp
public static Summary AsSummary(this BenchmarkDotNetWrapperResult benchmarkWrapperResult)
{
    return benchmarkWrapperResult.Summary;
}
```

#### Usage Example

```csharp
using BenchmarkDotNet.Attributes;
using BenchmarkDotNetWrapper;

[MemoryDiagnoser]
public class MyBenchmarks
{
    [Benchmark]
    public void TestMethod() { /* ... */ }
}

// Run with enhanced result handling
var result = BenchmarkRunner.Run<MyBenchmarks>();

// Convert to standard BenchmarkDotNet Summary when needed
var summary = result.AsSummary();

// Now you can use with standard BenchmarkDotNet APIs
Console.WriteLine($"Total run time: {summary.TotalTime}");
```

#### When to Use

Use this extension method when you need to:

1. Pass the result to existing BenchmarkDotNet utilities that expect a Summary object
2. Use BenchmarkDotNet-specific APIs that work with Summary objects
3. Integrate with existing code that works with standard BenchmarkDotNet

#### Benefits

This extension method allows you to:

1. Take advantage of the enhanced wrapper features when needed
2. Maintain compatibility with standard BenchmarkDotNet code
3. Smoothly transition between wrapper functionality and standard BenchmarkDotNet

## Future Extensions

Additional extension methods may be added in future releases to enhance the functionality of the library, focusing on:

- Result filtering and transformation utilities
- Export enhancements for reports
- Integration with CI/CD systems

## Related Documentation

- [BenchmarkDotNetWrapperResult](BenchmarkDotNetWrapperResult.md)
- [BenchmarkRunner](BenchmarkRunner.md) 