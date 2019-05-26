using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Shared;

namespace SmallEconomy.Client
{
    /// <summary>
    /// Register client-side events.
    /// </summary>
    public class EventRegistration : BaseScript
    {
        public EventRegistration()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (API.GetCurrentResourceName() != resourceName)
            {
                return;
            }

            API.RegisterCommand("getMoney", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (args.Count != 0)
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "Invalid Command", "Usage: /getMoney" }
                    });
                }

                TriggerServerEvent(Events.GetMoneyEvent, source);
            }), false);
        }
    }
}
