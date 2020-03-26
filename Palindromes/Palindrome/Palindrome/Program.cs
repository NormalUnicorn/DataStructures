using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPalindrome;
            Palindrome palindrome = new Palindrome();

            string line;

            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-a-text-file-one-line-at-a-time
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"E:\Downloads\Uni\palindromes.txt");

            while ((line = file.ReadLine()) != null)
            {
                isPalindrome = palindrome.FillStackQueue(line);
                if (isPalindrome)
                {
                    Console.WriteLine(line + " is a palindrome!");
                }
                else
                {
                    Console.WriteLine(line + " is not a palindrome!");
                }
               
            }

            file.Close();
        }
    }
}
