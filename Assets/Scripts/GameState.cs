using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameState: MonoBehaviour
    {
        private Dictionary<ItemType, uint> items = new();

        public static void AddItem(ItemType type, uint amount)
        {
            var instance = FindObjectOfType<GameState>();
            if (!instance.items.TryAdd(type, amount))
            {
                instance.items[type] += amount;
            }
        }

        public static bool TryRemoveItem(ItemType type, uint amount)
        {
            var instance = FindObjectOfType<GameState>();
            if (instance.items.TryGetValue(type, out var ownedAmount))
            {
                if (ownedAmount < amount)
                {
                    return false;
                }

                instance.items[type] -= amount;
                return true;
            }

            return false;
        }

        public static bool HasEnoughItems(ItemType type, uint amount)
        {
            var instance = FindObjectOfType<GameState>();
            if (instance.items.TryGetValue(type, out var ownedAmount))
            {
                return ownedAmount >= amount;
            }

            return false;
        }
    }
}