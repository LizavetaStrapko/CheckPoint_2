using System;
using System.Collections.Generic;
using System.Linq;
using Text.Constants;
using Text.Interface;

namespace Text.TextUnits
{
    public class PunctuationMark : TextItem, IPunctuationMark
    {
        //public PunctuationMark()
        //{ }
        public PunctuationMark(List<Symbol> symbols)
        {
            if (Separators.InnerSentenceSeparators.Contains(symbols.Last().Value.ToString()) || Separators.SentenceSeparators.Contains(symbols.Last().Value.ToString()))
            {
                base.chars = symbols;
            }
            else
            {
                throw new Exception("Unknown data");
            }
        }

        public bool SymbolEndOfSent
        {
            get { return Separators.SentenceSeparators.Contains(this.ToString()); }
        }
    }
}
