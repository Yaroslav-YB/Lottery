using System;

namespace Lottery_demo
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please type your ticket number and press \'Enter\'");
            string inputString = Console.ReadLine();
            bool result = Lottery.CheckTicketNumber(inputString);
            
            if(result)
            {  
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Lucky ticket!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }
            Console.WriteLine();
            Console.WriteLine();

            Main();
        }
    }

    static class Lottery
    {
        // private static bool inputIsNumber; //determines if inputString is a number
        private static int firstHalf;
        private static int secondHalf;

        public static bool CheckTicketNumber(string inputString)
        {
            if(!ValidateInputString(inputString)) return false;

            ProcessString(inputString); //split inputString on two numbers

            return ValidateNumber();
        }

        private static bool ValidateInputString(string inputString)
        {
            if(inputString.Length < 4 || inputString.Length > 8)
            {
                return false;
            }

            bool isNumber = Int32.TryParse(inputString, out int parsedNumber);

            if(!isNumber)
            {
                return false;
            }

            if(parsedNumber <= 0)
            {
                return false;
            }
            
            return true;
        }

        private static void ProcessString(string inputString)
        {
            if((inputString.Length%2) == 1)
            {
                inputString = String.Concat("0",inputString);
            }
            int halfStringLength = inputString.Length/2;

            firstHalf = Int32.Parse(inputString.Substring(0,halfStringLength));
            secondHalf = Int32.Parse(inputString.Substring(halfStringLength));
        }

        private static bool ValidateNumber()
        {
            if(GetSumOfDigits(firstHalf) == GetSumOfDigits(secondHalf)) return true;

            return false;
        }

        private static int GetSumOfDigits(int number)
        {
            if(number == 0) return 0;
            return number % 10 + GetSumOfDigits(number / 10);
        }
    }
}
