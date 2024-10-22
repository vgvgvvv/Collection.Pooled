﻿using BenchmarkDotNet.Attributes;

namespace Collections.Pooled.Benchmarks.PooledDictionary
{
    [Config(typeof(BenchmarkConfig))]
    public class Dict_TryGetValue_Exists : DictContainsBase_String
    {
        [Benchmark(Baseline = true)]
        public void DictTryGetValue()
        {
            for (int i = 0; i <= N; i++)
            {
                dict.TryGetValue(key, out _);
            }
        }

        [Benchmark]
        public void PooledTryGetValue()
        {
            for (int i = 0; i <= N; i++)
            {
                pooled.TryGetValue(key, out _);
            }
        }

        private string key = null;

        public override void GlobalSetup()
        {
            base.GlobalSetup();

            // needs a specific seed to prevent key collision with TestData
            int i = 0;
            do
            {
                key = GetT(i++);
            } while (pooled.ContainsKey(key));
            dict.Add(key, "12");
            pooled.Add(key, "12");
        }
    }
}
