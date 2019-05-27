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

        public void Dispose()
        {
            if (this.inUse == false)
            {
                ErrorHandler.PlayerError(player, "Item not in use");
            }

            this.inUse = false;
            TriggerClientEvent(this.player, Events.StashItemEventClient, this.Handle);
        }
    }
}
