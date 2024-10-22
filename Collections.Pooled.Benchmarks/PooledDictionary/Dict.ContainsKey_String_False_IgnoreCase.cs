﻿using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Collections.Pooled.Benchmarks.PooledDictionary
{
    [Config(typeof(BenchmarkConfig))]
    public class Dict_ContainsKey_String_False_IgnoreCase : DictContainsBase_String
    {
        [Benchmark(Baseline = true)]
        public void Dict_ContainsKey()
        {
            bool result = false;
            string missingKey = N.ToString();   //The value N is not present in the dictionary.
            for (int j = 0; j < N; j++)
                result = dict.ContainsKey(missingKey);
        }

        [Benchmark]
        public void Pooled_ContainsKey()
        {
            bool result = false;
            string missingKey = N.ToString();   //The value N is not present in the dictionary.
            for (int j = 0; j < N; j++)
                result = pooled.ContainsKey(missingKey);
        }

        protected override IEqualityComparer<string> Comparer
            => StringComparer.OrdinalIgnoreCase;
    }
}
