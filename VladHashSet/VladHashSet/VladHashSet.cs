using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladHashSet
{
    class VladHashSet<TElement>
    {
        public VladHashSet(TElement latitude, TElement longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            hashCode = GetHashCodes();
            ArrayWithCoordinate = new TElement[2];
            ArrayWithHashCode = new int[77];
        }
        public TElement Latitude { get; set; }
        public TElement Longitude { get; set; }
        int hashCode;
        public TElement[] ArrayWithCoordinate { get; set; }
        public int[] ArrayWithHashCode { get; set; }
        public int GetHashCodes()
        {
            return (int)( Convert.ToInt32(Latitude) + Convert.ToInt32(Longitude));
        }
        public bool FindHash(int[][] HashCodeArray, TElement[][] HashSets)
        {
            for (int i = 0; i < 77; i++)
            {
                try
                {
                    if (hashCode == HashCodeArray[(int)hashCode / 77][i])
                    {
                        if (Show(HashSets))
                        {
                            return true;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
            return false;
        }
        public (TElement[][] HashSets, int[][] HashCodeArray,  int index) PushInHashCodeArray(TElement[][] HashSets, int[][] HashCodeArray,  int index)
        {
            ArrayWithCoordinate[0] = Latitude;
            ArrayWithCoordinate[1] = Longitude;
            HashSets[index] = ArrayWithCoordinate;
            ArrayWithHashCode[hashCode - (int)(hashCode / 77) * 77] = hashCode;
            try
            {
                HashCodeArray[(int)(hashCode / 77)][hashCode - (int)(hashCode / 77) * 77] = hashCode;
            }
            catch (NullReferenceException)
            {
                HashCodeArray[(int)(hashCode / 77 )] = ArrayWithHashCode;
            }
            index++;
            Console.WriteLine(hashCode);
            return (HashSets, HashCodeArray, index);
        }
        public bool Show(TElement[][] HashSets)
        {
            var i = 0;
            while (true)
            {
                try
                {
                    if (HashSets[i][0].ToString()  == Latitude.ToString() && HashSets[i][1].ToString() == Longitude.ToString())
                    {
                        return true;
                    }
                }
                catch (NullReferenceException)
                {
                    return false;
                }
                i++;
            }
        }
    }
}
