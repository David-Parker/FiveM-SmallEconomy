using System;

namespace SmallEconomy.Client.Items
{
    /// <summary>
    /// Represents a pointer to GTA Native object so client can cleanup item.
    /// </summary>
    public abstract class ItemHandle : IDisposable
    {
        public ItemHandle(string handle)
        {
            this.Handle = handle;
        }

        public string Handle { get; private set; }
        public abstract void Dispose();
    }
}
