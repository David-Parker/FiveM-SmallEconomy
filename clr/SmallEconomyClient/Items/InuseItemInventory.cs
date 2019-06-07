using System.Collections.Concurrent;

namespace SmallEconomy.Client.Items
{
    /// <summary>
    /// Keeps track of all the client's in-use items.
    /// </summary>
    public static class InUseItemInventory
    {
        private static readonly ConcurrentDictionary<string, ItemHandle> items;

        static InUseItemInventory()
        {
            items = new ConcurrentDictionary<string, ItemHandle>();
        }

        public static void Add(string handle, ItemHandle item)
        {
            items.TryAdd(handle, item);
        }

        public static void Remove(string handle)
        {
            ItemHandle item;

            if (items.TryRemove(handle, out item) == false)
            {
                return;
            }

            item.Dispose();
        }
    }
}
