using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.CompilerServices;
using PG2Input;

namespace Lab1
{

    //
    //------------Lab Notes-------------
    //      Add your Read methods to the Input.cs file in the PG2Input project.
    //      Add any other methods in this file.
    //      Add the menu code to the Main method.
    //

    class Program
    {
        static void Main(string[] args)
        {


            //while not exit, continue selecting. Call read choice to show the menu
            //and get selection. Use switch statements.
            int menuChoice = 0;
            string[] mainMenu = new string[]
            {
                "1. The Speech",
                "2. List of Words",
                "3. Show Histogram",
                "4. Search for Word",
                "5. Remove Word",
                "6. Exit"
            };
            //GetSpeech();


            char[] delims = new char[] { ' ', ',', '.', '!', ':', ';' };
            List<string> word = Splitter(GetSpeech(), delims);

            Dictionary<string, int> counts = SpeechCounts(word);

            char[] chars = new char[] { '.', '!' };
            List<string> splitSent = Splitter(GetSpeech(), chars);






            bool choice = true;
            while (menuChoice != mainMenu.Length)
            {
                Console.Clear();
                Input.ReadChoice("Choice? ", mainMenu, out menuChoice);

                switch (menuChoice)
                {

                    case 1:
                        Console.WriteLine($"You Chose: {mainMenu[0]}");
                        Console.Clear();
                        Console.WriteLine(GetSpeech());
                        break;

                    case 2:
                        Console.WriteLine($"You Chose: {mainMenu[1]}");
                        Console.Clear();
                        for (int i = 0; i < word.Count; i++)
                        {
                            Console.WriteLine(word[i]);
                        }
                        break;

                    case 3:
                        Console.WriteLine($"You Chose: {mainMenu[2]}");
                        Console.Clear();

                        foreach (KeyValuePair<string, int> Valley in counts)
                        {
                            PrintKeyValueBar(Valley.Key, Valley.Value);
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine($"You Chose: {mainMenu[3]}");

                        //Console.Write("Enter word to search?");
                        string words = string.Empty;
                        Input.ReadString("Search word to find? ", ref words);

                        bool found = counts.TryGetValue(words, out int count);
                        if (found)
                        {
                            PrintKeyValueBar(words, count);
                            foreach (string s in splitSent)
                            {
                                string[] temp = s.Split(' ', ',', '.', '!', ':', ';');
                                foreach (string s2 in temp)
                                {
                                    if (s2 == words.ToLower())
                                    {

                                        Console.WriteLine(s.PadLeft(1));
                                        break;
                                    }
                                }
                            }
                        }

                        else
                            Console.WriteLine($"{words} is not available");



                        break;
                    case 5:
                        Console.WriteLine($"You Chose: {mainMenu[4]}");
                        //Console.Write("Enter a word to remove: ");
                        string remove = string.Empty;
                        Input.ReadString("Search word to find? ", ref remove);

                        bool found2 = counts.Remove(remove);
                        if (found2)
                            Console.WriteLine($"{remove} was removed");
                        else
                            Console.WriteLine($"{remove} was not found");
                        break;
                    case 6:
                        Console.WriteLine($"You Chose: {mainMenu[5]}");
                        choice = false;
                        break;

                    default:
                        break;

                }

                Console.WriteLine();
                Console.WriteLine("Hit any key to continue...");

                Console.ReadKey();
            }

             #region MyMethods//get speech
            static string GetSpeech()
            {

                string text = "I say to you today, my friends, so even though we face the difficulties of today and tomorrow, I still have a dream. It is a dream deeply rooted in the American dream. " +
                    "I have a dream that one day this nation will rise up and live out the true meaning of its creed: We hold these truths to be self-evident: that all men are created equal. " +
                    "I have a dream that one day on the red hills of Georgia the sons of former slaves and the sons of former slave owners will be able to sit down together at the table of brotherhood. " +
                    "I have a dream that one day even the state of Mississippi, a state sweltering with the heat of injustice, sweltering with the heat of oppression, will be transformed into an oasis of freedom and justice. " +
                    "I have a dream that my four little children will one day live in a nation where they will not be judged by the color of their skin but by the content of their character. " +
                    "I have a dream today. I have a dream that one day, down in Alabama, with its vicious racists, with its governor having his lips dripping with the words of interposition and nullification; one day right there in Alabama, little black boys and black girls will be able to join hands with little white boys and white girls as sisters and brothers. " +
                    "I have a dream today. I have a dream that one day every valley shall be exalted, every hill and mountain shall be made low, the rough places will be made plain, and the crooked places will be made straight, and the glory of the Lord shall be revealed, and all flesh shall see it together. " +
                    "This is our hope. This is the faith that I go back to the South with. With this faith we will be able to hew out of the mountain of despair a stone of hope. With this faith we will be able to transform the jangling discords of our nation into a beautiful symphony of brotherhood. " +
                    "With this faith we will be able to work together, to pray together, to struggle together, to go to jail together, to stand up for freedom together, knowing that we will be free one day. " +
                    "This will be the day when all of God's children will be able to sing with a new meaning, My country, 'tis of thee, sweet land of liberty, of thee I sing. Land where my fathers died, land of the pilgrim's pride, from every mountainside, let freedom ring. " +
                    "And if America is to be a great nation this must become true. So let freedom ring from the prodigious hilltops of New Hampshire. Let freedom ring from the mighty mountains of New York. Let freedom ring from the heightening Alleghenies of Pennsylvania! " +
                    "Let freedom ring from the snowcapped Rockies of Colorado! Let freedom ring from the curvaceous slopes of California! But not only that; let freedom ring from Stone Mountain of Georgia! " +
                    "Let freedom ring from Lookout Mountain of Tennessee! Let freedom ring from every hill and molehill of Mississippi. From every mountainside, let freedom ring. " +
                    "And when this happens, when we allow freedom to ring, when we let it ring from every village and every hamlet, from every state and every city, we will be able to speed up that day when all of God's children, black men and white men, Jews and Gentiles, Protestants and Catholics, will be able to join hands and sing in the words of the old Negro spiritual, Free at last! free at last! thank God Almighty, we are free at last!";

                return text.ToLower();
            }
           
            static List<string> Splitter(string split, Char[] delim)
            {


                string[] words = split.Split(delim, StringSplitOptions.RemoveEmptyEntries);

                //convert array of words to a list of strings and return the list
                List<string> word = new List<string>(words);

                return word;
            }
            static Dictionary<string, int> SpeechCounts(List<string> words)
            {//use list of words from speech, create a dictionary and claculate the counts
             //for each word. return the dictionary.

                Dictionary<string, int> counts = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
                foreach (string word in words)
                {
                    if (counts.ContainsKey(word))
                        counts[word]++;
                    else
                        counts.Add(word, 1);
                }
                return counts;
            }
            static void PrintKeyValueBar(string word, int count)
            {
                Console.Write(word.PadLeft(13) + " ");
                for (int i = 0; i < count; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                Console.WriteLine(count);
                Console.ResetColor();
            }
            static void splitSentence(List<string> strings)
            {
                Console.WriteLine($"{strings}");
                foreach (string sent in strings)
                {
                    Console.Write($"{sent}");
                }
            }

            #endregion
        }



    }
}
