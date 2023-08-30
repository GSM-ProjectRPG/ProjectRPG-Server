using Google.Protobuf.Protocol;
using ProjectRPG.Data;

namespace ProjectRPG.Game
{
    public class Consumable : Item
    {
        public ConsumableType ConsumableType { get; private set; }
        public int MaxCount { get; set; }

        public Consumable(int templateId) : base(ItemType.Consumable)
        {
            Init(templateId);
        }

        private void Init(int templateId)
        {
            DataManager.ItemDict.TryGetValue(templateId, out ItemData itemData);
            if (itemData.itemType != ItemType.Consumable) return;

            var data = (ConsumableData)itemData;
            TemplateId = data.id;
            Count = 1;
            MaxCount = data.maxCount;
            ConsumableType = data.consumableType;
            Stackable = (data.maxCount > 1);
        }
    }
}