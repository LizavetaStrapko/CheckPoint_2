using System.Collections.Generic;
using Text.TextUnits;

namespace Text.Factory
{
    public class TextFactory
    {
        public Texts Create(List<Sentence> sentences)
        {
            return new Texts(sentences);
        }
    }
}

