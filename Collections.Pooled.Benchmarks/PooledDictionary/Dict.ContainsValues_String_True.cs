﻿using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Collections.Pooled.Benchmarks.PooledDictionary
{
    [Config(typeof(BenchmarkConfig))]
    public class Dict_ContainsValue_String_True : DictContainsBase_String
    {
        [Benchmark(Baseline = true)]
        public void Dict_ContainsVal()
        {
            bool result = false;
            for (int j = 0; j < N; j++)
                result = dict.ContainsValue(sampleKeys[j]);
        }

        [Benchmark]
        public void Pooled_ContainsVal()
        {
            bool result = false;
            for (int j = 0; j < N; j++)
                result = pooled.ContainsValue(sampleKeys[j]);
        }

        private string[] sampleKeys;

        public override void GlobalSetup()
        {
            base.GlobalSetup();
            sampleKeys = dict.Keys.ToArray();
        }
    }
}
