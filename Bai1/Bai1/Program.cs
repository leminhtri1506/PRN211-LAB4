using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4
{
    public delegate void SampleDelegate(int a, int b);
    class MathOperations
    {
        public void Add(int a, int b)
        {
            Console.WriteLine("Add result : {0}", a + b);
        }
        public void Subtract(int x, int y)
        {
            Console.WriteLine("Subtract result : {0}", x - y);
        }
        public void Multiply(int x, int y)
        {
            Console.WriteLine("Multiply result : {0}", x * y);
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("**Delegate Example**");
        MathOperations m = new MathOperations();
        SampleDelegate dlgt = m.Add;
        dlgt += m.Subtract;
        dlgt += m.Multiply;
        dlgt(10, 90);
        Console.ReadLine();
    }
}