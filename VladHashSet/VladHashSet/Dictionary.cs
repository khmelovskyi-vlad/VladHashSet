//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VladHashSet
//{
//    class Dictionary<TElement>
//    {
//        public Dictionary(TElement latitude, TElement longitude)
//        {
//            this.Latitude = latitude;
//            this.Longitude = longitude;
//            HashSets = new TElement[1000000][];
//            HashKey = new TElement[int.MaxValue - 1];
//            HashCodeArray = new int[(int.MaxValue - 1) / 77][];
//        }
//        public TElement Latitude { get; set; }
//        public TElement Longitude { get; set; }
//        public TElement Key { get; set; }
//        public TElement[][] HashSets;
//        public TElement[] HashKey;
//        public int[][] HashCodeArray;
//        public int index;
//        public int GetHashCodes()
//        {
//            return (int)((Convert.ToInt32(Latitude) * Convert.ToInt32(Longitude)) / (Convert.ToInt32(Latitude) + Convert.ToInt32(Longitude)));
//        }
//        public void PushInHashCodeArray()
//        {
//            var hashCode = GetHashCodes();
//            HashCodeArray[(int)hashCode / 77][hashCode - (int)(hashCode / 77) * 77 - 1] = hashCode;
//            HashSets[index][0] = Latitude;
//            HashSets[index][1] = Longitude;
//            HashKey[index] = Key;
//        }
//        public bool FindHash()
//        {
//            var hashCode = GetHashCodes();
//            for (int i = 0; i < 77; i++)
//            {
//                if (hashCode == HashCodeArray[(int)hashCode / 77][i])
//                {
//                    return true;
//                }
//            }
//            return false;
//        }
//        public (TElement Key, TElement Latitude, TElement Longitude) Show()
//        {
//            var i = 0;
//            while (true)
//            {
//                if (HashSets[i][0] == Latitude && HashSets[i][0] == Longitude)
//                {
//                    return (HashKey[i], Latitude, Longitude);
//                }
//            }
//        }
//    }
//}
