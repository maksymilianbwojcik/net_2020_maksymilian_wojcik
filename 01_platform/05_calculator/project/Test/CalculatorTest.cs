using Xunit;
using Utils;

namespace Test
{
	public class CalculatorTest
	{
		[Fact]
		public void Adding()
		{
			var calculator = new Calculator(2,3);
			Assert.Equal(2+3, calculator.Add());
		}
		
		[Fact]
		public void Subtracting()
		{
			var calculator = new Calculator(2,3);
			Assert.Equal(2-3, calculator.Sub());
		}
		
		[Fact]
		public void Multiplying()
		{
			var calculator = new Calculator(2,3);
			Assert.Equal(2*3, calculator.Mul());
		}
		
		[Fact]
		public void Dividing()
		{
			var calculator = new Calculator(6,3);
			Assert.Equal(6/3, calculator.Div());
		}
	}
}