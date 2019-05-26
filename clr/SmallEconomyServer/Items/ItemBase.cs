using System;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Items
{
    /// <summary>
    /// Item base class for server items.
    /// </summary>
    public abstract class ItemBase : BaseScript, Item
    {
        public ItemBase()
        {
            this.Handle = Guid.NewGuid().ToString();
            this.inUse = false;
        }

        protected Player player;
        protected bool inUse;
        public string Handle { get; private set; }
        public abstract ItemType Type { get; }
        public abstract string DisplayName { get; }
        public abstract void Use();
        public abstract void Dispose();
    }
}
