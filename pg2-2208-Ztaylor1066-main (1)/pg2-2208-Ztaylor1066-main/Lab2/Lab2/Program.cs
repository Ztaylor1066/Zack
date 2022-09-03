using Newtonsoft.Json;
using PG2Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//dsdusing System;

namespace Lab2
{

    //
    //------------Lab Notes-------------
    //      Add your Sorting and Searching methods to the PG2Sorting.cs file.
    //      Add any other methods in this file.
    //      Add the menu code to the Main method.
    //

    class Program
    {
        static void Main(string[] args)
        {

            string title = "inputFile.csv";
            //List<string> list = PG2Sorting.FileReader(title);


            int menuChoice = 0;
            string[] mainMenu = new string[]
            {
                "1. Bubble Sort",
                "2. Merge Sort",
                "3. Binary Search",
                "4. Save",
                "5. Exit"
            };




            bool choice = true;
            while (menuChoice != mainMenu.Length)
            {
                Console.Clear();
                Input.ReadChoice("Choice? ", mainMenu, out menuChoice);

                switch (menuChoice)
                {

                    case 1:
                        Console.WriteLine($"You Chose: {mainMenu[0]}");
                        Console.Write("\n\n\t=================Comic Titles=============\n\n\n");
                        List<string> temp = PG2Sorting.FileReader(title);
                        List<string> temp2 = PG2Sorting.Bubblesort(temp);

                        for (int i = 0; i < temp.Count; i++)
                        {
                            Console.WriteLine($"{temp[i].PadRight(45)}  {temp2[i].PadRight(80)}");

                        }

                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine($"You Chose: {mainMenu[1]}\n\n");
                        List<string> merger = PG2Sorting.FileReader(title);
                        List<string> merged = PG2Sorting.MergeSort(merger);
                        for (int i = 0; i < merger.Count; i++)
                        {
                            Console.WriteLine($"{merger[i].PadRight(40)} {merged[i].PadLeft(45)}");
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine($"You Chose: {mainMenu[2]}\n\n");

                        List<string> data = PG2Sorting.FileReader(title);
                        data.Sort();
                        int min = 0;
                        int max = data.Count - 1;
                        string searchTerm = "";


                        int count = 0;

                        //int count;



                        for (int i = 0; i < data.Count; i++)
                        {
                            count = 1;
                            searchTerm = data[i];
                            int search = PG2Sorting.BinarySearch(data, searchTerm, min, max, ref count);
                            Console.WriteLine($"{data[i].PadRight(45)} Index:{i}\tIndex found:{search}\t" +
                                                $"Loop count:{count}");
                        }







                        //string searchTitle = string.Empty;
                        //int titleIndex = 0;
                        //int methodCalls = 0;
                        //int index = PG2Sorting.BinarySearch(search, searchTitle, titleIndex, methodCalls);
                        //for (int i = 0; i < bSearch.Count; i++)
                        //{
                        //    Console.WriteLine($"{bSearch[i].PadLeft(40)}\tIndex:{searchTitle}\t" +
                        //        $"Found Index:{titleIndex}\tMethod calls:{methodCalls} ");

                        //}

                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine($"You Chose: {mainMenu[3]}\n\n");

                        List<string> filePath = PG2Sorting.FileReader(title);
                        filePath.Sort();
                        string file = string.Empty;
                        
                        Input.ReadString("Please enter a name for the save file: ", value: ref file);
                        PG2Sorting.Serializer(filePath, file);
                        if (!file.EndsWith(".json"))
                        {
                            file = Path.ChangeExtension(file, ".json");
                        }
                        Console.WriteLine($"The file name {file} was saved successfully.");


                        
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine($"You Chose: {mainMenu[4]}");
                        choice = false;
                        break;

                    default:
                        break;


                }
            }

            Console.WriteLine();
            Console.WriteLine("Hit any key to continue...");

            Console.ReadKey();




        }
    }
}
