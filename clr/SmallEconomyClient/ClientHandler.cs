using CitizenFX.Core;

namespace SmallEconomy.Client
{
    /// <summary>
    /// Report errors back to the user.
    /// </summary>
    public class ClientHandler : BaseScript
    {
        private ClientHandler() { }

        public static void PlayerError(string message)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[Small Econ]", $"Client error: {message}." }
            });
        }

        public static void PlayerInfo(string message)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[Small Econ]", $"{message}." }
            });
        }
    }
}
