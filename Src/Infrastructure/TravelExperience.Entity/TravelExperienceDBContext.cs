using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelExperience.Entity.Entity;

namespace TravelExperience.DbContextClass
{
    public class TravelExperienceDBContext : DbContext
    {
        public TravelExperienceDBContext(DbContextOptions<TravelExperienceDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TravelerProfileEntity> TravelerProfiles { get; set; }
        public DbSet<HostProfileEntity> HostProfiles { get; set; }
        public DbSet<ExperienceEntity> Experiences { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<SavedExperienceEntity> SavedExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.TravelerProfile)
                      .WithOne(e => e.User)
                      .HasForeignKey<TravelerProfileEntity>(e => e.UserId);

                entity.HasOne(e => e.HostProfile)
                        .WithOne(e => e.User)
                        .HasForeignKey<HostProfileEntity>(e => e.UserId);
            });

            modelBuilder.Entity<TravelerProfileEntity>(entity =>
            {
                entity.ToTable("TravelerProfile");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Country).IsRequired().HasMaxLength(100);
                entity.Property(e => e.City).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.AvatarUrl).HasMaxLength(500);
                entity.Property(e => e.Bio).HasMaxLength(1000);
                entity.Property(e => e.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.User)
                      .WithOne(e => e.TravelerProfile)
                      .HasForeignKey<TravelerProfileEntity>(e => e.UserId);

                entity.HasMany(e => e.Bookings);

                entity.HasMany(e => e.SavedExperiences);

            });

            modelBuilder.Entity<HostProfileEntity>(entity =>
            {
                entity.ToTable("HostProfile");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.DisplayName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.BusinessName).HasMaxLength(200);
                entity.Property(e => e.Country).IsRequired().HasMaxLength(100);
                entity.Property(e => e.City).IsRequired().HasMaxLength(100);
                entity.Property(e => e.AvatarUrl).HasMaxLength(500);
                entity.Property(e => e.WebsiteUrl).HasMaxLength(500);
                entity.Property(e => e.Bio).HasMaxLength(1000);
                entity.Property(e => e.IsVerified).IsRequired().HasDefaultValue(false);
                entity.Property(e => e.Rating).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.TotalReviews).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
               
                entity.HasOne(e => e.User)
                      .WithOne(e => e.HostProfile)
                      .HasForeignKey<HostProfileEntity>(e => e.UserId);
                
                entity.HasMany(e => e.HostedExperiences);
            });

            modelBuilder.Entity<ExperienceEntity>(entity =>
            {
                entity.ToTable("Experience");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(2000);
                entity.Property(e => e.Location).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Information).HasColumnType("NVARCHAR(MAX)");
                entity.Property(e => e.PricePerPerson).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.MaxParticipants).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.DurationInHours).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.Rating).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.TotalReviews).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.ImagesUrls).HasColumnType("NVARCHAR(MAX)");
                entity.Property(e => e.TotalBookings).IsRequired().HasDefaultValue(0);

                entity.HasOne(e => e.HostProfile)
                      .WithMany(e => e.HostedExperiences)
                      .HasForeignKey(e => e.HostProfileId);

            });

            modelBuilder.Entity<BookingEntity>(entity =>
            {
                entity.ToTable("Booking");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.BookingDate).IsRequired();
                entity.Property(e => e.NumberOfGuests).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50).HasDefaultValue("Pending");
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.ConfirmedAt);
                entity.Property(e => e.CancelledAt);

                entity.HasOne(e => e.TravelerProfile)
                      .WithMany(t => t.Bookings)
                      .HasForeignKey(e => e.TravelerProfileId);
                    
                entity.HasOne(e => e.Experience)
                      .WithMany(x => x.Bookings)
                      .HasForeignKey(e => e.ExperienceId);
                                
            });

            modelBuilder.Entity<SavedExperienceEntity>(entity =>
            {
                entity.ToTable("SavedExperience");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().HasDefaultValueSql("NEWID()");
                entity.Property(e => e.SavedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.TravelerProfile)
                      .WithMany(e => e.SavedExperiences)
                      .HasForeignKey(e => e.TravelerProfileId);

                entity.HasOne( e => e.Experience)
                      .WithMany(e => e.SavedByTravelers)
                      .HasForeignKey(entity => entity.ExperienceId); 



            });

        }

    }
}
