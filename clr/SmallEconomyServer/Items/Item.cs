using System;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Items
{
    /// <summary>
    /// Defines an Item.
    /// </summary>
    public interface Item : IDisposable
    {
        ItemType Type { get; }
        string DisplayName { get; }
        void Use();
    }
}
