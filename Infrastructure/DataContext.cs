using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Custumer> Custumers { get; set; }
        public DbSet<ShopSetting> ShopSettings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Otp> Otps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().
               Property(x => x.FirstName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().
               Property(x => x.LastName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().
               Property(x => x.Email).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().
               Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);

            modelBuilder.Entity<User>().Property(x => x.Address1).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<User>().Property(x => x.Address2).HasMaxLength(100);

            modelBuilder.Entity<User>().Property(x => x.City).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().Property(x => x.State).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().Property(x => x.Country).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().Property(x => x.PinCode).IsRequired().HasMaxLength(10);

            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.Role).HasConversion<string>();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>().HasIndex(x => x.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Custumer>(entity =>
            {
                entity.HasKey(x => x.Id);



                entity.Property(x => x.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(x => x.Email)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(x => x.PhoneNumber)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(x => x.Notes)
                      .HasMaxLength(500);

                entity.Property(x => x.ProfilePicURL)
                      .HasMaxLength(200);

                entity.Property(x => x.Balance)
                      .IsRequired();


                entity.HasIndex(x => x.Email)
                      .IsUnique();

                entity.HasIndex(x => x.PhoneNumber)
                      .IsUnique();
            });

            modelBuilder.Entity<ShopSetting>(entity =>
            {
                entity.HasKey(x => x.Id);


                entity.Property(x => x.ShopName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(x => x.OwnerName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(x => x.PhoneNumber)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(x => x.GstNumber)
                      .IsRequired()
                      .HasMaxLength(15);


            });

            modelBuilder.Entity<Transaction>(entity =>
            {


                entity.HasKey(x => x.Id);



                entity.Property(x => x.Amount)
                      .IsRequired();

                entity.Property(x => x.Description)
                      .IsRequired(false)
                      .HasMaxLength(500);

                entity.Property(x => x.TransactionType)
                      .IsRequired()
                      .HasConversion<string>();


            });

        }
    }
}
