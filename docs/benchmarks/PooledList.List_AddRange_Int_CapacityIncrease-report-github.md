``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview6-012264
  [Host] : .NET Core 3.0.0-preview6-27804-01 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview6-27804-01 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), 64bit RyuJIT

Jit=RyuJit  Platform=X64  

```
|            Method |  Job | Runtime | LargeSets |        Mean |      Error |     StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------------ |----- |-------- |---------- |------------:|-----------:|-----------:|------:|--------:|---------:|---------:|---------:|----------:|
|        **List_Array** |  **Clr** |     **Clr** |     **False** | **2,385.16 us** | **45.3635 us** | **48.5384 us** |  **1.00** |    **0.00** | **878.9063** | **527.3438** | **527.3438** | **3715339 B** |
|   List_Enumerable |  Clr |     Clr |     False | 3,865.06 us | 41.2950 us | 38.6274 us |  1.62 |    0.03 | 492.1875 | 492.1875 | 492.1875 | 2781472 B |
|      Pooled_Array |  Clr |     Clr |     False | 1,215.18 us |  6.2478 us |  5.2172 us |  0.51 |    0.01 |        - |        - |        - |      64 B |
| Pooled_Enumerable |  Clr |     Clr |     False | 2,844.08 us | 15.6356 us | 13.8605 us |  1.19 |    0.03 | 214.8438 |        - |        - |  682094 B |
|                   |      |         |           |             |            |            |       |         |          |          |          |           |
|        List_Array | Core |    Core |     False | 1,266.57 us | 16.2322 us | 15.1836 us |  1.00 |    0.00 | 603.5156 | 599.6094 | 599.6094 | 2621839 B |
|   List_Enumerable | Core |    Core |     False | 3,545.75 us |  9.4330 us |  8.3622 us |  2.80 |    0.03 | 496.0938 | 496.0938 | 496.0938 | 2777576 B |
|      Pooled_Array | Core |    Core |     False |   575.11 us |  5.0663 us |  4.7390 us |  0.45 |    0.01 |        - |        - |        - |      56 B |
| Pooled_Enumerable | Core |    Core |     False | 2,281.42 us | 16.7062 us | 15.6270 us |  1.80 |    0.02 | 214.8438 |        - |        - |  680056 B |
|                   |      |         |           |             |            |            |       |         |          |          |          |           |
|        **List_Array** |  **Clr** |     **Clr** |      **True** |   **689.09 us** |  **6.1352 us** |  **5.7388 us** |  **1.00** |    **0.00** | **745.1172** | **514.6484** | **500.9766** | **3206668 B** |
|   List_Enumerable |  Clr |     Clr |      True | 2,819.14 us | 20.3595 us | 19.0443 us |  4.09 |    0.04 | 496.0938 | 496.0938 | 496.0938 | 2101536 B |
|      Pooled_Array |  Clr |     Clr |      True |   579.94 us |  3.8514 us |  3.6026 us |  0.84 |    0.01 |        - |        - |        - |      64 B |
| Pooled_Enumerable |  Clr |     Clr |      True | 2,056.72 us | 21.2397 us | 19.8676 us |  2.98 |    0.04 |        - |        - |        - |     768 B |
|                   |      |         |           |             |            |            |       |         |          |          |          |           |
|        List_Array | Core |    Core |      True |   546.65 us | 10.7794 us | 12.8321 us |  1.00 |    0.00 | 460.9375 | 426.7578 | 422.8516 | 2521582 B |
|   List_Enumerable | Core |    Core |      True | 2,685.07 us | 19.6595 us | 18.3895 us |  4.91 |    0.12 | 496.0938 | 496.0938 | 496.0938 | 2098256 B |
|      Pooled_Array | Core |    Core |      True |    65.46 us |  0.6463 us |  0.6046 us |  0.12 |    0.00 |        - |        - |        - |      56 B |
| Pooled_Enumerable | Core |    Core |      True | 1,528.14 us | 11.9967 us | 11.2218 us |  2.79 |    0.07 |        - |        - |        - |     736 B |
