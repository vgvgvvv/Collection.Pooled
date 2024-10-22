// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Collections.Pooled.Tests.PooledSet
{
    public abstract partial class HashSet_Generic_Tests<T> : ISet_Generic_Tests<T>
    {
        [Theory]
        [MemberData(nameof(ValidCollectionSizes))]
        public void HashSet_Generic_Constructor_int(int capacity)
        {
            using var set = new PooledSet<T>(capacity);
            Assert.Equal(0, set.Count);
        }

        [Theory]
        [MemberData(nameof(ValidCollectionSizes))]
        public void HashSet_Generic_Constructor_int_AddUpToAndBeyondCapacity(int capacity)
        {
            using var set = new PooledSet<T>(capacity);

            AddToCollection(set, capacity);
            Assert.Equal(capacity, set.Count);

            AddToCollection(set, capacity + 1);
            Assert.Equal(capacity + 1, set.Count);
        }

        [Fact]
        public void HashSet_Generic_Constructor_Capacity_ToNextPrimeNumber()
        {
            // Highest pre-computed number + 1.
            const int Capacity = 7199370;
            using var set = new PooledSet<T>(Capacity);

            // Assert that the HashTable's capacity is set to the descendant prime number of the given one.
            const int NextPrime = 7199371;
            Assert.Equal(NextPrime, set.EnsureCapacity(0));
        }

        [Fact]
        public void HashSet_Generic_Constructor_int_Negative_ThrowsArgumentOutOfRangeException()
        {
            AssertExtensions.Throws<ArgumentOutOfRangeException>("capacity", () => new PooledSet<T>(-1));
            AssertExtensions.Throws<ArgumentOutOfRangeException>("capacity", () => new PooledSet<T>(Int32.MinValue));
        }

        [Theory]
        [MemberData(nameof(ValidCollectionSizes))]
        public void HashSet_Generic_Constructor_int_IEqualityComparer(int capacity)
        {
            var comparer = GetIEqualityComparer();
            using var set = new PooledSet<T>(capacity, comparer);
            Assert.Equal(0, set.Count);
            if (comparer == null)
            {
                Assert.Equal(EqualityComparer<T>.Default, set.Comparer);
            }
            else
            {
                Assert.Equal(comparer, set.Comparer);
            }
        }

        [Theory]
        [MemberData(nameof(ValidCollectionSizes))]
        public void HashSet_Generic_Constructor_int_IEqualityComparer_AddUpToAndBeyondCapacity(int capacity)
        {
            var comparer = GetIEqualityComparer();
            using var set = new PooledSet<T>(capacity, comparer);

            AddToCollection(set, capacity);
            Assert.Equal(capacity, set.Count);

            AddToCollection(set, capacity + 1);
            Assert.Equal(capacity + 1, set.Count);
        }

        [Fact]
        public void HashSet_Generic_Constructor_int_IEqualityComparer_Negative_ThrowsArgumentOutOfRangeException()
        {
            var comparer = GetIEqualityComparer();
            AssertExtensions.Throws<ArgumentOutOfRangeException>("capacity", () => new PooledSet<T>(-1, comparer));
            AssertExtensions.Throws<ArgumentOutOfRangeException>("capacity", () => new PooledSet<T>(Int32.MinValue, comparer));
        }

        #region TryGetValue

        [Fact]
        public void HashSet_Generic_TryGetValue_Contains()
        {
            var value = CreateT(1);
            using var set = new PooledSet<T> { value };
            var equalValue = CreateT(1);
            Assert.True(set.TryGetValue(equalValue, out var actualValue));
            Assert.Equal(value, actualValue);
            if (!typeof(T).IsValueType)
            {
#pragma warning disable xUnit2005 // Do not use identity check on value type
                Assert.Same(value, actualValue);
#pragma warning restore xUnit2005 // Do not use identity check on value type
            }
        }

        [Fact]
        public void HashSet_Generic_TryGetValue_Contains_OverwriteOutputParam()
        {
            var value = CreateT(1);
            using var set = new PooledSet<T> { value };
            var equalValue = CreateT(1);
            var actualValue = CreateT(2);
            Assert.True(set.TryGetValue(equalValue, out actualValue));
            Assert.Equal(value, actualValue);
            if (!typeof(T).IsValueType)
            {
#pragma warning disable xUnit2005 // Do not use identity check on value type
                Assert.Same(value, actualValue);
#pragma warning restore xUnit2005 // Do not use identity check on value type
            }
        }

        [Fact]
        public void HashSet_Generic_TryGetValue_NotContains()
        {
            var value = CreateT(1);
            using var set = new PooledSet<T> { value };
            var equalValue = CreateT(2);
            Assert.False(set.TryGetValue(equalValue, out var actualValue));
            Assert.Equal(default, actualValue);
        }

        [Fact]
        public void HashSet_Generic_TryGetValue_NotContains_OverwriteOutputParam()
        {
            var value = CreateT(1);
            using var set = new PooledSet<T> { value };
            var equalValue = CreateT(2);
            var actualValue = equalValue;
            Assert.False(set.TryGetValue(equalValue, out actualValue));
            Assert.Equal(default, actualValue);
        }

        #endregion

        #region EnsureCapacity

        [Theory]
        [MemberData(nameof(ValidCollectionSizes))]
        public void EnsureCapacity_Generic_RequestingLargerCapacity_DoesNotInvalidateEnumeration(int setLength)
        {
            var set = (PooledSet<T>)(GenericISetFactory(setLength));
            int capacity = set.EnsureCapacity(0);
            IEnumerator valuesEnum = set.GetEnumerator();
            IEnumerator valuesListEnum = new List<T>(set).GetEnumerator();

            set.EnsureCapacity(capacity + 1); // Verify EnsureCapacity does not invalidate enumeration

            while (valuesEnum.MoveNext())
            {
                valuesListEnum.MoveNext();
                Assert.Equal(valuesListEnum.Current, valuesEnum.Current);
            }
        }

        [Fact]
        public void EnsureCapacity_Generic_NegativeCapacityRequested_Throws()
        {
            using var set = new PooledSet<T>();
            AssertExtensions.Throws<ArgumentOutOfRangeException>("capacity", () => set.EnsureCapacity(-1));
        }

        [Fact]
        public void EnsureCapacity_Generic_HashsetNotInitialized_RequestedZero_ReturnsZero()
        {
            using var set = new PooledSet<T>();
            Assert.Equal(0, set.EnsureCapacity(0));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void EnsureCapacity_Generic_HashsetNotInitialized_RequestedNonZero_CapacityIsSetToAtLeastTheRequested(int requestedCapacity)
        {
            using var set = new PooledSet<T>();
            Assert.InRange(set.EnsureCapacity(requestedCapacity), requestedCapacity, Int32.MaxValue);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        public void EnsureCapacity_Generic_RequestedCapacitySmallerThanCurrent_CapacityUnchanged(int currentCapacity)
        {
            PooledSet<T> set;

            // assert capacity remains the same when ensuring a capacity smaller or equal than existing
            for (int i = 0; i <= currentCapacity; i++)
            {
                set = new PooledSet<T>(currentCapacity);
                RegisterForDispose(set);
                Assert.Equal(currentCapacity, set.EnsureCapacity(i));
            }
        }

        [Theory]
        [InlineData(7)]
        [InlineData(89)]
        public void EnsureCapacity_Generic_ExistingCapacityRequested_SameValueReturned(int capacity)
        {
            var set = new PooledSet<T>(capacity);
            RegisterForDispose(set);
            Assert.Equal(capacity, set.EnsureCapacity(capacity));

            set = (PooledSet<T>)GenericISetFactory(capacity);
            Assert.Equal(capacity, set.EnsureCapacity(capacity));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void EnsureCapacity_Generic_EnsureCapacityCalledTwice_ReturnsSameValue(int setLength)
        {
            var set = (PooledSet<T>)GenericISetFactory(setLength);
            int capacity = set.EnsureCapacity(0);
            Assert.Equal(capacity, set.EnsureCapacity(0));

            set = (PooledSet<T>)GenericISetFactory(setLength);
            capacity = set.EnsureCapacity(setLength);
            Assert.Equal(capacity, set.EnsureCapacity(setLength));

            set = (PooledSet<T>)GenericISetFactory(setLength);
            capacity = set.EnsureCapacity(setLength + 1);
            Assert.Equal(capacity, set.EnsureCapacity(setLength + 1));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(8)]
        public void EnsureCapacity_Generic_HashsetNotEmpty_RequestedSmallerThanCount_ReturnsAtLeastSizeOfCount(int setLength)
        {
            var set = (PooledSet<T>)GenericISetFactory(setLength);
            Assert.InRange(set.EnsureCapacity(setLength - 1), setLength, Int32.MaxValue);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(20)]
        public void EnsureCapacity_Generic_HashsetNotEmpty_SetsToAtLeastTheRequested(int setLength)
        {
            var set = (PooledSet<T>)GenericISetFactory(setLength);

            // get current capacity
            int currentCapacity = set.EnsureCapacity(0);

            // assert we can update to a larger capacity
            int newCapacity = set.EnsureCapacity(currentCapacity * 2);
            Assert.InRange(newCapacity, currentCapacity * 2, Int32.MaxValue);
        }

        [Fact]
        public void EnsureCapacity_Generic_CapacityIsSetToPrimeNumberLargerOrEqualToRequested()
        {
            var set = new PooledSet<T>();
            RegisterForDispose(set);
            Assert.Equal(17, set.EnsureCapacity(17));

            set = new PooledSet<T>();
            RegisterForDispose(set);
            Assert.Equal(17, set.EnsureCapacity(15));

            set = new PooledSet<T>();
            RegisterForDispose(set);
            Assert.Equal(17, set.EnsureCapacity(13));
        }

        #endregion
    }
}
