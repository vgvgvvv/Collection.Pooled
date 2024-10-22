﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;

namespace Collections.Pooled.Tests.PooledList
{
    /// <summary>
    /// Contains tests that ensure the correctness of the List class.
    /// </summary>
    public abstract partial class List_Generic_Tests<T> : IList_Generic_Tests<T>
    {
        [Theory]
        [MemberData(nameof(ValidCollectionSizes))]
        public void ForEach_Verify(int count)
        {
            var list = GenericListFactory(count);
            var visitedItems = new PooledList<T>();
            void action(T item) => visitedItems.Add(item);

            //[] Verify ForEach looks at every item
            visitedItems.Clear();
            list.ForEach(action);
            VerifyList(list, visitedItems);

            list.Dispose();
            visitedItems.Dispose();
        }

        [Theory]
        [MemberData(nameof(ValidCollectionSizes))]
        public void ForEach_Index_Verify(int count)
        {
            var list = GenericListFactory(count);
            var visitedItems = new PooledList<T>();
            void action(T item, int i) => visitedItems.Add(item);

            //[] Verify ForEach looks at every item
            visitedItems.Clear();
            list.ForEach(action);
            VerifyList(list, visitedItems);

            list.Dispose();
            visitedItems.Dispose();
        }

        [Fact]
        public void ForEach_NullAction_ThrowsArgumentNullException()
        {
            var list = GenericListFactory();
            Assert.Throws<ArgumentNullException>(() => list.ForEach((Action<T>)null));
            list.Dispose();
        }
    }
}
