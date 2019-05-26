using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using SmallEconomy.Shared;

namespace SmallEconomy.Client.Event
{
    /// <summary>
    /// Client-side event for user to use an item in their inventory.
    /// </summary>
    public class BuyItemClient : BaseScript
    {
        public BuyItemClient()
        {
            API.RegisterCommand("buyItem", new Action<int, List<object>, string>((source, args, raw) =>
            {
                uint index;

                if (args.Count != 1 || uint.TryParse(args[0] as string, out index) == false)
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "Invalid Command", "Usage: /buyItem index" }
                    });

                    return;
                }

                TriggerServerEvent(Events.BuyItemEventServer, index, source);
            }), false);
        }

        public void BuyItemEvent(bool succeeded, string item)
        {
            if (succeeded)
            {
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[SmallEconomy]", $"You successfully bought a {item}!" }
                });
            }
        }
    }
}
