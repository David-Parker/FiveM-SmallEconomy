using System;
using CitizenFX.Core;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Manage operations on players.
    /// </summary>
    public class PlayerHandler
    {
        public static string GetPlayerId(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return player.Identifiers["steam"];
        }
    }
}
