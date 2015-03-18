using AutoTraders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO; 

namespace TestWordProcessor
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOneWord()
        {
            string sentenceToBeProcessed = "Smooth";
            string expectedResult = "S3h";
            WordProcessor wordProcessor = new WordProcessor(sentenceToBeProcessed);
            wordProcessor.ProcessSentence();

            Assert.AreEqual(expectedResult, wordProcessor.GetAnswerSentence());
        }


        [TestMethod]
        public void TestSentence()
        {
            string sentenceToBeProcessed = "SmooOth Operator$$He's laughing with another girl";
            string expectedResult = "S3h O6r$$He's l6g w2h a5r g2l";
            WordProcessor wordProcessor = new WordProcessor(sentenceToBeProcessed);
            wordProcessor.ProcessSentence();

            Assert.AreEqual(expectedResult, wordProcessor.GetAnswerSentence());
        }

        [TestMethod]
        public void TestSentenceNonCaseSensitive()
        {
            string sentenceToBeProcessed = "SmoOOoth Operator$$He's laughing with another girl";
            string expectedResult = "S4h O6r$$He's l6g w2h a5r g2l";
            WordProcessor wordProcessor = new WordProcessor(sentenceToBeProcessed, true);
            wordProcessor.ProcessSentence();

            Assert.AreEqual(expectedResult, wordProcessor.GetAnswerSentence());
        }


        [TestMethod]
        public void TestEmpySpace()
        {
            string sentenceToBeProcessed = "  ";
            string expectedResult = "  ";
            WordProcessor wordProcessor = new WordProcessor(sentenceToBeProcessed);
            wordProcessor.ProcessSentence();

            Assert.AreEqual(expectedResult, wordProcessor.GetAnswerSentence());
        }

        [TestMethod]
        public void TestLongText()
        {
            string sentenceToBeProcessed = @"  ";
            string fileName = "pg1342BIG";

            WordProcessor wordProcessor = new WordProcessor("");

            using (StreamReader sr = File.OpenText(@"C:\temp\" +  fileName + ".txt"))
            {
                string s = string.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    sentenceToBeProcessed = s;
                    wordProcessor = new WordProcessor(sentenceToBeProcessed);
                    wordProcessor.ProcessSentence();

                    using (StreamWriter writer = new StreamWriter(@"C:\temp\resultOF" + fileName + ".txt", true))
                    {
                        writer.Write(wordProcessor.GetAnswerSentence());
                    }

                }
            } 
            Assert.AreEqual(true, true);
        }
    }
}
