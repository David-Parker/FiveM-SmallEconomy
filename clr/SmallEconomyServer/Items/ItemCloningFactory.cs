using System;
using CitizenFX.Core;
using SmallEconomy.Shared;

namespace SmallEconomy.Server.Items
{
    /// <summary>
    /// Clones items based on their type.
    /// </summary>
    public static class ItemCloningFactory
    {
        public static Item Clone(Item itemToClone, Player forPlayer)
        {
            Item newItem;

            switch (itemToClone.Type)
            {
                case ItemType.Vehicle:
                    newItem = new VehicleItem(forPlayer, itemToClone.DisplayName);
                    break;
                case ItemType.Weapon:
                    newItem = new WeaponItem(forPlayer, itemToClone.DisplayName);
                    break;
                case ItemType.Drug:
                    newItem = new DrugItem(forPlayer, itemToClone.DisplayName);
                    break;
                default:
                    throw new InvalidOperationException("Enum out of range.");
            }

            return newItem;
        }
    }
}
