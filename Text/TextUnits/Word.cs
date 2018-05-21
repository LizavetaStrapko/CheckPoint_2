using System;
using System.Collections.Generic;
using System.Linq;
using Text.Constants;
using Text.Interface;

namespace Text.TextUnits
{
    public class Word : TextItem, IWord
    {
        public Word(List<Symbol> symbols)
        {
            if (!Separators.SentenceSeparators.Contains(symbols.Last().Value.ToString())
             && !Separators.InnerSentenceSeparators.Contains(symbols.Last().Value.ToString()))
            {
                base.chars = symbols;
            }
            else
            {
                throw new Exception("Unknown data");
            }
        }

        public int PageNumber { get; set; }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}

