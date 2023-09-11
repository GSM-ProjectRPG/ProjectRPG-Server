using Google.Protobuf.Protocol;
using GameServer.Data;

namespace GameServer.Game
{
    public class Accessory : Item
    {
        public AccessoryType AccessoryType { get; set; }

        public Accessory(int templateId) : base(ItemType.Accessory)
        {
            Init(templateId);
        }

        private void Init(int templateId)
        {
            DataManager.ItemDict.TryGetValue(templateId, out ItemData itemData);
            if (itemData.itemType != ItemType.Accessory) return;

            var data = (AccessoryData)itemData;
            TemplateId = data.id;
            Count = 1;
            AccessoryType = data.accessoryType;
            Stackable = false;
        }
    }
}