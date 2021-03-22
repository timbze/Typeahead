using System;
using System.Threading.Tasks;

namespace Blazored.Typeahead
{
    public interface ITypeaheadValueConverter<TItem, TValue>
    {
        TValue ConvertItemToValue(TItem item);
        TItem ConvertValueToItem(TValue item);
    }

    public class DefaultTypeaheadConverter<TItem, TValue> : ITypeaheadValueConverter<TItem, TValue>
    {
        public TValue ConvertItemToValue(TItem item)
        {
            if (item is TValue t)
                return t;
            else
                throw new ArgumentException("TItem must be the same type as TValue");
        }

        public TItem ConvertValueToItem(TValue item)
        {
            if (item is TItem t)
                return t;
            else
                throw new ArgumentException("TItem must be the same type as TValue");
        }
    }
}