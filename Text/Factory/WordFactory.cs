using System;
using System.Collections.Generic;
using System.Linq;
using Text.Constants;
using Text.Interface;
using Text.TextUnits;

namespace Text.Factory
{
    public class WordFactory
    {
        public ITextItem Create(List<Symbol> symbols, int pageNumber)
        {
            ITextItem textElement;

            if (!Separators.SentenceSeparators.Contains(symbols.Last().Value.ToString())
                    && !Separators.InnerSentenceSeparators.Contains(symbols.Last().Value.ToString()))
            {
                textElement = new Word(symbols);
                ((Word)textElement).PageNumber = pageNumber;
            }
            else
            {
                if (Separators.InnerSentenceSeparators.Contains(symbols.Last().Value.ToString())
                    || Separators.SentenceSeparators.Contains(symbols.Last().Value.ToString()))
                {
                    textElement = new PunctuationMark(symbols);
                }
                else
                {
                    throw new Exception("Unknown data");
                }

            }

            return textElement;

        }

    }
}

