using Google.Protobuf.Protocol;
using ProjectRPG.Data;
using ProjectRPG.DB;

namespace ProjectRPG.Game
{
    public class Item
    {
        public ItemInfo Info { get; set; } = new ItemInfo();

        public int ItemDbId { get => Info.ItemDbId; set => Info.ItemDbId = value; }
        public int TemplateId { get => Info.TemplateId; set => Info.TemplateId = value; }
        public int Count { get => Info.Count; set => Info.Count = value; }
        public int Slot { get => Info.Slot; set => Info.Slot = value; }
        public bool Equipped { get => Info.Equipped; set => Info.Equipped = value; }

        public ItemType Type { get; private set; }
        public bool Stackable { get; protected set; }

        public Item(ItemType type)
        {
            Type = type;
        }

        public static Item MakeItem(ItemDb itemDb)
        {
            Item item = null;

            DataManager.ItemDict.TryGetValue(itemDb.TemplateId, out ItemData itemData);
            if (itemData == null) return null;

            switch (itemData.itemType)
            {
                case ItemType.Weapon:
                    item = new Weapon(itemDb.TemplateId);
                    break;
                case ItemType.Consumable:
                    item = new Consumable(itemDb.TemplateId);
                    break;
            }

            if (item != null)
            {
                item.ItemDbId = itemDb.ItemDbId;
                item.Count = itemDb.Count;
                item.Slot = itemDb.Slot;
                item.Equipped = itemDb.Equipped;
            }

            return item;
        }
    }
}