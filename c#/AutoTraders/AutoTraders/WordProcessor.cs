using System.Collections.Generic;
using System.Text;

namespace AutoTraders
{
    /// <summary>
    /// Contains algorithm that that parses a sentence and replaces each word with the following:
    /// first letter, number of distinct characters between first and last character, and last letter.  
    /// For example, Smooth would become S3h.  Words are separated by spaces or non-alphabetic characters and 
    /// these separators are maintained in their original form and location in the answer. 
    /// </summary>
    public class WordProcessor
    {
        //Alpha characters, any character not in this string is considered as delimiters
        public readonly string alphabeticChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string sentence;
        private string answerString;

        private bool isCaseSensitive = false;

        public string Sentence
        {
            get { return sentence; }
            set { sentence = value; }
        }
        
        /// <summary>
        /// Default constructor will create word processor
        /// </summary>
        /// <param name="sentence"></param>
        public WordProcessor(string sentence)
        {
            this.sentence = sentence;
        }

        /// <summary>
        /// The class by default, is not case sensitive
        /// This constructor can be used to cread non case sensitive results
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="isCaseSensitive"></param>
        public WordProcessor(string sentence, bool isCaseSensitive)
        {
            this.sentence = sentence;
            this.isCaseSensitive = isCaseSensitive;
        }

        public string GetAnswerSentence()
        {
            return answerString;
        }

        /// <summary>
        /// Parse sentences into words
        /// </summary>
        /// <returns></returns>
        public void ProcessSentence()
        {
            StringBuilder stringToConcat = new StringBuilder();

            string word = string.Empty;
            string wordToBeProcessed = string.Empty;
            string finalWord = string.Empty;

            for (int i = 0; i <= sentence.Length; i++)
            {
                //i == sentence.Length is for end of the sentence, end of sentence can end with an alphabetic character
                if (i == sentence.Length || alphabeticChars.IndexOf(sentence[i]) < 0)
                {
                    //only words that are longer than 2 chars are eligible for the algorithm
                    if (word.Length > 2)
                    {
                        wordToBeProcessed = word.Substring(1, word.Length - 2);

                        //first letter, number of distinct characters between first and last character, and last letter.
                        finalWord = word[0] + NumberOfDistinct(wordToBeProcessed).ToString() + word[word.Length - 1];
                        wordToBeProcessed = string.Empty;
                    }
                    else
                        finalWord = word;

                    word = string.Empty;

                    stringToConcat.Append(finalWord);

                    //Adding non-alpha chars in result
                    if (i != sentence.Length)
                        stringToConcat.Append(sentence[i]);

                    finalWord = string.Empty;
                }
                else
                {
                    //Building the word to be processed
                    word +=  sentence[i];
                }
            }
            answerString = stringToConcat.ToString();
        }

        /// <summary>
        /// This will return number of unique characters of a given string
        /// </summary>
        /// <param name="word">String to be processed</param>
        /// <returns>Returns count of characters of the list</returns>
        public int NumberOfDistinct(string word)
        {
            //if it's case sensitive we convert all the characters into same case, lower case
            //This also could be upper case
            if (!isCaseSensitive)
                word = word.ToLower();

            //List will only contain unique characters
            List<string> uniqueCharacters = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                //Only add characters if it's not in the list
                if (!uniqueCharacters.Contains(word[i].ToString()))
                    uniqueCharacters.Add(word[i].ToString());
            }

            return uniqueCharacters.Count;
        }
    }
}
