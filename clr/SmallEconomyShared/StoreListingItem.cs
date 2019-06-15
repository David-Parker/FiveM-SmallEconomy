using System;

namespace SmallEconomy.Shared
{
    /// <summary>
    /// Fakes an item type for store listing.
    /// </summary>
    public class StoreListingItem : Item
    {
        private readonly ItemType type;
        private readonly string displayName;

        public StoreListingItem(ItemType type, string displayName)
        {
            this.type = type;
            this.displayName = displayName;
        }

        public ItemType Type
        {
            get { return this.type; }
        }

        public string DisplayName
        {
            get { return this.displayName; }
        }

        public string Handle
        {
            get { throw new InvalidOperationException(); }
        }

        public void Use()
        {
            throw new InvalidOperationException();
        }

        public void Dispose()
        {
            return;
        }
    }
}
