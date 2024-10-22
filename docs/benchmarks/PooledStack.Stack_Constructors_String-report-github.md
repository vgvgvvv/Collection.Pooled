``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview6-012264
  [Host] : .NET Core 3.0.0-preview6-27804-01 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview6-27804-01 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), 64bit RyuJIT

Jit=RyuJit  Platform=X64  

```
|      Method |  Job | Runtime |     N |       Kind |         Mean |        Error |       StdDev | Ratio | RatioSD |      Gen 0 |      Gen 1 |      Gen 2 |    Allocated |
|------------ |----- |-------- |------ |----------- |-------------:|-------------:|-------------:|------:|--------:|-----------:|-----------:|-----------:|-------------:|
|       **Stack** |  **Clr** |     **Clr** |  **1000** | **Collection** |   **1,208.9 us** |    **14.547 us** |    **13.607 us** |  **1.00** |    **0.00** |  **2570.3125** |          **-** |          **-** |   **7917.39 KB** |
| PooledStack |  Clr |     Clr |  1000 | Collection |   2,591.8 us |    14.067 us |    13.158 us |  2.14 |    0.03 |    15.6250 |          - |          - |     54.88 KB |
|             |      |         |       |            |              |              |              |       |         |            |            |            |              |
|       Stack | Core |    Core |  1000 | Collection |   1,142.0 us |    11.470 us |    10.729 us |  1.00 |    0.00 |  2562.5000 |          - |          - |   7867.19 KB |
| PooledStack | Core |    Core |  1000 | Collection |     691.3 us |     6.279 us |     5.874 us |  0.61 |    0.01 |    17.5781 |          - |          - |     54.69 KB |
|             |      |         |       |            |              |              |              |       |         |            |            |            |              |
|       **Stack** |  **Clr** |     **Clr** |  **1000** | **Enumerable** |  **15,875.9 us** |   **201.678 us** |   **188.649 us** |  **1.00** |    **0.00** |  **5281.2500** |          **-** |          **-** |  **16320.74 KB** |
| PooledStack |  Clr |     Clr |  1000 | Enumerable |  23,228.9 us |   147.299 us |   137.783 us |  1.46 |    0.02 |    31.2500 |          - |          - |    156.75 KB |
|             |      |         |       |            |              |              |              |       |         |            |            |            |              |
|       Stack | Core |    Core |  1000 | Enumerable |  13,530.4 us |    66.445 us |    62.153 us |  1.00 |    0.00 |  5296.8750 |          - |          - |  16257.81 KB |
| PooledStack | Core |    Core |  1000 | Enumerable |  15,152.5 us |   333.193 us |   342.165 us |  1.12 |    0.03 |    46.8750 |          - |          - |    156.25 KB |
|             |      |         |       |            |              |              |              |       |         |            |            |            |              |
|       **Stack** |  **Clr** |     **Clr** | **10000** | **Collection** |  **10,750.6 us** |    **88.827 us** |    **83.089 us** |  **1.00** |    **0.00** | **24984.3750** |          **-** |          **-** |  **78371.88 KB** |
| PooledStack |  Clr |     Clr | 10000 | Collection |  36,871.3 us |   223.961 us |   209.493 us |  3.43 |    0.04 |          - |          - |          - |     54.86 KB |
|             |      |         |       |            |              |              |              |       |         |            |            |            |              |
|       Stack | Core |    Core | 10000 | Collection |  10,506.2 us |   206.069 us |   332.763 us |  1.00 |    0.00 | 24984.3750 |          - |          - |  78179.69 KB |
| PooledStack | Core |    Core | 10000 | Collection |   9,614.4 us |    86.618 us |    81.022 us |  0.90 |    0.02 |    15.6250 |          - |          - |     54.69 KB |
|             |      |         |       |            |              |              |              |       |         |            |            |            |              |
|       **Stack** |  **Clr** |     **Clr** | **10000** | **Enumerable** | **213,879.4 us** | **1,094.471 us** | **1,023.769 us** |  **1.00** |    **0.00** | **41333.3333** | **41333.3333** | **41333.3333** | **256544.27 KB** |
| PooledStack |  Clr |     Clr | 10000 | Enumerable | 255,038.8 us | 1,354.032 us | 1,266.562 us |  1.19 |    0.01 |          - |          - |          - |       160 KB |
|             |      |         |       |            |              |              |              |       |         |            |            |            |              |
|       Stack | Core |    Core | 10000 | Enumerable | 206,015.2 us |   724.400 us |   642.161 us |  1.00 |    0.00 | 41333.3333 | 41333.3333 | 41333.3333 | 256351.56 KB |
| PooledStack | Core |    Core | 10000 | Enumerable | 152,765.4 us | 1,460.415 us | 1,366.073 us |  0.74 |    0.01 |          - |          - |          - |    156.25 KB |
