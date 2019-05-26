using System;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Items
{
    /// <summary>
    /// Vehicle item.
    /// </summary>
    public class VehicleItem : BaseScript, Item
    {
        private readonly string model;
        private readonly Player player;
        private bool inUse;

        public VehicleItem(Player player, string model)
        {
            if (String.IsNullOrEmpty(model))
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            this.model = model;
            this.player = player;
            this.inUse = false;
        }

        public ItemType Type
        {
            get { return ItemType.Vehicle; }
        }

        public string DisplayName
        {
            get { return this.model; }
        }

        public void Use()
        {
            if (this.inUse == true)
            {
                return;
            }

            this.inUse = true;

            TriggerClientEvent(this.player, Events.UseItemEventClient, (int)this.Type, this.model);
        }

        public void Dispose()
        {
            this.inUse = false;
            throw new NotImplementedException();
        }
    }
}
