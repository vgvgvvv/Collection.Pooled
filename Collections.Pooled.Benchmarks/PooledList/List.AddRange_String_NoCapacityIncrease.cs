﻿using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Collections.Pooled.Benchmarks.PooledList
{
    [Config(typeof(BenchmarkConfig))]
    public class List_AddRange_String_NoCapacityIncrease : ListBase
    {
        [Benchmark(Baseline = true)]
        public void List_Array()
        {
            //Clear the list without changing its capacity, so that when more data is added to the list its
            //capacity will not need to increase.
            list.RemoveRange(0, startingCapacity);

            for (int j = 0; j < addLoops; j++)
            {
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
            }
        }

        [Benchmark]
        public void Pooled_Array()
        {
            //Clear the list without changing its capacity, so that when more data is added to the list its
            //capacity will not need to increase.
            list.RemoveRange(0, startingCapacity);

            for (int j = 0; j < addLoops; j++)
            {
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
            }
        }

        [Benchmark]
        public void List_Enumerable()
        {
            //Clear the list without changing its capacity, so that when more data is added to the list its
            //capacity will not need to increase.
            pooled.RemoveRange(0, startingCapacity);

            for (int j = 0; j < addLoops; j++)
            {
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
            }
        }

        [Benchmark]
        public void Pooled_Enumerable()
        {
            //Clear the list without changing its capacity, so that when more data is added to the list its
            //capacity will not need to increase.
            pooled.RemoveRange(0, startingCapacity);

            for (int j = 0; j < addLoops; j++)
            {
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
                pooled.AddRange(SampleEnumerable());
            }
        }

        private int GetSampleLength()
        {
            if (LargeSets)
                return LARGE_SAMPLE_LENGTH;
            else
                return SMALL_SAMPLE_LENGTH;
        }

        private const int LARGE_SAMPLE_LENGTH = 10000;
        private const int SMALL_LOOPS = 1000;
        private const int SMALL_SAMPLE_LENGTH = LARGE_SAMPLE_LENGTH / SMALL_LOOPS;

        [Params(true, false)]
        public bool LargeSets;

        private string[] sampleSet;
        private List<string> list;
        private PooledList<string> pooled;
        private int addLoops, startingCapacity;

        private IEnumerable<string> SampleEnumerable()
        {
            for (int i = 0; i < sampleSet.Length; i++)
            {
                yield return sampleSet[i];
            }
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            int samples = GetSampleLength();
            sampleSet = new string[samples];

            for (int i = 0; i < samples; i++)
            {
                sampleSet[i] = i.ToString();
            }

            addLoops = LARGE_SAMPLE_LENGTH / samples;

            // create lists big enough to hold 17 copies of the sample set
            startingCapacity = 17 * samples * addLoops;
            list = new List<string>(startingCapacity);
            pooled = new PooledList<string>(startingCapacity);

            for (int j = 0; j < addLoops; j++)
            {
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);
                list.AddRange(sampleSet);

                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
                pooled.AddRange(sampleSet);
            }
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            pooled?.Dispose();
        }
    }
}
