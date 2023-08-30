using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectRPG.Data;

namespace ProjectRPG.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<AccountDb> Accounts { get; set; }
        public DbSet<PlayerDb> Players { get; set; }
        public DbSet<ItemDb> Items { get; set; }

        private static readonly ILoggerFactory _logger = LoggerFactory.Create(builder => builder.AddConsole());

        private string _connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ProjectRPG_GameDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLoggerFactory(_logger)
                .UseSqlServer(ConfigManager.Config == null ? _connectionString : ConfigManager.Config.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDb>()
                .HasIndex(a => a.AccountName)
                .IsUnique();

            modelBuilder.Entity<PlayerDb>()
                .HasIndex(p => p.PlayerName)
                .IsUnique();
        }
    }
}