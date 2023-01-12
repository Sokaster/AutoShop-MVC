using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Basket> Baskets { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);
                
            
                builder.HasData(new User
                {
                    Id = 1,
                    Name = "Sokaster",
                    Password = HashPasswordHelper.HashPassowrd("123456"),
                    Role = Role.Admin
                });
 
                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

                builder.HasOne(x => x.Profile)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                
                builder.HasOne(x => x.Basket)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Car>(builder =>
            {
                builder.ToTable("Cars").HasKey(x => x.Id);
                
                builder.HasData(new Car
                {
                    Id = 1,
                    Name = "AudiA4",
                    Description ="Fast And Furious car",
                    DateCreate = DateTime.Now,
                    Speed = 270,
                    Model = "A4",
                    Price = 27500,
                    Avatar = null,
                    TypeCar = TypeCar.PassengerCar
                });
                builder.HasData(new Car
                {
                    Id = 2,
                    Name = "AudiQ4",
                    Description = "премиальный электрокар пополнил ряды автомобилей новой эры. В Двух вариантах",
                    DateCreate = DateTime.Now,
                    Speed = 270,
                    Price = 45000,
                    Model = "Q4 E-TRON",
                    Avatar = null,
                    TypeCar = TypeCar.PassengerCar
                });
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.Id);
                
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Age);
                builder.Property(x => x.Address).HasMaxLength(200).IsRequired(false);
                
                builder.HasData(new Profile()
                {
                    Id = 1,
                    UserId = 1
                });
            });
            
            modelBuilder.Entity<Basket>(builder =>
            {
                builder.ToTable("Baskets").HasKey(x => x.Id);
                
                builder.HasData(new Basket() 
                {
                    Id = 1,
                    UserId = 1
                });
            });
            
            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders").HasKey(x => x.Id);

                builder.HasOne(r => r.Basket).WithMany(t => t.Orders)
                    .HasForeignKey(r => r.BasketId);
            });
        }
    }
}