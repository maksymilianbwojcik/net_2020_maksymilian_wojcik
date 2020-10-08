using System.Collections.Generic;
using Xunit;
 
namespace Test
{
	public class SortedListTest
	{
		// TODO: ReversedComparer class...
		private class ReversedComparer : IComparer<int>
		{
			public int Compare(int x, int y)
			{
				var res = Comparer<int>.Default.Compare(x, y);
				return 0 - res;
			}
		}
       
		[Fact]
		public void SortedListOfIntToStringIsSortedByKey()
		{
			// TODO: ...
			SortedList<int, string> list = new SortedList<int, string>{{0,"C"},{1,"A"},{2,"B"}};
			 
 
			Assert.Equal(3, list.Count);
 
			Assert.Equal("C", list[0]);
			Assert.Equal("A", list[1]);
			Assert.Equal("B", list[2]);
 
			Assert.Equal(0, list.Keys[0]);
			Assert.Equal(1, list.Keys[1]);
			Assert.Equal(2, list.Keys[2]);
 
			Assert.Equal("C", list.Values[0]);
			Assert.Equal("A", list.Values[1]);
			Assert.Equal("B", list.Values[2]);
		}
 
		[Fact]
		public void SortedListOfIntToStringWithCustomComparer()
		{
			// TODO: ...
			SortedList<int, string> list = new SortedList<int, string>(new ReversedComparer()){{0,"C"},{1,"A"},{2,"B"}};
       
			Assert.IsType<ReversedComparer>(list.Comparer);
           
			Assert.Equal(3, list.Count);
       
			Assert.Equal("C", list[0]);
			Assert.Equal("A", list[1]);
			Assert.Equal("B", list[2]);
       
			Assert.Equal(2, list.Keys[0]);
			Assert.Equal(1, list.Keys[1]);
			Assert.Equal(0, list.Keys[2]);
       
			Assert.Equal("B", list.Values[0]);
			Assert.Equal("A", list.Values[1]);
			Assert.Equal("C", list.Values[2]);
		}
	}
}