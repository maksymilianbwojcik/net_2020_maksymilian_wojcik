using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class HashSetTest
    {
        [Fact]
        public void HashSetStringBasicOperations()
        {
            // TODO: ...
            
            var hashSet = new HashSet<string> {"A","B","C"};
            
            Assert.Equal(3, hashSet.Count);
            Assert.Contains("A", hashSet);
            Assert.Contains("B", hashSet);
            Assert.Contains("C", hashSet);

            // TODO: ...
            hashSet.Remove("A");

            Assert.Equal(2, hashSet.Count);
            Assert.DoesNotContain("A", hashSet);
            Assert.Contains("B", hashSet);
            Assert.Contains("C", hashSet);
        }

        [Fact]
        public void HashSetStringIsCommonPart()
        {
            // TODO: ...
            
            var hashSetA = new HashSet<string> {"A","B","C"};

            Assert.Equal(3, hashSetA.Count);
            Assert.Contains("A", hashSetA);
            Assert.Contains("B", hashSetA);
            Assert.Contains("C", hashSetA);

            // TODO: ...
            
            var hashSetB = new HashSet<string> {"A","B","F"};

            Assert.Equal(3, hashSetB.Count);
            Assert.Contains("A", hashSetB);
            Assert.Contains("B", hashSetB);
            Assert.Contains("F", hashSetB);

            // TODO: ...

            hashSetA.IntersectWith(hashSetB);
            
            Assert.Equal(2, hashSetA.Count);
            Assert.Contains("A", hashSetA);
            Assert.Contains("B", hashSetA);

            Assert.Equal(3, hashSetB.Count);
            Assert.Contains("A", hashSetB);
            Assert.Contains("B", hashSetB);
            Assert.Contains("F", hashSetB);
        }

        [Fact]
        public void HashSetStringIsSubsetOfOtherSet()
        {
            // TODO: ...

            var hashSetA = new HashSet<int> {1,2,3,4,5};
            var hashSetB = new HashSet<int> {2,3,4};
            var hashSetSuperset = hashSetA;
            hashSetSuperset.UnionWith(hashSetB);
            var hashSetSubset = hashSetB;
            hashSetSubset.IntersectWith(hashSetA);
            
            Assert.Equal(5, hashSetSuperset.Count);
            Assert.Equal(3, hashSetSubset.Count);

            Assert.True(hashSetSuperset.Overlaps(hashSetSubset));
            Assert.True(hashSetSubset.Overlaps(hashSetSuperset));
        }
    }
}