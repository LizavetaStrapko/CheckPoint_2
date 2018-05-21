using System;
using System.Collections.Generic;
using System.Linq;
using Text.Interface;
using Text.TextUnits;

namespace Text.Factory
{
    public class SentenceFactory
    {
        public Sentence Create(List<ITextItem> elementsOfText)
        {
            Sentence sent;

            PunctuationMark punct = elementsOfText.Last() as PunctuationMark;

            if (punct != null && punct.SymbolEndOfSent)
            {
                sent = new Sentence(elementsOfText);
            }
            else
            {
                throw new Exception("Error in a sentece");
            }

            return sent;
        }

    }
}
