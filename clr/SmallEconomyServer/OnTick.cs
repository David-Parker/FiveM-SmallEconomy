using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Events to be called on game tick.
    /// </summary>
    public class OnTick : BaseScript
    {
        private readonly IDatabase database;
        private const int PayDayInterval = 1000 * 120; // Every two minute

        public OnTick(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
        }

        public async Task Payday()
        {
            foreach (var player in this.Players)
            {
                string id = PlayerHandler.GetPlayerId(player);
                EconomyData economyData = this.database.GetEconomyDataForPlayer(id);
                Job playerJob = economyData.Job;
                UInt64 money = playerJob.pay;
                this.database.AddMoneyForPlayer(id, money);

                PlayerHandler.Announce(player, $"You just got paid ${money}.");
            }

            await Delay(PayDayInterval);
        }
    }
}
