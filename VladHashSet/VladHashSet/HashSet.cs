﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladHashSet
{
    class HashSet<TElement>
    {
        public HashSet()
        {
            hashSet = new List<HashBox>[uint.MaxValue / maxUIntDivider];
        }
        private List<HashBox>[] hashSet;
        const int maxUIntDivider = 65537;
        HashBox hashBox;
        int indexList;

        public void Add(TElement value)
        {
            NewHashBoxAndIndexList(value);
            if (hashSet[indexList] == null)
            {
                hashSet[indexList] = new List<HashBox>();
                hashSet[indexList].Add(hashBox);
            }
            else
            {
                foreach(var existedHashBox in hashSet[indexList])
                {
                    if(existedHashBox.HashCode == hashBox.HashCode && existedHashBox.Value.Equals(hashBox.Value))
                    {
                        return;
                    }
                }
                hashSet[indexList].Add(hashBox);
            }
        }
        public bool Contains(TElement value)
        {
            NewHashBoxAndIndexList(value);
            if (hashSet[indexList] == null)
            {
                return false;
            }
            foreach (var existedHashBox in hashSet[indexList])
            {
                if (existedHashBox.HashCode == hashBox.HashCode && existedHashBox.Value.Equals(hashBox.Value))
                {
                    return true;
                }
            }
            return false;
        }
        public void Remove(TElement value)
        {
            NewHashBoxAndIndexList(value);
            if (hashSet[indexList] == null)
            {
                return;
            }
            foreach (var existedHashBox in hashSet[indexList])
            {
                if (existedHashBox.HashCode == hashBox.HashCode && existedHashBox.Value.Equals(hashBox.Value))
                {
                    hashSet[indexList].Remove(existedHashBox);
                    return;
                }
            }
        }
        private void NewHashBoxAndIndexList(TElement value)
        {
            hashBox = new HashBox(value, value.GetHashCode());
            indexList = value.GetHashCode() / maxUIntDivider;
        }

        private struct HashBox
        {
            public TElement Value;
            public int HashCode;
            public HashBox(TElement value, int hashCode)
            {
                Value = value;
                HashCode = hashCode;
            }
        }
    }
}
