using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Text.Constants;
using Text.Interface;

namespace Text.TextUnits
{
    public class Texts
    {
        List<Sentence> sentences = new List<Sentence>();

        public Texts()
        {
        }

        public Texts(List<Sentence> sentences)
        {
            this.sentences = sentences;
        }

        public ReadOnlyCollection<Sentence> Sentences
        {
            get
            {
                return new ReadOnlyCollection<Sentence>(sentences);
            }
        }

        public List<Sentence> GetListOfSentByNumOfWord()
        {
            List<Sentence> sent = new List<Sentence>();

            return sent = sentences.OrderBy(x => x.NumberOfWords).Select(x => x).ToList();
        }

        public List<ITextItem> GetListWordsInSent(int numOfLetter, TypeSent type)
        {
            IEnumerable<ITextItem> buffOfSymbols = new List<ITextItem>();

            foreach (var item in sentences)
            {
                if (item.TypeOfSentence == type)
                {
                    foreach (var item2 in item.ElementsOfText)
                    {
                        buffOfSymbols = buffOfSymbols.Concat(item.ElementsOfText
                               .Where(x => x is Word && x.Lenght == numOfLetter)
                               .Select(x => x));
                    }
                }

            }

            return buffOfSymbols.Distinct().ToList();
        }
        
        public void DelWordsWithConsonants(int numOfLetter)
        {
            foreach (var item in sentences)
            {
                for (int i = 0; i < item.ElementsOfText.Count; i++)
                {
                    if (item.ElementsOfText[i] is Word && item.ElementsOfText[i].Lenght == numOfLetter
                        && Letters.Consonants.Contains(item.ElementsOfText[i].ToString()[0].ToString()))
                    {
                        item.Remove(i);
                    }
                }
            }
        }

        public void ReplacementWordsInSent(int numOfSent, int lenghtWord, string str)
        {
            if (numOfSent > sentences.Count)
            {
                numOfSent = sentences.Count;
            }
            if (numOfSent > 0)
            {
                foreach (var item in sentences[numOfSent - 1].ElementsOfText)
                {
                    if (item.Lenght == lenghtWord && item is Word)
                    {
                        item.Clear();
                        for (int i = 0; i < str.Length; i++)
                        {
                            item.Add(new Symbol() { Value = str[i] });
                        }
                    }
                }
            }
        }
               
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (var sent in sentences)
            {
                foreach (var textElements in sent.ElementsOfText)
                {
                    s.Append(textElements);
                }
            }
            return s.ToString();
        }
    }
}

