using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] hashSets = new int[1000000][];
            int[][] hashCodeArray = new int[(int.MaxValue - 1) / 77][];
            for (int i = 0; i < 100; i++)
            {
                var latitude = Convert.ToInt32(Console.ReadLine());
                var longitude = Convert.ToInt32(Console.ReadLine());
                VladHashSet<int> vladHashSet = new VladHashSet<int>(latitude, longitude, hashSets, hashCodeArray, i);
                if (vladHashSet.FindHash())
                {
                    Console.WriteLine($"Latitude = {latitude}, longitude = {longitude}");
                }
                else
                {
                    vladHashSet.PushInHashCodeArray();
                }

            }
            Console.ReadKey();
        }
    }
}
