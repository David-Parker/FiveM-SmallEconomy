using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Shared;

namespace SmallEconomy.Client.Event
{
    /// <summary>
    /// Client-side event for user to query their current money balance.
    /// </summary>
    public class GetMoneyClient : BaseScript
    {
        public GetMoneyClient()
        {
            API.RegisterCommand("getMoney", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (args.Count != 0)
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "Invalid Command", "Usage: /getMoney" }
                    });

                    return;
                }

                TriggerServerEvent(Events.GetMoneyEventServer, source);
            }), false);
        }

        public void GetMoneyEvent(UInt64 money)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                args = new[] { "[SmallEconomy]", $"Your Money: {money}" }
            });
        }
    }
}
