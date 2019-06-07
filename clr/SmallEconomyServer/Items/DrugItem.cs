using System;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Items
{
    /// <summary>
    /// Vehicle item.
    /// </summary>
    public class DrugItem : ItemBase
    {
        private readonly string model;

        public DrugItem(Player player, string model)
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
        }

        public override ItemType Type
        {
            get { return ItemType.Drug; }
        }

        public override string DisplayName
        {
            get { return this.model; }
        }

        public override void Use()
        {
            if (this.inUse == true)
            {
                ErrorHandler.PlayerError(player, "Item already in use");
                return;
            }

            this.inUse = true;

            TriggerClientEvent(this.player, Events.UseItemEventClient, this.Handle, (int)this.Type, this.model);
        }
    }
}
