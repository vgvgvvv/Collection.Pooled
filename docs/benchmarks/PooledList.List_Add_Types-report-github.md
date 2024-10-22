``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host] : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT

Jit=RyuJit  Platform=X64  

```
|        Method |  Job | Runtime |    N |       Mean |     Error |    StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|-------------- |----- |-------- |----- |-----------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|
|      **List_Int** |  **Clr** |     **Clr** |  **256** |   **8.600 us** | **0.1393 us** | **0.1303 us** |  **1.00** |    **0.00** |  **10.5133** |        **-** |        **-** |   **33144 B** |
|    Pooled_Int |  Clr |     Clr |  256 |  12.550 us | 0.2279 us | 0.2132 us |  1.46 |    0.04 |   0.0153 |        - |        - |      56 B |
|   List_String |  Clr |     Clr |  256 |  15.209 us | 0.2970 us | 0.3177 us |  1.77 |    0.05 |  20.8130 |        - |        - |   65936 B |
| Pooled_String |  Clr |     Clr |  256 |  25.253 us | 0.4681 us | 0.4379 us |  2.94 |    0.06 |        - |        - |        - |      56 B |
|               |      |         |      |            |           |           |       |         |          |          |          |           |
|      List_Int | Core |    Core |  256 |   6.711 us | 0.0628 us | 0.0587 us |  1.00 |    0.00 |  10.5209 |        - |        - |   33048 B |
|    Pooled_Int | Core |    Core |  256 |   5.262 us | 0.0730 us | 0.0683 us |  0.78 |    0.01 |   0.0153 |        - |        - |      56 B |
|   List_String | Core |    Core |  256 |  14.044 us | 0.1756 us | 0.1642 us |  2.09 |    0.02 |  20.8282 |        - |        - |   65800 B |
| Pooled_String | Core |    Core |  256 |  13.579 us | 0.0561 us | 0.0497 us |  2.02 |    0.02 |   0.0153 |        - |        - |      56 B |
|               |      |         |      |            |           |           |       |         |          |          |          |           |
|      **List_Int** |  **Clr** |     **Clr** |  **512** |  **17.231 us** | **0.3296 us** | **0.3796 us** |  **1.00** |    **0.00** |  **20.8130** |        **-** |        **-** |   **66021 B** |
|    Pooled_Int |  Clr |     Clr |  512 |  24.641 us | 0.1382 us | 0.1293 us |  1.43 |    0.03 |        - |        - |        - |      56 B |
|   List_String |  Clr |     Clr |  512 |  30.701 us | 0.3558 us | 0.3329 us |  1.78 |    0.04 |  41.6260 |        - |        - |  131605 B |
| Pooled_String |  Clr |     Clr |  512 |  50.129 us | 0.5537 us | 0.5180 us |  2.91 |    0.07 |        - |        - |        - |      56 B |
|               |      |         |      |            |           |           |       |         |          |          |          |           |
|      List_Int | Core |    Core |  512 |  13.190 us | 0.1730 us | 0.1618 us |  1.00 |    0.00 |  20.8282 |        - |        - |   65840 B |
|    Pooled_Int | Core |    Core |  512 |   9.975 us | 0.1859 us | 0.1739 us |  0.76 |    0.02 |   0.0153 |        - |        - |      56 B |
|   List_String | Core |    Core |  512 |  28.800 us | 0.2925 us | 0.2736 us |  2.18 |    0.04 |  41.6565 |        - |        - |  131360 B |
| Pooled_String | Core |    Core |  512 |  26.174 us | 0.4898 us | 0.4582 us |  1.98 |    0.05 |        - |        - |        - |      56 B |
|               |      |         |      |            |           |           |       |         |          |          |          |           |
|      **List_Int** |  **Clr** |     **Clr** | **2048** | **118.886 us** | **1.7728 us** | **1.6582 us** |  **1.00** |    **0.00** |  **41.5039** |  **41.5039** |  **41.5039** |  **262702 B** |
|    Pooled_Int |  Clr |     Clr | 2048 |  95.424 us | 0.8630 us | 0.8072 us |  0.80 |    0.01 |        - |        - |        - |      57 B |
|   List_String |  Clr |     Clr | 2048 | 276.471 us | 4.4218 us | 4.1361 us |  2.33 |    0.06 | 124.5117 | 124.5117 | 124.5117 |  525552 B |
| Pooled_String |  Clr |     Clr | 2048 | 195.304 us | 3.7503 us | 3.6833 us |  1.64 |    0.05 |        - |        - |        - |      58 B |
|               |      |         |      |            |           |           |       |         |          |          |          |           |
|      List_Int | Core |    Core | 2048 | 102.187 us | 1.8745 us | 1.7534 us |  1.00 |    0.00 |  41.6260 |  41.6260 |  41.6260 |  262496 B |
|    Pooled_Int | Core |    Core | 2048 |  38.483 us | 0.6596 us | 0.6170 us |  0.38 |    0.01 |        - |        - |        - |      56 B |
|   List_String | Core |    Core | 2048 | 261.256 us | 4.0062 us | 3.7474 us |  2.56 |    0.06 | 124.5117 | 124.5117 | 124.5117 |  524624 B |
| Pooled_String | Core |    Core | 2048 | 108.695 us | 0.9348 us | 0.8744 us |  1.06 |    0.02 |        - |        - |        - |      56 B |
