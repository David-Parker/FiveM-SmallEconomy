using System;
using System.Linq;
using System.Text;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Event
{
    /// <summary>
    /// Server-side event for player to query their current money balance.
    /// </summary>
    public class ViewStoreServer : BaseScript
    {
        private readonly IDatabase database;

        public ViewStoreServer(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
        }

        public void ViewStoreEvent([FromSource] Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            StoreListing data = this.database.GetStoreListingData();

            StringBuilder items = new StringBuilder();
            for (int i = 0; i < data.Items.Count(); ++i)
            {
                items.AppendFormat("[{0}:${1}] {2}", i, data.Items.ElementAt(i).Price, data.Items.ElementAt(i).Item.DisplayName);

                if (i < data.Items.Count() - 1)
                {
                    items.Append(", ");
                }
            }

            TriggerClientEvent(player, Events.ViewStoreEventClient, items.ToString());
        }
    }
}
