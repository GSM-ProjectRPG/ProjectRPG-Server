using System;
using Microsoft.EntityFrameworkCore;
using Google.Protobuf.Protocol;
using GameServer.Data;
using GameServer.Game;
using GameServer.Job;

namespace GameServer.DB
{
    public partial class DbTransaction : JobSerializer
    {
        public static DbTransaction Instance { get; } = new DbTransaction();

        public static void RewardPlayer(Player player, RewardData rewardData, GameRoom room)
        {
            if (player == null || rewardData == null || room == null)
                return;

            int? slot = player.Inven.GetEmptySlot();
            if (slot == null)
                return;

            var itemDb = new ItemDb()
            {
                TemplateId = rewardData.itemId,
                Count = rewardData.count,
                Slot = slot.Value,
                OwnerDbId = player.PlayerDbId
            };

            Instance.Push(() =>
            {
                using (var db = new AppDbContext())
                {
                    db.Items.Add(itemDb);
                    bool success = db.SaveChangesEx();
                    if (success)
                    {
                        room.Push(() =>
                        {
                            var newItem = Item.MakeItem(itemDb);
                            player.Inven.Add(newItem);

                            // Noti
                            var itemPacket = new S_AddItem();
                            var itemInfo = new ItemInfo();
                            itemInfo.MergeFrom(newItem.Info);
                            itemPacket.Items.Add(itemInfo);

                            player.Session.Send(itemPacket);
                        });
                    }
                }
            });
        }
    }
}