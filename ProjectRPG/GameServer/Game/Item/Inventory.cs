using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Game
{
    public class Inventory
    {
        public Dictionary<int, Item> Items { get; } = new Dictionary<int, Item>();

        public void Add(Item item)
        {
            Items.Add(item.ItemDbId, item);
        }

        public Item Get(int itemDbId)
        {
            Items.TryGetValue(itemDbId, out Item item);
            return item;
        }

        public Item Find(Func<Item, bool> predicate)
        {
            foreach (var item in Items.Values)
            {
                if (predicate.Invoke(item))
                    return item;
            }

            return null;
        }

        public int? GetEmptySlot()
        {
            for (int slot = 0; slot < 20; slot++)
            {
                var item = Items.Values.FirstOrDefault(i => i.Slot == slot);
                if (item == null)
                    return slot;
            }

            return null;
        }
    }
}