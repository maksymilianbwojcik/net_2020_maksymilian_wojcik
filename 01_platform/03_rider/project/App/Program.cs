using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main(string[] args)
        {
            var argument1 = int.Parse(args[0], NumberStyles.Integer, CultureInfo.InvariantCulture);
            var argument2 = int.Parse(args[2], NumberStyles.Integer, CultureInfo.InvariantCulture);

	        var calculator = new Calculator(argument1, argument2);
            var sum = calculator.Add();
            
            switch (args[1])
            {
                case "add":
                    Console.WriteLine($"{argument1} add {argument2} = {sum}");
                    break;
                case "sub":
                    Console.WriteLine($"{argument1} sub {argument2} = {calculator.Sub()}");
                    break;
                case "mul":
                    Console.WriteLine($"{argument1} mul {argument2} = {calculator.Mul()}");
                    break;
                case "div":
                    Console.WriteLine($"{argument1} div {argument2} = {calculator.Div()}");
                    break;
                default:
                    Console.WriteLine("\nsmth went wrong\n");
                    break;
            }
            
        }
    }
}
