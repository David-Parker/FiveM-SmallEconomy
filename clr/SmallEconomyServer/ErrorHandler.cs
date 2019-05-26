using System;
using CitizenFX.Core;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Report errors back to the user.
    /// </summary>
    public class ErrorHandler : BaseScript
    {
        private ErrorHandler() { }

        public static void PlayerError(Player player, string message)
        {
            TriggerClientEvent(player, "chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[Small Econ]", $"Invalid operation: {message}." }
            });
        }

        public static void ServerError(Player player, Exception ex)
        {
            TriggerClientEvent(player, "chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[Small Econ]", $"Server retruned an error: {ex.Message}." }
            });
        }
    }
}
