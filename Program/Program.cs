using System;
using System.Configuration;
using System.IO;
using System.Text;
using Text;
using Text.TextUnits;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = ConfigurationManager.AppSettings["filePath"];

            string writePath = ConfigurationManager.AppSettings["writePath"];

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadToEnd();

                    StringBuilder f = new StringBuilder(line, 1000);

                    Parser parser = new Parser();

                    Texts text = parser.Parse(f);

                    Console.WriteLine(f);

                    Console.WriteLine("----------Sentences ordered by the number of words------------\n\n");

                    foreach (var item in text.GetListOfSentByNumOfWord())
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("---------Words by length from interrogative sentence-----------\n\n");

                    foreach (var item in text.GetListWordsInSent(2, TypeSent.Interrogative))
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("\n\n");

                    Console.WriteLine("------------Delete words starts with consonants--------------\n\n");

                    text.DelWordsWithConsonants(3);

                    Console.WriteLine(text);

                    Console.WriteLine("------------------Replace word in sentence-------------------\n\n");

                    text.ReplacementWordsInSent(1, 3, "It's a substring");

                    Console.WriteLine(text);

                    using (StreamWriter sw = new StreamWriter(writePath))

                    { sw.WriteLine(f); }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e);
            }

            Console.ReadKey();
        }

    }
}

