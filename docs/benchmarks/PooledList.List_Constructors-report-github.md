``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host] : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT

Jit=RyuJit  Platform=X64  

```
|                       Method |  Job | Runtime |      N |   Type |           Mean |         Error |        StdDev | Ratio | RatioSD |       Gen 0 |       Gen 1 |       Gen 2 |     Allocated |
|----------------------------- |----- |-------- |------- |------- |---------------:|--------------:|--------------:|------:|--------:|------------:|------------:|------------:|--------------:|
|             **List_ICollection** |  **Clr** |     **Clr** |   **1000** |    **Int** |       **280.9 us** |      **5.526 us** |      **7.185 us** |  **1.00** |    **0.00** |   **1294.9219** |           **-** |           **-** |     **3984.4 KB** |
|           Pooled_ICollection |  Clr |     Clr |   1000 |    Int |     1,026.4 us |     20.001 us |     20.540 us |  3.65 |    0.11 |     17.5781 |           - |           - |      54.86 KB |
|             List_IEnumerable |  Clr |     Clr |   1000 |    Int |     8,795.1 us |    153.063 us |    143.175 us | 31.34 |    1.08 |   2687.5000 |           - |           - |    8299.85 KB |
| PooledIEnumerableConstructor |  Clr |     Clr |   1000 |    Int |     8,804.4 us |    150.599 us |    140.871 us | 31.37 |    1.14 |     15.6250 |           - |           - |      94.13 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             List_ICollection | Core |    Core |   1000 |    Int |       271.2 us |      5.118 us |      4.787 us |  1.00 |    0.00 |   1291.5039 |           - |           - |    3960.94 KB |
|           Pooled_ICollection | Core |    Core |   1000 |    Int |       136.7 us |      1.434 us |      1.341 us |  0.50 |    0.01 |     17.8223 |           - |           - |      54.69 KB |
|             List_IEnumerable | Core |    Core |   1000 |    Int |     6,538.5 us |    103.988 us |     97.271 us | 24.12 |    0.54 |   2695.3125 |           - |           - |    8265.63 KB |
| PooledIEnumerableConstructor | Core |    Core |   1000 |    Int |     6,297.1 us |    122.976 us |    115.032 us | 23.22 |    0.41 |     23.4375 |           - |           - |      93.75 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             **List_ICollection** |  **Clr** |     **Clr** |   **1000** | **String** |       **799.9 us** |     **15.631 us** |     **16.725 us** |  **1.00** |    **0.00** |   **2570.3125** |           **-** |           **-** |    **7917.38 KB** |
|           Pooled_ICollection |  Clr |     Clr |   1000 | String |     2,168.7 us |     41.952 us |     39.242 us |  2.72 |    0.09 |     15.6250 |           - |           - |      54.88 KB |
|             List_IEnumerable |  Clr |     Clr |   1000 | String |    13,305.3 us |    251.249 us |    246.760 us | 16.65 |    0.44 |   5296.8750 |           - |           - |   16320.59 KB |
| PooledIEnumerableConstructor |  Clr |     Clr |   1000 | String |    15,441.2 us |    290.430 us |    285.241 us | 19.32 |    0.54 |     31.2500 |           - |           - |        102 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             List_ICollection | Core |    Core |   1000 | String |       672.1 us |      8.244 us |      7.711 us |  1.00 |    0.00 |   2563.4766 |           - |           - |    7867.19 KB |
|           Pooled_ICollection | Core |    Core |   1000 | String |       583.0 us |      9.859 us |      9.222 us |  0.87 |    0.01 |     17.5781 |           - |           - |      54.69 KB |
|             List_IEnumerable | Core |    Core |   1000 | String |    12,562.8 us |    170.720 us |    159.691 us | 18.69 |    0.37 |   5296.8750 |           - |           - |   16257.81 KB |
| PooledIEnumerableConstructor | Core |    Core |   1000 | String |    12,721.4 us |     68.287 us |     63.876 us | 18.93 |    0.25 |     31.2500 |           - |           - |     101.56 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             **List_ICollection** |  **Clr** |     **Clr** |  **10000** |    **Int** |     **2,898.4 us** |     **46.267 us** |     **43.278 us** |  **1.00** |    **0.00** |  **12656.2500** |           **-** |           **-** |   **39210.66 KB** |
|           Pooled_ICollection |  Clr |     Clr |  10000 |    Int |    15,306.2 us |    210.893 us |    197.269 us |  5.28 |    0.10 |     15.6250 |           - |           - |      54.88 KB |
|             List_IEnumerable |  Clr |     Clr |  10000 |    Int |    86,912.8 us |  1,733.737 us |  1,702.762 us | 30.03 |    0.67 |  41500.0000 |           - |           - |  128520.83 KB |
| PooledIEnumerableConstructor |  Clr |     Clr |  10000 |    Int |    92,336.2 us |  1,790.585 us |  1,838.799 us | 31.79 |    0.84 |           - |           - |           - |      94.67 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             List_ICollection | Core |    Core |  10000 |    Int |     2,856.4 us |     67.078 us |     62.745 us |  1.00 |    0.00 |  12656.2500 |           - |           - |   39117.19 KB |
|           Pooled_ICollection | Core |    Core |  10000 |    Int |     1,141.9 us |     20.570 us |     19.241 us |  0.40 |    0.01 |     17.5781 |           - |           - |      54.69 KB |
|             List_IEnumerable | Core |    Core |  10000 |    Int |    66,332.1 us |    919.909 us |    860.484 us | 23.23 |    0.58 |  41625.0000 |           - |           - |  128359.38 KB |
| PooledIEnumerableConstructor | Core |    Core |  10000 |    Int |    57,915.3 us |    770.523 us |    720.748 us | 20.28 |    0.51 |           - |           - |           - |      93.75 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             **List_ICollection** |  **Clr** |     **Clr** |  **10000** | **String** |     **7,809.6 us** |    **151.393 us** |    **155.469 us** |  **1.00** |    **0.00** |  **24984.3750** |           **-** |           **-** |   **78371.88 KB** |
|           Pooled_ICollection |  Clr |     Clr |  10000 | String |    31,879.5 us |    603.944 us |    671.283 us |  4.09 |    0.12 |           - |           - |           - |         55 KB |
|             List_IEnumerable |  Clr |     Clr |  10000 | String |   185,799.6 us |  3,657.800 us |  4,065.635 us | 23.84 |    0.91 |  41333.3333 |  41333.3333 |  41333.3333 |  256544.27 KB |
| PooledIEnumerableConstructor |  Clr |     Clr |  10000 | String |   167,416.1 us |  3,229.899 us |  3,719.556 us | 21.51 |    0.68 |           - |           - |           - |        104 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             List_ICollection | Core |    Core |  10000 | String |     7,068.8 us |    138.151 us |    141.871 us |  1.00 |    0.00 |  24992.1875 |           - |           - |   78179.69 KB |
|           Pooled_ICollection | Core |    Core |  10000 | String |     8,210.5 us |    134.219 us |    112.079 us |  1.16 |    0.02 |     15.6250 |           - |           - |      54.69 KB |
|             List_IEnumerable | Core |    Core |  10000 | String |   184,084.6 us |  3,518.432 us |  3,455.571 us | 26.05 |    0.55 |  41333.3333 |  41333.3333 |  41333.3333 |  256351.56 KB |
| PooledIEnumerableConstructor | Core |    Core |  10000 | String |   124,878.6 us |  2,377.830 us |  2,224.224 us | 17.67 |    0.45 |           - |           - |           - |     101.56 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             **List_ICollection** |  **Clr** |     **Clr** | **100000** |    **Int** |    **63,359.7 us** |  **1,223.701 us** |  **1,144.650 us** |  **1.00** |    **0.00** |  **21750.0000** |  **21750.0000** |  **21750.0000** |  **390868.63 KB** |
|           Pooled_ICollection |  Clr |     Clr | 100000 |    Int |   125,330.9 us |  1,853.755 us |  1,734.004 us |  1.98 |    0.05 |           - |           - |           - |         56 KB |
|             List_IEnumerable |  Clr |     Clr | 100000 |    Int |   983,434.2 us | 17,994.980 us | 15,952.081 us | 15.54 |    0.38 | 195000.0000 | 155000.0000 | 153000.0000 | 1027642.03 KB |
| PooledIEnumerableConstructor |  Clr |     Clr | 100000 |    Int |   877,536.5 us |  5,191.000 us |  4,601.686 us | 13.86 |    0.26 |           - |           - |           - |         96 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             List_ICollection | Core |    Core | 100000 |    Int |    67,322.7 us |  1,287.272 us |  1,141.133 us |  1.00 |    0.00 |  22875.0000 |  22875.0000 |  22875.0000 |  390835.76 KB |
|           Pooled_ICollection | Core |    Core | 100000 |    Int |    14,924.9 us |     77.986 us |     72.948 us |  0.22 |    0.00 |     15.6250 |           - |           - |      54.69 KB |
|             List_IEnumerable | Core |    Core | 100000 |    Int |   770,353.9 us |  4,285.895 us |  4,009.028 us | 11.45 |    0.20 | 188000.0000 | 146000.0000 | 146000.0000 | 1025254.43 KB |
| PooledIEnumerableConstructor | Core |    Core | 100000 |    Int |   589,567.2 us |  7,719.768 us |  7,221.076 us |  8.76 |    0.17 |           - |           - |           - |      93.75 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             **List_ICollection** |  **Clr** |     **Clr** | **100000** | **String** |   **441,104.9 us** |  **6,637.039 us** |  **6,208.290 us** |  **1.00** |    **0.00** |  **17000.0000** |  **17000.0000** |  **17000.0000** |  **781465.61 KB** |
|           Pooled_ICollection |  Clr |     Clr | 100000 | String |   272,055.5 us |  3,090.388 us |  2,890.751 us |  0.62 |    0.01 |           - |           - |           - |         56 KB |
|             List_IEnumerable |  Clr |     Clr | 100000 | String | 1,594,022.1 us | 16,853.630 us | 15,764.896 us |  3.61 |    0.06 | 291000.0000 | 251000.0000 | 249000.0000 | 2052879.15 KB |
| PooledIEnumerableConstructor |  Clr |     Clr | 100000 | String | 1,598,188.8 us | 14,149.822 us | 13,235.752 us |  3.62 |    0.07 |           - |           - |           - |        104 KB |
|                              |      |         |        |        |                |               |               |       |         |             |             |             |               |
|             List_ICollection | Core |    Core | 100000 | String |   427,248.2 us |  8,450.925 us | 14,119.596 us |  1.00 |    0.00 |  16000.0000 |  16000.0000 |  16000.0000 |  781393.28 KB |
|           Pooled_ICollection | Core |    Core | 100000 | String |    85,661.6 us |    883.851 us |    826.755 us |  0.20 |    0.01 |           - |           - |           - |      54.69 KB |
|             List_IEnumerable | Core |    Core | 100000 | String | 1,564,072.6 us | 13,924.399 us | 13,024.891 us |  3.71 |    0.15 | 326000.0000 | 284000.0000 | 283000.0000 | 2049687.57 KB |
| PooledIEnumerableConstructor | Core |    Core | 100000 | String | 1,233,009.3 us |  3,512.002 us |  2,932.681 us |  2.93 |    0.12 |           - |           - |           - |     101.56 KB |
