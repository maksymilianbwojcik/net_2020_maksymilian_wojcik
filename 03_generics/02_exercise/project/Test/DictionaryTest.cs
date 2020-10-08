using System;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class DictionaryTest
    {
        [Fact]
        public void DictionaryOfInToIntChangeExistingValue()
        {
            // TODO: ...

            var dictionary = new Dictionary<int, int> 
            {
                {1, 10}
            };
            
            Assert.Single(dictionary);
            Assert.Equal(10, dictionary[1]);

            // TODO: ...

            dictionary[1] = 20;
            
            Assert.Single(dictionary);
            Assert.Equal(20, dictionary[1]);
        }

        [Fact]
        public void DictionaryOfInToIntRemoveValues()
        {
            // TODO: ...
            
            var dictionary = new Dictionary<int, int>
            {
                {1,0},
                {2,0},
                {3,0}
            };
            
            Assert.Equal(3, dictionary.Count);
            Assert.True(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(2));
            Assert.True(dictionary.ContainsKey(3));

            // TODO: ...

            dictionary.Remove(2);
            dictionary.Remove(3);

            Assert.Single(dictionary);
            Assert.True(dictionary.ContainsKey(1));
            Assert.False(dictionary.ContainsKey(2));
            Assert.False(dictionary.ContainsKey(3));
        }

        [Fact]
        public void DictionaryOfInToIntTryGetValue()
        {
            // TODO: ...
            
            var dictionary = new Dictionary<int, int>
            {
                {1, 10}
            };

            Assert.Single(dictionary);
            Assert.Equal(10, dictionary[1]);

            // TODO: ...
            
            var value = 10;
            var hasValue = dictionary.TryGetValue(1, out value);
            
            Assert.True(hasValue);
            Assert.Equal(10, value);
            
            Assert.Single(dictionary);
        }

        [Fact]
        public void DictionaryOfIntToIntCanBeCreatedInOneLine()
        {
            // TODO: ...
            var dictionary = new Dictionary<int, int>
            {
                {1, 2},
                {3, 4}
            };

            Assert.Equal(2, dictionary.Count);
            Assert.Equal(2, dictionary[1]);
            Assert.Equal(4, dictionary[3]);
        }

        [Fact]
        public void DictionaryOfStringToStringThrowsWheKeyNotInDictionary()
        {
            // TODO: ...

            var dictionary = new Dictionary<string, string>
            {
                {"A", "B"}
            };
            
            Assert.Single(dictionary);
            Assert.Equal("B", dictionary["A"]);

            void AccessElement()
            {
                // TODO: ...
                var b = dictionary["B"];
            }

            Assert.Throws<KeyNotFoundException>(AccessElement);

            // TODO: ...
            
            dictionary.Add("B", "H");
            
            Assert.Equal(2, dictionary.Count);

            AccessElement();
        }

        [Fact]
        public void DictionaryOfStringToStringThrowsWhenAddedElementExists()
        {
            // TODO: ...
            
            var dictionary = new Dictionary<string, string>
            {
                {"A", "B"}
            };

            Assert.Single(dictionary);
            Assert.Equal("B", dictionary["A"]);

            void AddElement()
            {
                // TODO: ...
                    dictionary.Add("A", "C");
            }

            Assert.Throws<ArgumentException>(AddElement);

            // TODO: ...

            dictionary.Remove("A");
            
            Assert.Empty(dictionary);

            AddElement();
            
            Assert.Single(dictionary);
            Assert.Equal("C", dictionary["A"]);
        }
    }
}