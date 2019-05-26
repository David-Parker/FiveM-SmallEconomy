using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Events to be called on game tick.
    /// </summary>
    public class OnTick : BaseScript
    {
        private readonly IDatabase database;
        private const int PayDayInterval = 1000 * 5; // Every minute

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
            this.database.UpdateMoneyForAllPlayers(5);
            await Delay(PayDayInterval);
        }
    }
}
