
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Maze : FileLoad
    {
        int[,] map;

        RowAndCol rc = new RowAndCol();
        RowAndCol end = new RowAndCol();
        Stack<RowAndCol> branch = new Stack<RowAndCol>();
        /*
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
        }*/
        public void ArrayLoad()
        {
            map = new int[5, 8]
            { { 1, 0, 0, 0, 0, 1, 1, 1}, { 0, 0, 1, 1, 1, 1, 1, 1}, { 1, 0, 0, 0, 1, 0, 0, 0}, { 1, 1, 1, 0, 0,0 ,1 , 1}, { 1, 1, 1, 1, 1, 1, 1, 1 } };
            
            for(int i =0; i<map.GetLength(0); i++)
            {
                for(int j=0; j<map.GetLength(1); j++)
                {
                    if (map[i, 0] == 0)
                    {
                        rc.row = j;
                        rc.col = i;
                        map[i, j] = 5;
                        branch.Push(rc);
                    }
                    if(map[i, map.GetLength(1) - 1] == 0)
                    {
                        end.row = map.GetLength(1)-1;
                        end.col = i;
                        map[i, map.GetLength(1)-1] = 9;
                    }
                }
            }
            Console.WriteLine("{0}, {1}", branch.Peek().row, branch.Peek().col);
           /* SearchHeightAndWidth(message);

            StreamReader mazeread = new StreamReader(message);
            int temp;
            map = new int[height, width];
            string path = mazeread.ReadToEnd();

            string[] array = path.Split(' ');

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    temp = int.Parse(array[i + j]);
                    map[i, j] = temp;
                    Console.Write("{0} ", map[i, j]);
                }
                Console.WriteLine();
            }*/
        }
        public void print()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 0)
                        Console.Write("  "); //길
                    if (map[i, j] == 1)
                        Console.Write("■"); //벽
                    if (map[i, j] == 3)
                        Console.Write("XX"); //잘못된 길
                    if (map[i, j] == 7)
                        Console.Write("□"); //지나온 길
                    if (map[i, j] == 5)
                        Console.Write("→"); //입구
                    if (map[i, j] == 9)
                        Console.Write("◎"); //출구
                    if (map[i, j] == 8)
                        Console.Write("∵"); //분기점
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool IsLoad(int r, int c)
        {
            if (r < 0 || c < 0 || r >= map.GetLength(1) || c >= map.GetLength(0))
                return false;
            else
                return (map[c, r] == 0 || map[c, r] == 9);
        }
        public void SearchEnd()
        {
            while (branch.Count > 0)
            {

                print();

                Console.WriteLine("==================================");
                rc = branch.Peek();
                int r = rc.row;
                int c = rc.col;

                map[c, r] = 7;
                if (r == end.row && c == end.col)
                    return;
                else
                {
                    if (IsLoad(r + 1, c))
                    {
                        rc.row++;
                        branch.Push(rc);
                    }
                    else if (IsLoad(r, c + 1))
                    {
                        rc.col++;
                        branch.Push(rc);
                    }
                    else if (IsLoad(r, c - 1))
                    {
                        rc.col--;
                        branch.Push(rc);
                    }
                    else if (IsLoad(r - 1, c))
                    {
                        rc.row--;
                        branch.Push(rc);
                    }
                    else
                    {
                        map[c, r] = 3;
                        branch.Pop();
                    }
                }
            }
            while (branch.Count > 0)
                branch.Pop();
        }
    }
}