using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG2Input
{
    public static class Input
    {
        
        //readinteger class
        public static int ReadInteger(string prompt, int min, int max)
        {
            Console.WriteLine(prompt);
            string entered = Console.ReadLine();
            int number;
            bool isANumber = int.TryParse(entered, out number);
            
            while (!isANumber && number < min || number > max)
            {
                Console.WriteLine("That is not an option. Try again");
                

                break;
            }
            
            return number;
        }
        //readstring class
        public static void ReadString(string prompt, ref string value)
        {
            
            Console.WriteLine(prompt);

             
            string temp = Console.ReadLine();
            while (true)
            {
                if (String.IsNullOrWhiteSpace(temp))
                {
                    Console.WriteLine("That's wrong, do it again");
                    temp = Console.ReadLine();  
                }
               else
                {
                    break;
                }
            }
            
            value = temp;

        }
        //readchoice class
        public static void ReadChoice(string prompt, string[] options, out int selection)
        {
            Console.WriteLine("Menu");
            for (int ndx = 0; ndx < options.Length; ndx++)
            {
                Console.WriteLine(options[ndx]);
            }
            Console.WriteLine();
            selection = ReadInteger(prompt, 1, options.Length);




        }
    }
}
