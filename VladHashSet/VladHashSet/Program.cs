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
            int[][] HashSets = new int[1000000][];
            int[][] HashCodeArray = new int[(int.MaxValue - 1) / 77][];
            int index = 0;
            for (int i = 0; i < 100; i++)
            {
                var latitude = Convert.ToInt32(Console.ReadLine());
                var longitude = Convert.ToInt32(Console.ReadLine());
                VladHashSet<int> vladHashSet = new VladHashSet<int>(latitude, longitude);
                if (vladHashSet.FindHash(HashCodeArray, HashSets))
                {
                    Console.WriteLine($"Latitude = {latitude}, longitude = {longitude}");
                }
                else
                {
                    (HashSets, HashCodeArray,  index) = vladHashSet.PushInHashCodeArray(HashSets, HashCodeArray,  index);
                }

            }
            Console.ReadKey();
        }
    }
}
