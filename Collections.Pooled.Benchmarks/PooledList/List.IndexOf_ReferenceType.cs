﻿using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Collections.Pooled.Benchmarks.PooledList
{
    [Config(typeof(BenchmarkConfig))]
    public class List_IndexOf_ReferenceType : ListBase
    {
        [Benchmark(Baseline = true)]
        public void List_IndexOf()
        {
            list.IndexOf(nonexistentItem);
            list.IndexOf(firstItem);
            list.IndexOf(middleItem);
            list.IndexOf(lastItem);
        }

        [Benchmark]
        public void Pooled_IndexOf()
        {
            pooled.IndexOf(nonexistentItem);
            pooled.IndexOf(firstItem);
            pooled.IndexOf(middleItem);
            pooled.IndexOf(lastItem);
        }

        private List<string> list;
        private PooledList<string> pooled;
        string nonexistentItem, firstItem, middleItem, lastItem;

        //[Params(1_000, 10_000, 100_000)]
        //public int N;

        [GlobalSetup]
        public void GlobalSetup()
        {
            int N = 8192;
            list = new List<string>(N);
            pooled = new PooledList<string>(N);

            for (int i = 0; i < N; i++)
            {
                list.Add(i.ToString());
                pooled.Add(i.ToString());
            }

            nonexistentItem = "foo";
            firstItem = 0.ToString();
            middleItem = (list.Count / 2).ToString();
            lastItem = (list.Count - 1).ToString();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            pooled?.Dispose();
        }
    }
}
