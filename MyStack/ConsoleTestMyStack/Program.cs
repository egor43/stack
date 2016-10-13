using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStack;

namespace ConsoleTestMyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<double> ms = new MyStack<double>();
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            ms.Push(4);
            ms.Push(5);
            ms.Push(6);
            try
            {
                Console.WriteLine(ms.Pop());
                Console.WriteLine(ms.Peek());
                Console.WriteLine(ms.Contains(6));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(ms.Print());
            Console.WriteLine(ms.Length);
            Console.ReadLine();
        }
    }
}
