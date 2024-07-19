﻿

namespace Games_Zone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameDevice>().HasKey(p => new { p.DeviceId, p.GameId });

            modelBuilder.Entity<userGameDevice>().HasKey(p => new { p.DeviceId, p.userGameId });

            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category { Id=1,Name="Sports"},
                    new Category { Id=2, Name ="Action" },
                    new Category { Id=3, Name ="Adventure" },
                    new Category { Id=4, Name ="Racing" },
                    new Category { Id=5, Name ="Fighting" },
                    new Category { Id=6, Name ="Film" }, // 7 was added in database
                    new Category { Id=8, Name ="post apocalyptic" },
                    new Category { Id=9, Name ="Survival" },
                    new Category { Id=10, Name ="Souls" },
                    new Category { Id=11, Name ="Horror"}
                });
            modelBuilder.Entity<Device>()
                .HasData(new Device[]
                {
                    new Device { Id=1,Name ="PlayStation" ,Icon ="bi bi-playstation"},
                    new Device { Id=2,Name ="xbox" ,Icon ="bi bi-xbox" },
                    new Device { Id=3,Name ="Nintendo Switch" ,Icon= "bi bi-nintendo-switch" },
                    new Device { Id=4,Name ="PC" ,Icon= "bi bi-pc-display" }

                });

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
        public DbSet<userGame> userGames { get; set; } 
        public DbSet<userGameDevice> userGameDevices { get; set; }

        
    }
}
