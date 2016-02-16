using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class mazePrinter
    {

        // seperate method to print a maze
        // Maybe add a method to print either the regular maze or the transposed one.
        // public toString( char Array[] input){
        //    return input;
        //}

        //public void outItGoes(char[,] maze)
        //{
        //    maze.ToString().ForEach(i => Console.WriteLine(i.ToString()));            
        //}

        //public override string ToString(char[,] maze)
        //{
            //foreach(var item in maze)
            //{
            //    Console.Write(maze.ToString);
            //}
        //}

        public void printing(char[,] arr){
        
        //char[,] arr = new char[x,y];

        int rowLength = arr.GetLength(0);
        int colLength = arr.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                Console.Write(string.Format("{0} ", arr[i, j]));
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
        Console.ReadLine();
        }
    }
}
