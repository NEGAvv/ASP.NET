using myApp.Interfaces;

namespace myApp.Classes
{
    public class CalcService : ICalcService
    {
        public float Add(float a, float b) => a + b;

        public float Subtract(float a, float b) => a - b;

        public float Multiply(float a, float b) => a * b;

        public float Divide(float a, float b)
        {
            if (b == 0)
                throw new DivideByZeroException("You cannot divide by zero");
            return (float)a / b;
        }
    }
}

