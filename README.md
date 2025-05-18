# BenchmarkDotNetWrapper

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/BenchmarkDotNetWrapper.svg)](https://www.nuget.org/packages/BenchmarkDotNetWrapper)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/download)

A lightweight wrapper extension for BenchmarkDotNet that provides improved workflow and result handling capabilities. This extension is designed for developers already familiar with BenchmarkDotNet who want enhanced results management and a streamlined API.

## 📋 Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Quick Start](#quick-start)
- [Usage Examples](#usage-examples)
- [API Reference](#api-reference)
- [Documentation](#documentation)
- [BenchmarkDotNetWrapper.AI](#benchmarkdotnetwrapperai)
- [Why BenchmarkDotNetWrapper?](#why-benchmarkdotnetwrapper)
- [Contributing](#contributing)
- [License](#license)

## ✨ Features

- **Enhanced Result Handling** - Improved programmatic access to benchmark results
- **Simplified API Surface** - Streamlined interfaces that complement BenchmarkDotNet
- **100% Compatible** - Works seamlessly with all existing BenchmarkDotNet features
- **Lightweight** - Minimal overhead compared to using BenchmarkDotNet directly

## 📦 Installation

### Using .NET CLI

```bash
dotnet add package BenchmarkDotNetWrapper
```

### Using Package Manager Console

```powershell
Install-Package BenchmarkDotNetWrapper
```

### Using PackageReference in .csproj

```xml
<PackageReference Include="BenchmarkDotNetWrapper" Version="1.0.0" />
```

## 🚀 Quick Start

### One-Liner Example

```csharp
// Run a benchmark in just one line, with improved result handling
var result = BenchmarkDotNetWrapper.BenchmarkRunner.Run<YourBenchmarkClass>();
```

### Complete Example

```csharp
using BenchmarkDotNet.Attributes;
using BenchmarkDotNetWrapper;

namespace MyBenchmarkProject
{
    [MemoryDiagnoser]
    public class MyBenchmarks
    {
        [Benchmark]
        public void Method1()
        {
            // Code to benchmark
        }
        
        [Benchmark]
        public void Method2()
        {
            // Alternative implementation to benchmark
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Run the benchmarks and get the wrapped result
            var result = BenchmarkRunner.Run<MyBenchmarks>();
            
            // Access the underlying BenchmarkDotNet Summary if needed
            var summary = result.AsSummary();
            
            // Use result properties for additional processing
            Console.WriteLine($"Benchmark type: {result.Type.Name}");
        }
    }
}
```


## 📚 Documentation

For detailed documentation, see the [Documentation](Docs/README.md) section, which includes:

- [API Reference](Docs/api/README.md)
- [Getting Started Guide](Docs/getting-started/FirstBenchmark.md)
- [Advanced Topics](Docs/advanced/README.md)

## 🤖 BenchmarkDotNetWrapper.AI

BenchmarkDotNetWrapper.AI is an extension for AI model benchmarking that helps you measure and analyze the performance of AI-related operations in your .NET applications.

[![NuGet](https://img.shields.io/nuget/v/BenchmarkDotNetWrapper.AI.svg)](https://www.nuget.org/packages/BenchmarkDotNetWrapper.AI)

### Features

- Easy integration with BenchmarkDotNet
- Support for AI-specific benchmarking scenarios including OpenAI models
- Detailed performance metrics and analysis
- API keys are never stored - only used temporarily for valid providers
- Code optimization suggestions powered by AI
- Compatible with .NET 8.0 and later

### Installation

```bash
dotnet add package BenchmarkDotNetWrapper.AI
```

### Basic Usage

```csharp
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.AI;
using BenchmarkDotNet.AI.Types.BenchmarkDotNet.AI.Types;
using LLM;

[MemoryDiagnoser]
public class MyBenchmark
{
    [Benchmark]
    public void MyOperation()
    {
        // Your code to benchmark
    }
}

// Run the benchmark
var summary = BenchmarkRunner.Run<MyBenchmark>();
```

### AI-Powered Code Analysis

```csharp
using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.AI;
using BenchmarkDotNet.AI.Types.BenchmarkDotNet.AI.Types;
using BenchmarkDotNet.AI.LlmEngines.OpenAI;
using LLM;

[MemoryDiagnoser]
public class MyBenchmark
{
    [Benchmark]
    public void SlowMethod()
    {
        // Inefficient code to analyze
        var list = new List<int>();
        for (int i = 0; i < 1000000; i++)
        {
            list.Add(i);
            // Inefficient implementation
        }
    }
}

// Run the benchmark with AI analysis
var llmOptions = new LlmEngineOptions
{
    EngineType = typeof(OpenAiEngine),
    ApiKey = "your-openai-api-key", // Never stored, only used during execution
    OveridingPrompt = null // Use the default prompt
};

var summary = await BenchmarkRunner<MyBenchmark>.Run(llmOptions);
```

### Configuration Options

The `LlmEngineOptions` class provides the configuration for the LLM engine:

| Option | Description | Default |
|--------|-------------|---------|
| `EngineType` | Type that implements `ILlmEngine` | Required |
| `ApiKey` | Your AI provider API key (never stored) | Empty string |
| `OveridingPrompt` | Custom prompt to override the default | null |

For more details on BenchmarkDotNetWrapper.AI, see the [AI Documentation](Docs/api/AIExtension.md).

## 🤔 Why BenchmarkDotNetWrapper?

As a BenchmarkDotNet user, you'll benefit from this wrapper extension through:

1. **Improved Result Handling** - Makes it easier to work with benchmark results programmatically
2. **Enhanced API** - Provides a cleaner interface around BenchmarkDotNet's functionality
3. **Consistency** - Enforces consistent patterns for benchmark execution
4. **Extensibility** - Provides a foundation for adding custom functionality around benchmarks
5. **AI Integration** - Through the AI extension, provides advanced analysis capabilities

## 👥 Contributing

Contributions to BenchmarkDotNetWrapper are welcome! Here's how you can contribute:

1. **Fork the repository**
2. **Create a feature branch**:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Make your changes**
4. **Run tests** to ensure everything works as expected
5. **Commit your changes**:
   ```bash
   git commit -m "Add your meaningful commit message"
   ```
6. **Push to your fork**:
   ```bash
   git push origin feature/your-feature-name
   ```
7. **Create a Pull Request** against the main repository

### Development Setup

1. Clone the repository
2. Open the solution in Visual Studio or your preferred IDE
3. Restore NuGet packages
4. Build the solution

### Coding Standards

- Follow the existing code style
- Write unit tests for new functionality
- Document public APIs with XML comments
- Keep commits focused and avoid mixing unrelated changes

## 📄 License

BenchmarkDotNetWrapper is licensed under the [MIT License](LICENSE), which permits use, modification, and distribution with attribution.

## ❓ Support

If you encounter any issues or have questions, please open an issue on the GitHub repository.

---

Made with ❤️ by [Avishai Dotan](https://github.com/avishaidotan) and contributors.