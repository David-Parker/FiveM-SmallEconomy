﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using SmallEconomy.Client.Event;
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
            var moneyEvent = new GetMoneyClient();
            EventHandlers[Events.GetMoneyEventClient] += new Action<UInt64>(moneyEvent.GetMoneyEvent);

            var useItemEvent = new UseItemClient();
            EventHandlers[Events.UseItemEventClient] += new Func<int, string, Task>(useItemEvent.UseItemEvent);

            var listItemEvent = new ListItemsClient();
            EventHandlers[Events.ListItemsEventClient] += new Action<string>(listItemEvent.ListItemsEvent);
        }
    }
}
