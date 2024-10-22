//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.
//// See the LICENSE file in the project root for more information.
#if NETCOREAPP
using System.Collections.Generic;
using Xunit;

namespace Collections.Pooled.Tests
{
    /// <summary>
    /// Contains tests that ensure the correctness of any class that implements the generic
    /// IDictionary interface
    /// </summary>
    public abstract partial class IDictionary_Generic_Tests<TKey, TValue> : ICollection_Generic_Tests<KeyValuePair<TKey, TValue>>
    {
        [Theory]
        [MemberData(nameof(ValidCollectionSizes))]
        public void KeyValuePair_Deconstruct(int size)
        {
            var dictionary = GenericIDictionaryFactory(size);
            Assert.All(dictionary, (entry) =>
            {
                entry.Deconstruct(out var key, out var value);
                Assert.Equal(entry.Key, key);
                Assert.Equal(entry.Value, value);

                key = default;
                value = default;
                (key, value) = entry;
                Assert.Equal(entry.Key, key);
                Assert.Equal(entry.Value, value);
            });
        }
    }
}
#endif
