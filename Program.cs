using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze m = new Maze();
            m.ArrayLoad();
            m.SearchEnd();
            m.print();


        }
    }
}
