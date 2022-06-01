using System;
using System.Collections.Generic;

namespace HashingQuestion_Nainu
{
    class Program
    {
        static void Main(string[] args)
        {
            //int numberOfSlots = 3;
            //List<int> values = new List<int> { 1, 3, 5, 7, 9 };
            //int findItem = 3;

            int numberOfSlots = 5;
            List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int findItem = 7;

            //int numberOfSlots = 5;
            //List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int findItem = 100;

            MySpecialTable table = new MySpecialTable();

            table.create_table(numberOfSlots);

            foreach (int value in values)
            {
                table.add_item(value);
            }

            Console.WriteLine(table.find_item(findItem));

        }
    }

    class MySpecialTable
    {
        Dictionary<int, List<int>> hash = new Dictionary<int, List<int>>();
        public void create_table(int numberOfSlots)
        {
            for (int i = 0; i < numberOfSlots; i++)
            {
                hash.Add(i, new List<int>());
            }
        }

        public int hash_key(int value)
        {
            return value % hash.Count;
        }

        public void add_item(int value)
        {
            hash[hash_key(value)].Add(value);
        }

        public int find_item(int value)
        {
            int key = hash_key(value);
            List<int> values = hash[key];
            if (values.Contains(value))
                return key;

            return -1;
        }
    }
}
