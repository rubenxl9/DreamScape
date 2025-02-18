using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using DreamScape.Data;

namespace DreamScape.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<TradeItem> TradeItems { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Status> Statuses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
            "server=localhost;user=root;password=;database=DreamScape",
            ServerVersion.Parse("8.0.30")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    Username = "ShadowSlayer",
                    Password = "Test123!",
                    Email = "Shadow@example.com",
                    role_id = 1
                },
                new Player
                {
                    Id = 2,
                    Username = "MysticMage",
                    Password = "Mage2024",
                    Email = "Mystic@example.com",
                    role_id = 1
                },
                new Player
                {
                    Id = 3,
                    Username = "DragonKnight",
                    Password = "Dragon!99",
                    Email = "Dragon@example.com",
                    role_id = 1
                },
                new Player
                {
                    Id = 4,
                    Username = "AdminMaster",
                    Password = "Admin007",
                    Email = "Admin@example.com",
                    role_id = 2
                },
                new Player
                {
                    Id = 5,
                    Username = "ThunderRogue",
                    Password = "Thund3r!!",
                    Email = "Thunder@example.com",
                    role_id = 1
                });
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Player"
                },
                new Role
                {
                    Id = 2,
                    Name = "Admin"
                });
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 101,
                    Title = "Zwaard des Vuur",
                    Description = "Een mythisch zwaard met een vlammende gloed.",
                    Stat_id = 1,
                    Type_id = 1
                },
                new Item
                {
                    Id = 102,
                    Title = "IJs Amulet",
                    Description = "Een amulet dat de drager beschermt tegen kou.",
                    Stat_id = 2,
                    Type_id = 2
                },
                new Item
                {
                    Id = 103,
                    Title = "Schaduw Mantel",
                    Description = "Een donkere mantel die je bewegingen verbergt.",
                    Stat_id = 3,
                    Type_id = 3
                },
                new Item
                {
                    Id = 104,
                    Title = "Hamer der Titanen",
                    Description = "Een massieve hamer met de kracht van de aarde.",
                    Stat_id = 4,
                    Type_id = 1
                },
                new Item
                {
                    Id = 105,
                    Title = "Lichtboog",
                    Description = "Een boog die pijlen van pure energie afvuurt.",
                    Stat_id = 5,
                    Type_id = 1
                },
                new Item
                {
                    Id = 106,
                    Title = "Helende Ring",
                    Description = "Een ring die de gezondheid van de drager herstelt.",
                    Stat_id = 6,
                    Type_id = 2
                },
                new Item
                {
                    Id = 107,
                    Title = "Demonen Harnas",
                    Description = "Een verdoemd harnas met duistere krachten.",
                    Stat_id = 7,
                    Type_id = 3
                });
            modelBuilder.Entity<Stat>().HasData(
                new Stat
                {
                    Id = 1,
                    Rarity = "Legendarisch",
                    Power = 90,
                    Speed = 60,
                    Durability = 80,
                    Ability = "+30% vuurschade"
                },
                new Stat
                {
                    Id = 2,
                    Rarity = "Episch",
                    Power = 20,
                    Speed = 10,
                    Durability = 70,
                    Ability = "+25% weerstand tegen ijsaanvallen"
                },
                new Stat
                {
                    Id = 3,
                    Rarity = "Zeldzaam",
                    Power = 40,
                    Speed = 85,
                    Durability = 50,
                    Ability = "+15% kans om aanvallen te ontwijken"
                },
                new Stat
                {
                    Id = 4,
                    Rarity = "Legendarisch",
                    Power = 95,
                    Speed = 40,
                    Durability = 90,
                    Ability = "Kan vijanden 3 sec verdoven"
                },
                new Stat
                {
                    Id = 5,
                    Rarity = "Episch",
                    Power = 85,
                    Speed = 75,
                    Durability = 60,
                    Ability = "+10% kans op kritieke schade"
                },
                new Stat
                {
                    Id = 6,
                    Rarity = "Zeldzaam",
                    Power = 10,
                    Speed = 5,
                    Durability = 100,
                    Ability = "+5 HP per seconde"
                },
                new Stat
                {
                    Id = 7,
                    Rarity = "Legendarisch",
                    Power = 75,
                    Speed = 50,
                    Durability = 95,
                    Ability = "Absorbeert 20% van ontvangen schade"
                });
            modelBuilder.Entity<Type>().HasData(
                new Type
                {
                    Id = 1,
                    Name = "Wapen"
                },
                new Type
                {
                    Id = 2,
                    Name = "Accessoire"
                },
                new Type
                {
                    Id = 3,
                    Name = "Armor"
                });
        }
    }
}