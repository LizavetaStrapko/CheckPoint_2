using System.Collections.ObjectModel;
using Text.TextUnits;

namespace Interfaces.Interface
{
    interface ITextItem
    {
        ReadOnlyCollection<Symbol> Chars { get; }

        int Lenght { get; }

        void Clear();

        void Add(Symbol symbol);
    }
}
