``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview6-012264
  [Host] : .NET Core 3.0.0-preview6-27804-01 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview6-27804-01 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), 64bit RyuJIT

Jit=RyuJit  Platform=X64  InvocationCount=1  
UnrollFactor=1  

```
|       Method |  Job | Runtime |      N |   Type |      Mean |      Error |     StdDev |    Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------- |----- |-------- |------- |------- |----------:|-----------:|-----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|  **StackTryPop** |  **Clr** |     **Clr** |  **10000** |    **Int** |  **33.11 us** |  **3.3211 us** |   **9.635 us** |  **27.60 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| PooledTryPop |  Clr |     Clr |  10000 |    Int |  30.65 us |  2.7509 us |   7.981 us |  26.00 us |  0.99 |    0.35 |     - |     - |     - |         - |
|              |      |         |        |        |           |            |            |           |       |         |       |       |       |           |
|  StackTryPop | Core |    Core |  10000 |    Int |  65.79 us |  5.5470 us |  15.826 us |  65.10 us |  1.00 |    0.00 |     - |     - |     - |         - |
| PooledTryPop | Core |    Core |  10000 |    Int |  69.14 us |  4.5080 us |  12.934 us |  71.00 us |  1.10 |    0.30 |     - |     - |     - |         - |
|              |      |         |        |        |           |            |            |           |       |         |       |       |       |           |
|  **StackTryPop** |  **Clr** |     **Clr** |  **10000** | **String** |  **26.96 us** |  **0.5368 us** |   **1.097 us** |  **26.55 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| PooledTryPop |  Clr |     Clr |  10000 | String |  45.40 us |  2.0902 us |   5.757 us |  42.50 us |  1.70 |    0.24 |     - |     - |     - |         - |
|              |      |         |        |        |           |            |            |           |       |         |       |       |       |           |
|  StackTryPop | Core |    Core |  10000 | String | 155.49 us |  8.2265 us |  24.127 us | 150.50 us |  1.00 |    0.00 |     - |     - |     - |         - |
| PooledTryPop | Core |    Core |  10000 | String |  84.84 us |  6.7962 us |  19.499 us |  77.20 us |  0.56 |    0.15 |     - |     - |     - |         - |
|              |      |         |        |        |           |            |            |           |       |         |       |       |       |           |
|  **StackTryPop** |  **Clr** |     **Clr** | **100000** |    **Int** | **280.52 us** |  **8.3525 us** |  **23.005 us** | **277.20 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| PooledTryPop |  Clr |     Clr | 100000 |    Int | 310.07 us | 13.0907 us |  36.922 us | 301.85 us |  1.11 |    0.15 |     - |     - |     - |         - |
|              |      |         |        |        |           |            |            |           |       |         |       |       |       |           |
|  StackTryPop | Core |    Core | 100000 |    Int | 565.07 us | 16.7186 us |  47.155 us | 553.70 us |  1.00 |    0.00 |     - |     - |     - |         - |
| PooledTryPop | Core |    Core | 100000 |    Int | 636.40 us | 19.5154 us |  55.679 us | 617.25 us |  1.14 |    0.14 |     - |     - |     - |         - |
|              |      |         |        |        |           |            |            |           |       |         |       |       |       |           |
|  **StackTryPop** |  **Clr** |     **Clr** | **100000** | **String** | **302.22 us** | **12.9595 us** |  **37.391 us** | **288.40 us** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| PooledTryPop |  Clr |     Clr | 100000 | String | 484.83 us | 22.7296 us |  63.361 us | 465.15 us |  1.61 |    0.26 |     - |     - |     - |         - |
|              |      |         |        |        |           |            |            |           |       |         |       |       |       |           |
|  StackTryPop | Core |    Core | 100000 | String | 540.30 us | 35.6308 us |  96.330 us | 502.50 us |  1.00 |    0.00 |     - |     - |     - |         - |
| PooledTryPop | Core |    Core | 100000 | String | 619.97 us | 51.6006 us | 149.703 us | 554.10 us |  1.19 |    0.34 |     - |     - |     - |         - |
