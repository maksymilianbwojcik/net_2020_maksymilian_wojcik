using System;
using System.Collections.Generic;
using Xunit;
 
namespace Test
{
    public class ListTest
    {
        private static int ComparatorAsc(string x, string y)
        {
            return string.Compare(x, y, StringComparison.Ordinal);
        }
       
        private static int ComparatorDesc(string x, string y)
        {
            return string.Compare(x, y, StringComparison.Ordinal)*-1;
        }
       
        [Fact]
        public void ListOfIntHasSometimesHigherCapacityThanCount()
        {
            // TODO: ...
            List<int> list = new List<int> {1};
 
            Assert.Single(list);
            Assert.Equal(4, list.Capacity);
        }
 
        [Fact]
        public void ListOfIntHasSometimesTheSameSizeAndCapacity()
        {
            // TODO: ...
            List<int> listOne = new List<int> {1, 2, 3, 4};
 
            Assert.Equal(4, listOne.Count);
            Assert.Equal(4, listOne.Capacity);
 
            // TODO: ...
            List<int> listTwo = new List<int> {1, 2};
 
            Assert.Equal(2, listTwo.Count);
            Assert.Equal(4, listTwo.Capacity);
        }
 
        [Fact]
        public void ListOfIntSometimesGrowsCapacityAfterAdd()
        {
            // TODO: ...
            List<int> list = new List<int> {1, 2};
       
            Assert.Equal(2, list.Count);
            Assert.Equal(4, list.Capacity);
       
            // TODO: ...
            list.Add(3);
       
            Assert.Equal(3, list.Count);
            Assert.Equal(4, list.Capacity);
       
            // TODO: ...
            list.Add(4);
       
            Assert.Equal(4, list.Count);
            Assert.Equal(4, list.Capacity);
       
            // TODO: ...
            list.Add(5);
       
            Assert.Equal(5, list.Count);
            Assert.Equal(8, list.Capacity);
        }
       
        [Fact]
        public void ListOfStringCanBeCreatedInOneLine()
        {
            // TODO: ...
            List<string> list = new List<string>{"Foo","Bar","Baz"};
       
            Assert.Equal(3, list.Count);
            Assert.Equal("Foo", list[0]);
            Assert.Equal("Bar", list[1]);
            Assert.Equal("Baz", list[2]);
        }
       
        [Fact]
        public void ListOfStringCanBeSortedWithCustomComparators()
        {
            // TODO: ...
            List<string> list = new List<string>{"EC","FB","GA","AG","BF","CE","DD"};
           
           
            Assert.Equal(7, list.Count);
            Assert.Equal("EC", list[0]);
            Assert.Equal("FB", list[1]);
            Assert.Equal("GA", list[2]);
            Assert.Equal("AG", list[3]);
            Assert.Equal("BF", list[4]);
            Assert.Equal("CE", list[5]);
            Assert.Equal("DD", list[6]);
           
            // TODO: ...
            list.Sort(ComparatorDesc);
           
            Assert.Equal(7, list.Count);
            Assert.Equal("GA", list[0]);
            Assert.Equal("FB", list[1]);
            Assert.Equal("EC", list[2]);
            Assert.Equal("DD", list[3]);
            Assert.Equal("CE", list[4]);
            Assert.Equal("BF", list[5]);
            Assert.Equal("AG", list[6]);
           
            // TODO: ...
            list.Sort(ComparatorAsc);
           
            Assert.Equal(7, list.Count);
            Assert.Equal("AG", list[0]);
            Assert.Equal("BF", list[1]);
            Assert.Equal("CE", list[2]);
            Assert.Equal("DD", list[3]);
            Assert.Equal("EC", list[4]);
            Assert.Equal("FB", list[5]);
            Assert.Equal("GA", list[6]);
        }
    }
}