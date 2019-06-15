using System.Collections.Generic;

namespace SmallEconomy.Shared
{
    /// <summary>
    /// Represents all that the store has for sale.
    /// </summary>
    public class StoreListing
    {
        public StoreListing(IEnumerable<StoreItem> items)
        {
            this.Items = items;
        }

        public IEnumerable<StoreItem> Items { get; set; }
    }
}
