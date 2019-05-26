using System;
using CitizenFX.Core;
using SmallEconomy.Server.Items;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Keeps track of items owned by each player.
    /// </summary>
    public class ItemInventory
    {
        private readonly IDatabase database;

        public ItemInventory(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
        }

        public void AddItem(Player player, Item item)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            this.database.AddItemForPlayer(player.Identifiers["steam"], item);
        }

        public Item GetItem(Player player, uint index)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return this.database.GetItemForPlayer(player.Identifiers["steam"], index);
        }
    }
}
