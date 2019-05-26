using System;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Event
{
    /// <summary>
    /// Server-side event for player to query their current money balance.
    /// </summary>
    public class GetMoneyServer : BaseScript
    {
        private readonly IDatabase database;

        public GetMoneyServer(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
        }

        public void GetMoneyEvent([FromSource] Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            EconomyData data = this.database.GetEconomyDataForPlayer(PlayerHandler.GetPlayerId(player));

            TriggerClientEvent(player, Events.GetMoneyEventClient, data.Money);
        }
    }
}
