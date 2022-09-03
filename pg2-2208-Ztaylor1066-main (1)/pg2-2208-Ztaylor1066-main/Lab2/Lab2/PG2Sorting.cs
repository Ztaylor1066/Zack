using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace Lab2
{
    public static class PG2Sorting
    {

        public static List<string> FileReader(string temp)
        {
            //Write a method to read the file and return a list of strings. Open and read the line from 
            //the inputFile.csv file. The line in the file contains a list of comic book titles separated by
            //commas.Split the string and store each title in a List of strings.

            //string file = "inputFile.csv";
            char delim = ',';
            string fileData = File.ReadAllText(temp);
            string[] fData = fileData.Split(delim);
            List<string> title = fData.ToList();

            return title;
        }

        public static List<string> Bubblesort(List<string> sorted)
        {
            List<string> sort = new List<string>(sorted);
            int list = sorted.Count;
            int loopCount = 0;
            bool isSorted;

            do
            {
                isSorted = false;

                for (int i = 1; i <= (list - 1); i++)
                {

                    if (sort[i - 1].CompareTo(sort[i]) == 1)
                    {
                        Swap(sort, i - 1, i);
                        isSorted = true;

                    }
                    loopCount++;
                }
                list -= 1;

            } while (isSorted);

            Console.WriteLine($"\t# of items: {sorted.Count}. Total number of loops: {loopCount}\n\n\n");

            return sort;
        }

        public static List<string> MergeSort(List<string> strings)
        {

            if (strings.Count <= 1)
            {
                return strings;
            }

            List<string> left = new List<string>();
            List<string> right = new List<string>();
            int mid = strings.Count / 2;

            for (int i = 0; i < strings.Count; i++)
            {
                if (i < mid)
                {
                    left.Add(strings[i]);
                }
                else
                {
                    right.Add(strings[i]);
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);


            return Merge(left, right);
        }

        public static List<string> Merge(List<string> left, List<string> right)
        {
            List<string> result = new List<string>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0].CompareTo(right[0]) <= 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }

            return result;
        }

        public static int BinarySearch(List<string> search, string searchTerm, int low, int high, ref int count)
        {

            if (high < low)
            {

                return -1;
            }

            int mid = (low + high) / 2;
            int compare = searchTerm.CompareTo(search[mid]);

            if (compare == -1)
            {
                count++;
                return BinarySearch(search, searchTerm, low, (mid - 1), ref count);
            }
            else if (compare == 1)
            {
                count++;
                return BinarySearch(search, searchTerm, (mid + 1), high, ref count);
            }
            else
                return mid;

        }

        public static void Serializer(List<string> temp, string serial)
        {


            List<string> strings1 = new List<string>(temp);

            serial = Path.ChangeExtension(serial, ".json");
            using (StreamWriter sw = new StreamWriter(serial))
            {
                using (JsonTextWriter jtw = new JsonTextWriter(sw))
                {
                    jtw.Formatting = Formatting.Indented;
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    jsonSerializer.Serialize(jtw, strings1);
                }
            }

        }


        static void Swap(List<string> num, int index1, int index2)
        {
            string temp = num[index1];
            num[index1] = num[index2];
            num[index2] = temp;
        }
    }
}
