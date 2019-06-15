using System;
using CitizenFX.Core;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Manage operations on players.
    /// </summary>
    public class PlayerHandler : BaseScript
    {
        public static string GetPlayerId(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return player.Identifiers["steam"];
        }

        public static void Announce(Player player, string message)
        {
            TriggerClientEvent(player, "chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[Small Econ]", $"Server: {message}." }
            });
        }
    }
}
