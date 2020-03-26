using System;
using System.Collections.Generic;
using System.Text;

namespace Palindrome
{
    class Palindrome
    {
        public bool FillStackQueue(string TestString)
        {
            // Letter to add to stack and queue.
            char letter;
            // Does what it says on the tin.
            bool isPalindrome;

            // Stack and queue for the letters in each sentence.
            Stack<char> StackChar = new Stack<char>();
            Queue<char> QueueChar = new Queue<char>();

            // Only adds letters to the stack and queue, and lowers them to prevent any diferences between caps and lowercase.
            for (int i = 0; i < TestString.Length; i++)
            {
                if (Char.IsLetter(TestString[i]))
                {
                    letter = TestString[i];
                    letter = char.ToLower(letter);
                    StackChar.Push(letter);
                    QueueChar.Enqueue(letter);
                }
            }

            
            isPalindrome = IsPalindrome(StackChar, QueueChar);

            return isPalindrome;
        }

        // Function for testing if it is a palindrome, going through the stack and queue one by one and seeing if the result is the same, if at any point it isn't then it's not a palindrome.
        private bool IsPalindrome(Stack<char> StackChar, Queue<char> QueueChar)
        {
            for (int i = 0; i < StackChar.Count; i++)
            {
                char StackLetter = StackChar.Pop();
                char QueueLetter = QueueChar.Dequeue();

                if (StackLetter != QueueLetter)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
