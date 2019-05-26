using System;
using System.Linq;
using CitizenFX.Core;
using SmallEconomy.Server.Items;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Event
{
    /// <summary>
    /// Server-side event for player to use an item.
    /// </summary>
    public class BuyItemServer : BaseScript
    {
        private readonly IDatabase database;

        public BuyItemServer(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
        }

        public void BuyItemEvent(uint index, [FromSource] Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            string id = PlayerHandler.GetPlayerId(player);
            EconomyData playerData = this.database.GetEconomyDataForPlayer(id);
            StoreListing storeListing = this.database.GetStoreListingData();

            if (index >= storeListing.Items.Count())
            {
                ErrorHandler.PlayerError(player, $"There is no item in the store for slot {index}");
                return;
            }

            StoreItem storeItem = storeListing.Items.ElementAt((int)index);

            if (storeItem.Price > playerData.Money)
            {
                ErrorHandler.PlayerError(player, $"You cannot afford {storeItem.Item.DisplayName}");
                return;
            }

            // Deduct money
            bool success = this.database.DeductMoneyForPlayer(id, storeItem.Price);

            if (success == false)
            {
                ErrorHandler.PlayerError(player, $"Error with database transaction, please retry purchase.");
                return;
            }

            // Give item
            this.database.AddItemForPlayer(id, ItemCloningFactory.Clone(storeItem.Item, player));

            TriggerClientEvent(player, Events.BuyItemEventClient, true, storeItem.Item.DisplayName);
        }
    }
}
