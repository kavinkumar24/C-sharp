using System;

namespace task_3{
    public class StringHelper{
        public static void StringMethodsExecution(){
            
            string text = "Hi, we are here to help the c# which is a programming language with object oriented programming and more features.  ";

            
            string subString = text.Substring(0, 2);
            Console.WriteLine($"Substring: {subString}");

            string upperText = text.ToUpper();
            Console.WriteLine($"Uppercase: {upperText}");

            string lowerText = text.ToLower();
            Console.WriteLine($"Lowercase: {lowerText}");

            string trimmedText = text.Trim();
            Console.WriteLine($"Trimmed: {trimmedText}");

            string replacedText = text.Replace("c#", "C-sharp");
            Console.WriteLine($"Replaced: {replacedText}");

            string indexOfText = text.IndexOf("c#").ToString();
            Console.WriteLine($"Index of 'c#': {indexOfText}");

            string containsText = text.Contains("c#").ToString();
            Console.WriteLine($"Contains 'c#': {containsText}");

            string startsWithText = text.StartsWith("Hi").ToString();
            Console.WriteLine($"Starts with 'Hi': {startsWithText}");

            string endsWithText = text.EndsWith("features.").ToString();
            Console.WriteLine($"Ends with 'features.': {endsWithText}");

            string nullCheckText = string.IsNullOrEmpty(text).ToString();
            Console.WriteLine($"Is null or empty: {nullCheckText}");

            string lengthText = text.Length.ToString();
            Console.WriteLine($"Length: {lengthText}");

            string removedText = text.Remove(0, 2);
            Console.WriteLine($"Removed: {removedText}");

            char[] charArray = text.ToCharArray();
            Console.WriteLine("Char array: ");
            foreach (char c in charArray)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

    }
}