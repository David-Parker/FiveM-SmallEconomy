using System;

namespace SmallEconomy.Shared
{
    /// <summary>
    /// Defines an Item.
    /// </summary>
    public interface Item : IDisposable
    {
        ItemType Type { get; }
        string DisplayName { get; }
        string Handle { get; }
        void Use();
    }
}
