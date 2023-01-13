using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Name = "Audi A4",
                    Description ="Комфортабельный седан",
                    DateCreate = DateTime.Now,
                    Speed = 270,
                    Model = "A4",
                    Price = 27500,
                    Avatar = null,
                    TypeCar = TypeCar.Sedan,
                    ImageUrl = "https://fikiwiki.com/uploads/posts/2022-02/1644909361_5-fikiwiki-com-p-kartinki-mashini-audi-5.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 2,
                    Name = "Audi Q4 Electron",
                    Description = "Premium Внедорожник новой эры. Машина имеет все предпосылки для того, чтобы стать успешной в своем сегменте. ",
                    DateCreate = DateTime.Now,
                    Speed = 200,
                    Price = 45000,
                    Model = "Q4 E-TRON",
                    Avatar = null,
                    TypeCar = TypeCar.Suv,
                    ImageUrl = "https://www.auto-data.net/images/f49/Audi-Q4-Sportback-e-tron-concept.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 3,
                    Name = "Audi A1",
                    Description = "Такой автомобиль не растворится в сером будничном потоке и отлично подчеркнет индивидуальность своего владельца.",
                    DateCreate = DateTime.Now,
                    Speed = 240,
                    Model = "A1",
                    Price = 18500,
                    Avatar = null,
                    TypeCar = TypeCar.HatchBack,
                    ImageUrl = "https://img.salon.av.by/catalog/audi/a1/e7/3/e7399b1c.jpeg"
                });
                builder.HasData(new Car
                {
                    Id = 4,
                    Name = "Audi A3",
                    Description = "Премиумный компактный автомобиль с спортивным видом",
                    DateCreate = DateTime.Now,
                    Speed = 250,
                    Model = "A3",
                    Price = 22000,
                    Avatar = null,
                    TypeCar = TypeCar.HatchBack,
                    ImageUrl = "https://www.motorionline.com/wp-content/gallery/audi-a3-sedan-2021/Audi-A3-Sedan-2021-113.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 5,
                    Name = "Audi A5",
                    Description = "Премиум седан для деловых встреч",
                    DateCreate = DateTime.Now,
                    Speed = 270,
                    Model = "A5",
                    Price = 25000,
                    Avatar = null,
                    TypeCar = TypeCar.Sedan,
                    ImageUrl = "https://avcdn.av.by/cargeneration/0000/5712/6373.jpeg"
                });
                builder.HasData(new Car
                {
                    Id = 6,
                    Name = "Audi A6",
                    Description = "PREMIUM Version седана с кучей электронных функций",
                    DateCreate = DateTime.Now,
                    Speed = 300,
                    Model = "A6",
                    Price = 28000,
                    Avatar = null,
                    TypeCar = TypeCar.Sedan,
                    ImageUrl = "https://cdn.motor1.com/images/mgl/0e4BEz/s1/audi-a6-avant-e-tron-concept-studio-city-backdrop-front-angle.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 7,
                    Name = "Audi A7",
                    Description = "Audi A7- это премиальный четырехдверный лифтбэк E класса. Его габаритные размеры составляют: длина 4969 мм, ширина 1908 мм, высота 1422 мм, а колесная база- 2926 мм.",
                    DateCreate = DateTime.Now,
                    Speed = 320,
                    Model = "A7",
                    Price = 32000,
                    Avatar = null,
                    TypeCar = TypeCar.Sedan,
                    ImageUrl = "https://s1.1zoom.ru/big3/233/Audi_Hatchback_A7_Sportback_quattro_2018_Silver_599269_5120x2812.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 8,
                    Name = "Audi E-Tron",
                    Description = "Ауди Е-трон – это премиальный полностью электрический полноразмерный пятиместный кроссовер.",
                    DateCreate = DateTime.Now,
                    Speed = 250,
                    Model = "E-Tron",
                    Price = 51000,
                    Avatar = null,
                    TypeCar = TypeCar.Suv,
                    ImageUrl = "https://avtodream.org/uploads/posts/2018-04/1524295367_elektrokrossover-audi-e-tron-budet-zaryazhatsya-bystree-tesla.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 9,
                    Name = "Audi Q3",
                    Description = "Audi Q3 - Новый премиальный среднеразмерный кроссовер легендарного немецкого бренда с впечатляющими динамическими характеристиками.",
                    DateCreate = DateTime.Now,
                    Speed = 240,
                    Model = "Q3",
                    Price = 27000,
                    Avatar = null,
                    TypeCar = TypeCar.Suv,
                    ImageUrl = "https://www.wallpaperup.com/uploads/wallpapers/2020/02/19/1369709/a2e09e13d80fdead188e88af6e739aa1-700.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 10,
                    Name = "Audi Q5",
                    Description = "Audi Q5 идет в ногу со временем. У нее стильный и харизматичный дизайн, который как нельзя лучше подчеркнет характер и статус своего владельца в обществе.",
                    DateCreate = DateTime.Now,
                    Speed = 270,
                    Model = "Q5",
                    Price = 33000,
                    Avatar = null,
                    TypeCar = TypeCar.Suv,
                    ImageUrl = "https://wallpapercave.com/wp/wp10799385.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 11,
                    Name = "Audi Q7",
                    Description = "Ауди Ку7- это премиальный кроссовер с возможностью установки третьего ряда сидений.",
                    DateCreate = DateTime.Now,
                    Speed = 290,
                    Model = "Q7",
                    Price = 36000,
                    Avatar = null,
                    TypeCar = TypeCar.Suv,
                    ImageUrl = "https://columbauto.by/upload/iblock/1b0/1b0f2bf89da1e83109d6cb778b402cd2.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 12,
                    Name = "Audi Q8",
                    Description = "Ауди Ку 8- это полноразмерный пятиместный внедорожник премиум класса.",
                    DateCreate = DateTime.Now,
                    Speed = 300,
                    Model = "Q8",
                    Price = 40000,
                    Avatar = null,
                    TypeCar = TypeCar.Suv,
                    ImageUrl = "https://wheelz.me/wp-content/uploads/2021/05/A213053_medium.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 13,
                    Name = "Audi R8",
                    Description = "RWS- принципиально новая модель для немецкого производителя.",
                    DateCreate = DateTime.Now,
                    Speed = 330,
                    Model = "R8",
                    Price = 29000,
                    Avatar = null,
                    TypeCar = TypeCar.SportsCar,
                    ImageUrl = "https://pbs.twimg.com/media/FBG7sftXMAMquaZ.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 14,
                    Name = "Audi RS Q3",
                    Description = "Ауди Эр-Эс Ку 3- это пятиместный спортивный кроссовер премиум класса.",
                    DateCreate = DateTime.Now,
                    Speed = 300,
                    Model = "RS Q3",
                    Price = 49000,
                    Avatar = null,
                    TypeCar = TypeCar.SportsCar,
                    ImageUrl = "https://a.d-cd.net/22f83ces-960.jpg"
                });
                builder.HasData(new Car
                {
                    Id = 15,
                    Name = "Audi RS Q8",
                    Description = "Ауди РС Ку8- это спортивный полноразмерный кроссовер премиум класса. Он насчитывает 4986 мм в длину, 1995 мм в ширину, 1705 мм в высоту и 2995 мм между колесными парами.",
                    DateCreate = DateTime.Now,
                    Speed = 310,
                    Model = "RS Q8",
                    Price = 52000,
                    Avatar = null,
                    TypeCar = TypeCar.SportsCar,
                    ImageUrl = "https://i.pinimg.com/originals/03/0b/fa/030bfa46e969dd37d4fb0e4fbca166f2.jpg"
                });

            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.Id);
                
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Age);
                builder.Property(x => x.Address).IsRequired(false);
                builder.Property(x => x.Telephone).IsRequired(false);
                
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