using System;

namespace SmallEconomy.Shared
{
    /// <summary>
    /// Individual item in the store.
    /// </summary>
    public class StoreItem
    {
        public StoreItem(UInt64 price, Item item)
        {
            this.Price = price;
            this.Item = item;
        }

        public UInt64 Price { get; set; }
        public Item Item { get; set; }
    }
}
