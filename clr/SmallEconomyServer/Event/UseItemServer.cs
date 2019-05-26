using System;
using CitizenFX.Core;
using SmallEconomy.Server.Items;

namespace SmallEconomy.Server.Event
{
    /// <summary>
    /// Server-side event for player to use an item.
    /// </summary>
    public class UseItemServer : BaseScript
    {
        private readonly IDatabase database;

        public UseItemServer(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
        }

        public void UseItemEvent(uint index, [FromSource] Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Item item = this.database.GetItemForPlayer(player.Identifiers["steam"], index);

            if (item == null)
            {
                item = new VehicleItem(player, "adder");
                this.database.AddItemForPlayer(player.Identifiers["steam"], item);
            }

            item.Use();
        }
    }
}
