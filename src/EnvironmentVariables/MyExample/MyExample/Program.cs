using System;

namespace MyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string myVariableValue = Environment.GetEnvironmentVariable("MyCustomVariable");
            Console.WriteLine(myVariableValue);
        }
    }
}
