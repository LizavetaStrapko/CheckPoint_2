using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Text.Interface;

namespace Text.TextUnits
{
    public enum TypeSent
    {
        Interrogative,
        Exclamatory,
        Declarative
    }

    public class Sentence
    {
        private List<ITextItem> elementsOfText = new List<ITextItem>();
        
        public Sentence(List<ITextItem> elementsOfText)
        {
            this.elementsOfText = elementsOfText;
        }

        public ReadOnlyCollection<ITextItem> ElementsOfText
        {
            get
            {
                return new ReadOnlyCollection<ITextItem>(elementsOfText);
            }
        }

        public void Remove(int i)
        {
            elementsOfText.RemoveAt(i);
        }

        public TypeSent TypeOfSentence
        {
            get
            {
                switch (elementsOfText.Last().ToString())
                {
                    case ".": return TypeSent.Declarative;
                    case "!": return TypeSent.Exclamatory;
                    case "?": return TypeSent.Interrogative;
                    default: return TypeSent.Declarative;
                }
            }
        }

        public int NumberOfWords
        {
            get
            {
                int i = 0;
                foreach (var item in elementsOfText)
                {
                    if (item is Word)
                    {
                        i++;
                    }
                }
                return i;
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in elementsOfText)
            {
                s.Append(item);
            }
            return s.ToString();
        }
    }
}
