using System;
using CitizenFX.Core;
using SmallEconomy.Server.Event;
using SmallEconomy.Shared;

namespace SmallEconomy.Server
{
    /// <summary>
    /// Register server-side events.
    /// </summary>
    public class EventRegistration : BaseScript
    {
        public EventRegistration()
        {
            var onTick = new OnTick(new InMemoryDatabase());
            Tick += onTick.Payday;

            var moneyEvent = new GetMoney(new InMemoryDatabase());
            EventHandlers[Events.GetMoneyEvent] += new Action<Player>(moneyEvent.GetMoneyEvent);
        }
    }
}
