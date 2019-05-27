using System;
using System.Text;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Event
{
    /// <summary>
    /// Server-side event for player to query their current money balance.
    /// </summary>
    public class ListItemsServer : BaseScript
    {
        private readonly IDatabase database;

        public ListItemsServer(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
        }

        public void ListItemsEvent([FromSource] Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            EconomyData data = this.database.GetEconomyDataForPlayer(PlayerHandler.GetPlayerId(player));

            StringBuilder items = new StringBuilder();
            for (int i = 0; i < data.Items.Count; ++i)
            {
                items.AppendFormat("[{0}]: {1}", i, data.Items[i].DisplayName);

                if (i < data.Items.Count - 1)
                {
                    items.Append(", ");
                }
            }

            TriggerClientEvent(player, Events.ListItemsEventClient, items.ToString());
        }
    }
}
