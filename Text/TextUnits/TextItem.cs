using System.Collections.Generic;
using System.Collections.ObjectModel;
using Text.Interface;

namespace Text.TextUnits
{
    public abstract class TextItem : ITextItem
    {
        public List<Symbol> chars = new List<Symbol>();

        public ReadOnlyCollection<Symbol> Chars
        {
            get { return new ReadOnlyCollection<Symbol>(chars); }
        }

        public int Lenght
        {
            get  { return chars.Count; }
        }

        public void Add(Symbol symbol)
        {
            this.chars.Add(symbol);
        }

        public void Clear()
        {
            this.chars.Clear();
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in chars)
            {
                str += item.Value.ToString();
            }
            return str;
        }
    }
}

