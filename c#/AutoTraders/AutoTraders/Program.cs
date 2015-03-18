using System;

namespace AutoTraders
{
    /// <summary>
    /// The Problem: PP 1.4: In the programming language of your choice, write a 
    /// program that parses a sentence and replaces each word with the following:
    /// first letter, number of distinct characters between first and last character, and last letter.  
    /// For example, Smooth would become S3h.  Words are separated by spaces or non-alphabetic characters and 
    /// these separators should be maintained in their original form and location in the answer.
    /// 
    /// The Solution:
    /// -Created WordProcessor class to do all the work about the problem
    /// -Created test project for testing the algorithm
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the sentence to be processed then press ENTER/RETURN key");

            string sentence = Console.ReadLine();
             
            Console.WriteLine("Processed sentence : ");
            WordProcessor wordProcessor = new WordProcessor(sentence);
            wordProcessor.ProcessSentence();
            Console.WriteLine(wordProcessor.GetAnswerSentence());

            Console.ReadKey();
        }

      
    }
}
