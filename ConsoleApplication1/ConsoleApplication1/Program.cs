using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();
            s.Push(4);
            s.Push(5);
            s.Push(4);
            s.Pop();
            Console.Write(s.Peek());
            Console.ReadKey();
        }
    }
    
}
