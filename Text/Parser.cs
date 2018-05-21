using System.Collections.Generic;
using System.Linq;
using System.Text;
using Text.Constants;
using Text.Factory;
using Text.Interface;
using Text.TextUnits;

namespace Text
{
    public class Parser
    {
        private SentenceFactory sentenceFactory = new SentenceFactory();

        private TextFactory textFactory = new TextFactory();

        private WordFactory wordFactory = new WordFactory();

        private const int Page = 1;

        public Texts Parse(StringBuilder text)
        {
            List<ITextItem> buffTextItems = new List<ITextItem>();

            List<Sentence> buffSentences = new List<Sentence>();

            List<Symbol> buffWordPunctuationMark = new List<Symbol>();

            int indexOfCaret = 1;

            DelExtraSymbols(text);

            for (int i = 0; i < text.Length - 1; i++)
            {
                buffWordPunctuationMark.Add(new Symbol() { Value = text[i] });

                if ((!Separators.InnerSentenceSeparators.Contains(text[i].ToString())
                        && !Separators.SentenceSeparators.Contains(text[i].ToString()))
                        && (Separators.InnerSentenceSeparators.Contains(text[i + 1].ToString())
                        || Separators.SentenceSeparators.Contains(text[i + 1].ToString())))
                {
                    buffTextItems.Add(wordFactory.Create(buffWordPunctuationMark.ToList(), indexOfCaret / Page));
                    buffWordPunctuationMark.Clear();

                    if (text[i + 1].ToString() == "\r")
                    {
                        text.Remove(i + 1, 1);
                        indexOfCaret++;
                    }
                }
                else
                {
                    if (Separators.InnerSentenceSeparators.Contains(text[i].ToString()))
                    {
                        buffTextItems.Add(wordFactory.Create(buffWordPunctuationMark.ToList(), indexOfCaret / Page));
                        buffWordPunctuationMark.Clear();
                    }

                    if ((Separators.SentenceSeparators.Contains(text[i].ToString()) && text[i + 1] == ' ')
                        || (Separators.SentenceSeparators.Contains(text[i].ToString()) && text[i + 1] == '\r'))
                    {
                        buffTextItems.Add(wordFactory.Create(buffWordPunctuationMark.ToList(), indexOfCaret / Page));
                        buffWordPunctuationMark.Clear();
                        buffSentences.Add(sentenceFactory.Create(buffTextItems.ToList()));
                        buffTextItems.Clear();
                    }

                    if (text[i].ToString() == "\r")
                    {
                        text.Remove(i, 1);
                        indexOfCaret++;
                    }
                }

                if (i + 1 == text.Length - 1)
                {
                    buffWordPunctuationMark.Add(new Symbol() { Value = text[i + 1] });
                    buffTextItems.Add(wordFactory.Create(buffWordPunctuationMark.ToList(), indexOfCaret / Page));

                    if (Separators.SentenceSeparators.Contains(buffTextItems.Last().ToString()))
                    {
                        buffSentences.Add(sentenceFactory.Create(buffTextItems.ToList()));
                    }
                }
            }

            return textFactory.Create(buffSentences);
        }

        private void DelExtraSymbols(StringBuilder text)
        {
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == ' ' && text[i + 1] == ' ' || text[i] == '\n' || text[i] == '\t')
                {
                    text.Remove(i, 1);
                    i--;
                }
            }
        }

    }
}
