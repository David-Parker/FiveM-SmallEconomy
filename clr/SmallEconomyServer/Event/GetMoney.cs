using System;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Event
{
    /// <summary>
    /// Server-side event for player to query their current money balance.
    /// </summary>
    public class GetMoney : BaseScript
    {
        private readonly IDatabase database;

        public GetMoney(IDatabase database)
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

            EconomyData data = this.database.GetEconomyDataForPlayer(player.Identifiers["steam"]);

            TriggerClientEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[SmallEconomy]", $"Your Money: {data.Money}" }
            });
        }
    }
}
