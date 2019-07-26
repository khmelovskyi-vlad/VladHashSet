using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladHashSet
{
    class VladHashSet<TElement>
    {
        public VladHashSet(TElement latitude, TElement longitude, TElement[][] hashSets, int[][] hashCodeArray, int index)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.HashSets = hashSets;
            this.HashCodeArray = hashCodeArray;
            this.Index = index;
            hashCode = GetHashCodes();
            ArrayWithCoordinate = new TElement[2];
            ArrayWithHashCode = new int[77];
        }
        public TElement Latitude { get; set; }
        public TElement Longitude { get; set; }
        public TElement[][] HashSets { get; set; }
        public int[][] HashCodeArray { get; set; }
        public int Index { get; set; }
        int hashCode;
        public TElement[] ArrayWithCoordinate { get; set; }
        public int[] ArrayWithHashCode { get; set; }
        public int GetHashCodes()
        {
            return (int)( Convert.ToInt32(Latitude) + Convert.ToInt32(Longitude));
        }
        public bool FindHash()
        {
            for (int i = 0; i < 77; i++)
            {
                try
                {
                    if (hashCode == HashCodeArray[(int)hashCode / 77][i])
                    {
                        if (Show())
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
        public void PushInHashCodeArray()
        {
            ArrayWithCoordinate[0] = Latitude;
            ArrayWithCoordinate[1] = Longitude;
            HashSets[Index] = ArrayWithCoordinate;
            ArrayWithHashCode[hashCode - (int)(hashCode / 77) * 77] = hashCode;
            try
            {
                HashCodeArray[(int)(hashCode / 77)][hashCode - (int)(hashCode / 77) * 77] = hashCode;
            }
            catch (NullReferenceException)
            {
                HashCodeArray[(int)(hashCode / 77 )] = ArrayWithHashCode;
            }
            Console.WriteLine(hashCode);
        }
        public bool Show()
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
