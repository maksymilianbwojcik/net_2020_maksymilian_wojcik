namespace Utils
{
    public class Calculator
    {
        private readonly int _a;
        private readonly int _b;
    
        public Calculator(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int Add()
        {
            return _a + _b;
        }
    
        public int Sub()
        {
            return _a - _b;
        }
    
        public int Mul()
        {
            return _a * _b;
        }
    
        public int Div()
        {
            return _a / _b;
        }
    }
}