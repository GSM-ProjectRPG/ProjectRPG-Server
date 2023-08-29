using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRPG.DB
{
    [Table("Account")]
    public class AccountDb
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public ICollection<PlayerDb> Players { get; set; }
    }

    [Table("Player")]
    public class PlayerDb
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        [ForeignKey("Account")]
        public int AccountDbId { get; set; }
        public AccountDb Account { get; set; }

        public ICollection<ItemDb> Items { get; set; }

    }

    [Table("Item")]
    public class ItemDb
    {
        public int ItemDbId { get; set; }
        public int TemplateId { get; set; }
        public int Count { get; set; }
        public int Slot { get; set; }
        public bool Equipped { get; set; } = false;

        [ForeignKey("Owner")]
        public int? OwnerDbId { get; set; }
        public PlayerDb Owner { get; set; }
    }
}