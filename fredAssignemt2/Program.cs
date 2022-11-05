using System.Text;

namespace fredAssignemt2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ShowMenu();
            // int select = GetUserInput();
            // bool input = ValidateInput(select);
            // while (input == false)
            // {
            //     ShowMenu();
            //     select = GetUserInput();
            //     input = ValidateInput(select);
            // }

            //GetStringInput();
            //Console.WriteLine(GetStringInput());

            Console.WriteLine(CompressString("RRZZ"));
        }

        /*
        *start with the menu
        make a list of options that is
        printer out to user.
        make those options selectable by typing
        their number of thier choice.

        make 3 methods 1 for getting user input and 
        show menu and 1 to validate input

        once an option is selected take them to
        that part of the code.
        */

        static void ShowMenu()
        {
            Console.WriteLine("Select One Option");
            Console.WriteLine("1. compress");
            Console.WriteLine("2. decompress");
        }

        static int GetUserInput()
        {
            int select = Int32.Parse(Console.ReadLine());


            return select;
        }

        static bool ValidateInput(int select)
        {
            if (select == 1 || select == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * prompt user asking for a string input in caps
         * then validate that its the correcr form of input
         * if the input os valid then compress the string
         * look for 3 or more of the same letters and 
         * shorten to just the amount of times it occurnes in a row
         * and the letters
         * 
         *  No spaces, punctuation, or other non-letter characters are allowed. 
         * 
         * method for compress and one for string input
         * 1 method to put them together (comply)
         */

        static string GetStringInput()
        {
            Console.WriteLine("Please enter a sentence or string in all caps");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input is not valid please enter new one with No spaces, punctuation, or other non-letter characters.");
                input = Console.ReadLine();
            }
            foreach (char c in input)
            {
                if (Char.IsPunctuation(c))
                {
                    Console.WriteLine("Input is not valid please enter new one with No spaces, punctuation, or other non-letter characters.");
                    input = Console.ReadLine();
                }
                else if (Char.IsLower(c))
                {
                    Console.WriteLine("Input is not valid please enter new one with No spaces, punctuation, or other non-letter characters.");
                    input = Console.ReadLine();
                }
                else if (Char.IsDigit(c))
                {
                    Console.WriteLine("Input is not valid please enter new one with No spaces, punctuation, or other non-letter characters.");
                    input = Console.ReadLine();
                }

            }
            return input;

        }

        static string CompressString(string input)
        {
            char[] chars = input.ToCharArray();
            Dictionary<char, int> result = new Dictionary<char, int>();
            /*
             * loop for a charcaters more than 3x in a row
             * take the number of times its there
             * then store to dictionary along with the character
             * print the number and char from the dictionary
             */

            //for (int i = 0; i < chars.Length; i++)
            //{
            //    if (result.ContainsKey(chars[i]))
            //    {
            //        result[chars[i]] = counter++;
            //    } else
            //    {
            //        result.Add(chars[i], counter);
            //    }
            //}

            //UUURRPPTYUIOOOPMMMM

            var count = 1;
            

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    count++;
                    if (count > 2)
                    {
                        result.Add(chars[i], count);
                    }
                }
                else
                {
                    count = 1;
                    result.Add(chars[i], count);
                }
               
            }

            //"3URRPPTYUI3OP4M"

            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<char, int> pair in result)
            {

                if(pair.Value > 2)
                {
                    stringBuilder.Append(pair.Value);
                    stringBuilder.Append(pair.Key);
                }
                else
                {
                    stringBuilder.Append(pair.Key);
                }
            }
            return stringBuilder.ToString();
        }

    }
}