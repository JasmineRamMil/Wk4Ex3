using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4Ex3
{
    class StringManipulationProgram
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("String Manipulation Program");

                string input = GetValidString(); // Get a valid string input from the user

                while (true)
                {
                    // Display menu options
                    Console.WriteLine("\nChoose an operation:");
                    Console.WriteLine("1. Reverse String");
                    Console.WriteLine("2. Count Vowels");
                    Console.WriteLine("3. Check if Palindrome");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice (1-4): ");
                    string choice = Console.ReadLine();

                    // Perform the selected operation
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Reversed String: {ReverseString(input)}");
                            break;
                        case "2":
                            Console.WriteLine($"Number of Vowels: {CountVowels(input)}");
                            break;
                        case "3":
                            Console.WriteLine(IsPalindrome(input)
                                ? "The string is a Palindrome!"
                                : "The string is NOT a Palindrome.");
                            break;
                        case "4":
                            Console.WriteLine("Exiting program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Please enter a number between 1 and 4.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        // Method to ensure user enters a valid string
        static string GetValidString()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter a string: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input)) // Checks for empty or whitespace input
                    {
                        throw new ArgumentException("Error: Input cannot be empty. Please enter a valid string.");
                    }

                    return input;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        // Method to manually reverse a string (without built-in methods)
        static string ReverseString(string input)
        {
            char[] reversed = new char[input.Length];
            int j = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed[j] = input[i];
                j++;
            }

            string result = "";
            for (int i = 0; i < reversed.Length; i++)
            {
                result += reversed[i]; // Manually concatenate characters
            }

            return result;
        }

        // Method to manually count vowels in a string
        static int CountVowels(string input)
        {
            int count = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (input[i] == vowels[j])
                    {
                        count++;
                        break; // No need to check further if it's a vowel
                    }
                }
            }

            return count;
        }

        // Method to manually check if a string is a palindrome (ignoring spaces and punctuation)
        static bool IsPalindrome(string input)
        {
            // Remove spaces and punctuation manually
            char[] cleanedChars = new char[input.Length];
            int length = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'a' && input[i] <= 'z') ||
                    (input[i] >= 'A' && input[i] <= 'Z') ||
                    (input[i] >= '0' && input[i] <= '9'))
                {
                    // Convert uppercase to lowercase manually
                    cleanedChars[length] = (input[i] >= 'A' && input[i] <= 'Z') ? (char)(input[i] + 32) : input[i];
                    length++;
                }
            }

            // Compare manually without reversing using two pointers
            int left = 0, right = length - 1;

            while (left < right)
            {
                if (cleanedChars[left] != cleanedChars[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }
    }

}
