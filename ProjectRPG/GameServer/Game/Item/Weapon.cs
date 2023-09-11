using Google.Protobuf.Protocol;
using ProjectRPG.Data;

namespace ProjectRPG.Game
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public int Damage { get; private set; }

        public Weapon(int templateId) : base(ItemType.Weapon)
        {
            Init(templateId);
        }

        private void Init(int templateId)
        {
            DataManager.ItemDict.TryGetValue(templateId, out ItemData itemData);
            if (itemData.itemType != ItemType.Weapon) return;

            var data = (WeaponData)itemData;
            TemplateId = data.id;
            Count = 1;
            WeaponType = data.weaponType;
            Damage = data.damage;
            Stackable = false;
        }
    }
}