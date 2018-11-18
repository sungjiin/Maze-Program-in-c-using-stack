using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class FileLoad :HeightAndWidth
    {
        public void SearchHeightAndWidth(string message)
        {
            StreamReader sr = new StreamReader(message);
            string path = sr.ReadToEnd();
            int one = path.Length - path.Replace("1", "").Length;
            int zero = path.Length - path.Replace("0", "").Length;
            char c = '\n';
            string[] path2 = path.Split(c);
            height = path2.Length;
            width = (one + zero) / path2.Length;

        }
        public void FileL(string message)
        {
            SearchHeightAndWidth(message);
            StreamReader mazeread = new StreamReader(message);
            int[,] map = new int[height, width];
            string line;
            string[] array = new string[height];
            int s = 0;
            while ((line = mazeread.ReadLine()) != null)
            {
                array[s] = line;
                Console.WriteLine(array[s]);
                s++;
            }
        }
    }
}