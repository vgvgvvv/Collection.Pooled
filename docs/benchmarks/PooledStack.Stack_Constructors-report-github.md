``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host] : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3801.0
  Core   : .NET Core 3.0.0-preview5-27626-15 (CoreCLR 4.6.27622.75, CoreFX 4.700.19.22408), 64bit RyuJIT

Jit=RyuJit  Platform=X64  

```
|             Method |  Job | Runtime |      N |   Type |           Mean |         Error |        StdDev | Ratio | RatioSD |       Gen 0 |       Gen 1 |       Gen 2 |     Allocated |
|------------------- |----- |-------- |------- |------- |---------------:|--------------:|--------------:|------:|--------:|------------:|------------:|------------:|--------------:|
|  **Stack_ICollection** |  **Clr** |     **Clr** |   **1000** |    **Int** |       **278.4 us** |      **5.276 us** |      **5.645 us** |  **1.00** |    **0.00** |   **1294.9219** |           **-** |           **-** |     **3984.4 KB** |
| Pooled_ICollection |  Clr |     Clr |   1000 |    Int |     1,051.5 us |     16.427 us |     15.366 us |  3.79 |    0.08 |     17.5781 |           - |           - |      54.86 KB |
|  Stack_IEnumerable |  Clr |     Clr |   1000 |    Int |     7,914.0 us |    154.736 us |    231.601 us | 28.57 |    1.19 |   2687.5000 |           - |           - |    8299.85 KB |
| Pooled_IEnumerable |  Clr |     Clr |   1000 |    Int |    10,054.3 us |    124.771 us |    116.711 us | 36.23 |    0.84 |     46.8750 |           - |           - |     148.88 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  Stack_ICollection | Core |    Core |   1000 |    Int |       278.9 us |      5.549 us |      7.595 us |  1.00 |    0.00 |   1291.5039 |           - |           - |    3960.94 KB |
| Pooled_ICollection | Core |    Core |   1000 |    Int |       144.1 us |      2.876 us |      2.953 us |  0.52 |    0.02 |     17.8223 |           - |           - |      54.69 KB |
|  Stack_IEnumerable | Core |    Core |   1000 |    Int |     6,456.4 us |     72.066 us |     63.885 us | 23.32 |    0.55 |   2695.3125 |           - |           - |    8265.63 KB |
| Pooled_IEnumerable | Core |    Core |   1000 |    Int |     7,160.4 us |     33.598 us |     31.428 us | 25.87 |    0.65 |     46.8750 |           - |           - |     148.44 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  **Stack_ICollection** |  **Clr** |     **Clr** |   **1000** | **String** |       **786.8 us** |     **10.717 us** |     **10.025 us** |  **1.00** |    **0.00** |   **2570.3125** |           **-** |           **-** |    **7917.38 KB** |
| Pooled_ICollection |  Clr |     Clr |   1000 | String |     2,195.0 us |     33.696 us |     31.519 us |  2.79 |    0.05 |     15.6250 |           - |           - |      54.88 KB |
|  Stack_IEnumerable |  Clr |     Clr |   1000 | String |    13,180.4 us |    249.752 us |    233.619 us | 16.75 |    0.35 |   5296.8750 |           - |           - |   16320.59 KB |
| Pooled_IEnumerable |  Clr |     Clr |   1000 | String |    19,887.7 us |    388.936 us |    363.811 us | 25.28 |    0.60 |     31.2500 |           - |           - |     156.75 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  Stack_ICollection | Core |    Core |   1000 | String |       692.3 us |     13.758 us |     21.010 us |  1.00 |    0.00 |   2563.4766 |           - |           - |    7867.19 KB |
| Pooled_ICollection | Core |    Core |   1000 | String |       600.2 us |     10.640 us |      9.953 us |  0.88 |    0.02 |     17.5781 |           - |           - |      54.69 KB |
|  Stack_IEnumerable | Core |    Core |   1000 | String |    12,527.4 us |    242.798 us |    259.791 us | 18.39 |    0.66 |   5296.8750 |           - |           - |   16257.81 KB |
| Pooled_IEnumerable | Core |    Core |   1000 | String |    14,089.9 us |    139.579 us |    123.733 us | 20.75 |    0.60 |     46.8750 |           - |           - |     156.25 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  **Stack_ICollection** |  **Clr** |     **Clr** |  **10000** |    **Int** |     **2,883.6 us** |     **39.573 us** |     **37.017 us** |  **1.00** |    **0.00** |  **12656.2500** |           **-** |           **-** |   **39210.66 KB** |
| Pooled_ICollection |  Clr |     Clr |  10000 |    Int |    15,592.2 us |    143.665 us |    134.384 us |  5.41 |    0.10 |     15.6250 |           - |           - |      54.88 KB |
|  Stack_IEnumerable |  Clr |     Clr |  10000 |    Int |    78,918.9 us |  1,055.223 us |    987.057 us | 27.37 |    0.53 |  41571.4286 |           - |           - |  128521.21 KB |
| Pooled_IEnumerable |  Clr |     Clr |  10000 |    Int |   110,104.4 us |  1,402.826 us |  1,312.205 us | 38.19 |    0.66 |           - |           - |           - |      150.4 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  Stack_ICollection | Core |    Core |  10000 |    Int |     2,840.8 us |     35.185 us |     32.912 us |  1.00 |    0.00 |  12656.2500 |           - |           - |   39117.19 KB |
| Pooled_ICollection | Core |    Core |  10000 |    Int |     1,013.8 us |     13.886 us |     12.989 us |  0.36 |    0.01 |     17.5781 |           - |           - |      54.69 KB |
|  Stack_IEnumerable | Core |    Core |  10000 |    Int |    68,481.7 us |  1,113.670 us |  1,041.728 us | 24.11 |    0.48 |  41625.0000 |           - |           - |  128359.38 KB |
| Pooled_IEnumerable | Core |    Core |  10000 |    Int |    66,449.4 us |  1,043.008 us |    975.631 us | 23.39 |    0.45 |           - |           - |           - |     148.44 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  **Stack_ICollection** |  **Clr** |     **Clr** |  **10000** | **String** |     **7,717.6 us** |    **154.066 us** |    **164.849 us** |  **1.00** |    **0.00** |  **24992.1875** |           **-** |           **-** |   **78371.88 KB** |
| Pooled_ICollection |  Clr |     Clr |  10000 | String |    31,697.2 us |    602.261 us |    563.355 us |  4.12 |    0.10 |           - |           - |           - |         55 KB |
|  Stack_IEnumerable |  Clr |     Clr |  10000 | String |   176,075.7 us |  3,516.735 us |  3,611.427 us | 22.85 |    0.69 |  41333.3333 |  41333.3333 |  41333.3333 |  256544.27 KB |
| Pooled_IEnumerable |  Clr |     Clr |  10000 | String |   221,596.4 us |  4,236.656 us |  3,962.971 us | 28.82 |    0.92 |           - |           - |           - |     157.33 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  Stack_ICollection | Core |    Core |  10000 | String |     7,022.0 us |     65.301 us |     54.529 us |  1.00 |    0.00 |  24992.1875 |           - |           - |   78179.69 KB |
| Pooled_ICollection | Core |    Core |  10000 | String |     8,292.2 us |    105.167 us |     98.373 us |  1.18 |    0.01 |     15.6250 |           - |           - |      54.69 KB |
|  Stack_IEnumerable | Core |    Core |  10000 | String |   170,911.5 us |  3,243.802 us |  3,331.146 us | 24.29 |    0.58 |  41333.3333 |  41333.3333 |  41333.3333 |  256351.56 KB |
| Pooled_IEnumerable | Core |    Core |  10000 | String |   137,300.4 us |  1,358.507 us |  1,134.415 us | 19.55 |    0.22 |           - |           - |           - |     156.25 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  **Stack_ICollection** |  **Clr** |     **Clr** | **100000** |    **Int** |    **63,000.7 us** |  **1,222.346 us** |  **1,589.395 us** |  **1.00** |    **0.00** |  **21333.3333** |  **21333.3333** |  **21333.3333** |  **390866.75 KB** |
| Pooled_ICollection |  Clr |     Clr | 100000 |    Int |   129,650.7 us |  1,466.197 us |  1,371.481 us |  2.05 |    0.07 |           - |           - |           - |         56 KB |
|  Stack_IEnumerable |  Clr |     Clr | 100000 |    Int |   878,893.3 us |  5,391.086 us |  5,042.825 us | 13.90 |    0.39 | 186000.0000 | 146000.0000 | 144000.0000 | 1027370.37 KB |
| Pooled_IEnumerable |  Clr |     Clr | 100000 |    Int | 1,011,410.4 us |  2,160.759 us |  2,021.175 us | 16.00 |    0.43 |           - |           - |           - |     150.96 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  Stack_ICollection | Core |    Core | 100000 |    Int |    65,634.2 us |  1,278.835 us |  1,133.654 us |  1.00 |    0.00 |  23250.0000 |  23250.0000 |  23250.0000 |  390837.05 KB |
| Pooled_ICollection | Core |    Core | 100000 |    Int |    14,957.6 us |     68.564 us |     64.135 us |  0.23 |    0.00 |     15.6250 |           - |           - |      54.69 KB |
|  Stack_IEnumerable | Core |    Core | 100000 |    Int |   805,672.3 us |  5,467.038 us |  5,113.871 us | 12.29 |    0.23 | 200000.0000 | 161000.0000 | 158000.0000 | 1025301.93 KB |
| Pooled_IEnumerable | Core |    Core | 100000 |    Int |   636,882.1 us |  6,799.661 us |  6,360.407 us |  9.71 |    0.17 |           - |           - |           - |     148.44 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  **Stack_ICollection** |  **Clr** |     **Clr** | **100000** | **String** |   **439,553.6 us** |  **6,679.839 us** |  **6,248.326 us** |  **1.00** |    **0.00** |  **17000.0000** |  **17000.0000** |  **17000.0000** |  **781465.49 KB** |
| Pooled_ICollection |  Clr |     Clr | 100000 | String |   272,424.5 us |  3,155.962 us |  2,952.089 us |  0.62 |    0.01 |           - |           - |           - |         56 KB |
|  Stack_IEnumerable |  Clr |     Clr | 100000 | String | 1,653,246.9 us | 13,803.483 us | 12,911.786 us |  3.76 |    0.07 | 289000.0000 | 249000.0000 | 246000.0000 |  2053241.6 KB |
| Pooled_IEnumerable |  Clr |     Clr | 100000 | String | 2,100,444.9 us |  3,314.339 us |  3,100.235 us |  4.78 |    0.07 |           - |           - |           - |        160 KB |
|                    |      |         |        |        |                |               |               |       |         |             |             |             |               |
|  Stack_ICollection | Core |    Core | 100000 | String |   426,314.0 us |  8,230.675 us | 11,266.241 us |  1.00 |    0.00 |  25000.0000 |  25000.0000 |  25000.0000 |  781419.49 KB |
| Pooled_ICollection | Core |    Core | 100000 | String |    82,736.9 us |  1,026.354 us |    909.836 us |  0.20 |    0.01 |           - |           - |           - |      54.69 KB |
|  Stack_IEnumerable | Core |    Core | 100000 | String | 1,555,364.8 us |  9,028.426 us |  8,445.195 us |  3.67 |    0.11 | 308000.0000 | 271000.0000 | 265000.0000 |  2049583.2 KB |
| Pooled_IEnumerable | Core |    Core | 100000 | String | 1,407,568.1 us |  5,778.675 us |  5,405.376 us |  3.32 |    0.09 |           - |           - |           - |     156.25 KB |
