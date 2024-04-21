using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<BodyInformation> BodyInformations { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDocumentation> CarDocumentations { get; set; }
    public DbSet<CarPhoto> CarPhotos { get; set; }
    public DbSet<CarReview> CarReviews { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessagePhoto> MessagePhotos { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Propietary> Propietaries { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Tables
        builder.Entity<BodyInformation>().ToTable("BodyInformations");
        builder.Entity<BodyInformation>().HasKey(p=>p.Id);
        builder.Entity<BodyInformation>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<BodyInformation>().Property(p=>p.Text).IsRequired().HasMaxLength(5000);
        builder.Entity<BodyInformation>().Property(p=>p.Date).IsRequired().HasMaxLength(10);
        builder.Entity<BodyInformation>().Property(p=>p.Time).IsRequired().HasMaxLength(10);
        
        builder.Entity<Car>().ToTable("Cars");
        builder.Entity<Car>().HasKey(p=>p.Id);
        builder.Entity<Car>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Car>().Property(p=>p.Plate).IsRequired().HasMaxLength(6);
        builder.Entity<Car>().Property(p=>p.Brand).IsRequired().HasMaxLength(25);
        builder.Entity<Car>().Property(p=>p.Model).IsRequired().HasMaxLength(25);
        builder.Entity<Car>().Property(p=>p.YearManufactured).IsRequired().HasMaxLength(4);
        builder.Entity<Car>().Property(p=>p.FuelType).IsRequired().HasMaxLength(25);
        builder.Entity<Car>().Property(p=>p.Transmission).IsRequired().HasMaxLength(25);
        builder.Entity<Car>().Property(p=>p.Category).IsRequired().HasMaxLength(25);
        builder.Entity<Car>().Property(p=>p.PassengerCapacity).IsRequired().HasMaxLength(2);
        builder.Entity<Car>().Property(p=>p.Color).IsRequired().HasMaxLength(25);
        builder.Entity<Car>().Property(p=>p.Mileage).IsRequired().HasMaxLength(6);
        builder.Entity<Car>().Property(p=>p.Condition).IsRequired().HasMaxLength(25);
        builder.Entity<Car>().Property(p=>p.Price).IsRequired();
        builder.Entity<Car>().Property(p=>p.AC);
        builder.Entity<Car>().Property(p=>p.GPS);
        builder.Entity<Car>().Property(p=>p.Location).IsRequired().HasMaxLength(200);
        builder.Entity<Car>().Property(p=>p.Status).IsRequired().HasMaxLength(25);
        
        builder.Entity<CarDocumentation>().ToTable("CarDocumentations");
        builder.Entity<CarDocumentation>().HasKey(p=>p.Id);
        builder.Entity<CarDocumentation>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CarDocumentation>().Property(p=>p.CarDocumentationPhotoURL).IsRequired().HasMaxLength(5000);
        
        builder.Entity<CarPhoto>().ToTable("CarPhotos");
        builder.Entity<CarPhoto>().HasKey(p=>p.Id);
        builder.Entity<CarPhoto>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CarPhoto>().Property(p=>p.CarPhotoURL).IsRequired().HasMaxLength(5000);
        
        builder.Entity<CarReview>().ToTable("CarReviews");
        builder.Entity<CarReview>().HasKey(p=>p.Id);
        builder.Entity<CarReview>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CarReview>().Property(p=>p.Score).IsRequired();
        
        builder.Entity<Destination>().ToTable("Destinations");
        builder.Entity<Destination>().HasKey(p=>p.Id);
        builder.Entity<Destination>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Destination>().Property(p=>p.Issuer).IsRequired().HasMaxLength(25);
        builder.Entity<Destination>().Property(p=>p.Category).IsRequired().HasMaxLength(25);
        
        builder.Entity<Message>().ToTable("Messages");
        builder.Entity<Message>().HasKey(p=>p.Id);
        builder.Entity<Message>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<MessagePhoto>().ToTable("MessagePhotos");
        builder.Entity<MessagePhoto>().HasKey(p=>p.Id);
        builder.Entity<MessagePhoto>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MessagePhoto>().Property(p=>p.PhotoURL).IsRequired().HasMaxLength(5000);
        
        builder.Entity<Notification>().ToTable("Notifications");
        builder.Entity<Notification>().HasKey(p=>p.Id);
        builder.Entity<Notification>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Propietary>().ToTable("Propietaries");
        builder.Entity<Propietary>().HasKey(p=>p.Id);
        builder.Entity<Propietary>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Propietary>().Property(p=>p.ContractURL).IsRequired().HasMaxLength(5000);
        
        builder.Entity<Rent>().ToTable("Rents");
        builder.Entity<Rent>().HasKey(p=>p.Id);
        builder.Entity<Rent>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Rent>().Property(p=>p.StartDate).IsRequired().HasMaxLength(10);
        builder.Entity<Rent>().Property(p=>p.EndDate).IsRequired().HasMaxLength(10);
        builder.Entity<Rent>().Property(p=>p.SignedContractURL).IsRequired().HasMaxLength(5000);
        builder.Entity<Rent>().Property(p=>p.Status).IsRequired().HasMaxLength(25);
        
        builder.Entity<Request>().ToTable("Requests");
        builder.Entity<Request>().HasKey(p=>p.Id);
        builder.Entity<Request>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Request>().Property(p=>p.Status).IsRequired().HasMaxLength(25);
        builder.Entity<Request>().Property(p=>p.SubmissionDate).IsRequired().HasMaxLength(10);
        builder.Entity<Request>().Property(p=>p.TotalPrice).IsRequired();
        
        builder.Entity<Review>().ToTable("Reviews");
        builder.Entity<Review>().HasKey(p=>p.Id);
        builder.Entity<Review>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(p=>p.Score).IsRequired();
        
        builder.Entity<Tenant>().ToTable("Tenants");
        builder.Entity<Tenant>().HasKey(p=>p.Id);
        builder.Entity<Tenant>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tenant>().Property(p=>p.LicenceNumber).IsRequired().HasMaxLength(5000);
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p=>p.Id);
        builder.Entity<User>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p=>p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(p=>p.Email).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(p=>p.Password).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p=>p.PhoneNumber).IsRequired().HasMaxLength(9);
        builder.Entity<User>().Property(p=>p.DNI).IsRequired().HasMaxLength(8);
        builder.Entity<User>().Property(p=>p.PhotoURL).HasMaxLength(5000);
        builder.Entity<User>().Property(p=>p.Type).IsRequired().HasMaxLength(25);
        
        //Relationships
        builder.Entity<BodyInformation>()
            .HasOne(p=>p.CarReview)
            .WithOne(p=>p.BodyInformation)
            .HasForeignKey<CarReview>(p=>p.BodyInformationId);
        builder.Entity<BodyInformation>()
            .HasOne(p => p.Message)
            .WithOne(p => p.BodyInformation)
            .HasForeignKey<Message>(p => p.BodyInformationId);
        builder.Entity<BodyInformation>()
            .HasOne(p => p.Notification)
            .WithOne(p => p.BodyInformation)
            .HasForeignKey<Notification>(p => p.BodyInformationId);
        builder.Entity<BodyInformation>()
            .HasOne(p => p.Review)
            .WithOne(p => p.BodyInformation)
            .HasForeignKey<Review>(p => p.BodyInformationId);
        
        builder.Entity<Car>()
            .HasMany(p=>p.CarDocumentations)
            .WithOne(p=>p.Car)
            .HasForeignKey(p=>p.CarId);
        builder.Entity<Car>()
            .HasMany(p => p.CarPhotos)
            .WithOne(p => p.Car)
            .HasForeignKey(p => p.CarId);
        builder.Entity<Car>()
            .HasMany(p => p.Requests)
            .WithOne(p => p.Car)
            .HasForeignKey(p => p.CarId);
        builder.Entity<Car>()
            .HasMany(p => p.CarReviews)
            .WithOne(p => p.Car)
            .HasForeignKey(p => p.CarId);

        builder.Entity<CarReview>()
            .HasOne(p => p.Tenant)
            .WithMany(p => p.CarReviews)
            .HasForeignKey(p => p.TenantId);
        
        builder.Entity<Destination>()
            .HasOne(p=>p.Message)
            .WithOne(p=>p.Destination)
            .HasForeignKey<Message>(p=>p.DestinationId);
        builder.Entity<Destination>()
            .HasOne(p => p.Review)
            .WithOne(p => p.Destination)
            .HasForeignKey<Review>(p => p.DestinationId);
        
        builder.Entity<Message>()
            .HasMany(p=>p.MessagePhotos)
            .WithOne(p=>p.Message)
            .HasForeignKey(p=>p.MessageId);
        
        builder.Entity<Propietary>()
            .HasMany(p=>p.Cars)
            .WithOne(p=>p.Propietary)
            .HasForeignKey(p=>p.PropietaryId);
        builder.Entity<Propietary>()
            .HasMany(p => p.Destinations)
            .WithOne(p => p.Propietary)
            .HasForeignKey(p => p.PropietaryId);
        builder.Entity<Propietary>()
            .HasMany(p => p.Requests)
            .WithOne(p => p.Propietary)
            .HasForeignKey(p => p.PropietaryId);
        
        builder.Entity<Request>()
            .HasOne(p=>p.Rent)
            .WithOne(p=>p.Request)
            .HasForeignKey<Rent>(p=>p.RequestId);
        
        builder.Entity<Tenant>()
            .HasMany(p=>p.Destinations)
            .WithOne(p=>p.Tenant)
            .HasForeignKey(p=>p.TenantId);
        builder.Entity<Tenant>()
            .HasMany(p => p.Requests)
            .WithOne(p => p.Tenant)
            .HasForeignKey(p => p.TenantId);
        
        builder.Entity<User>()
            .HasOne(p=>p.Propietary)
            .WithOne(p=>p.User)
            .HasForeignKey<Propietary>(p=>p.UserId);
        builder.Entity<User>()
            .HasOne(p => p.Tenant)
            .WithOne(p => p.User)
            .HasForeignKey<Tenant>(p => p.UserId);
        builder.Entity<User>()
            .HasMany(p=>p.Notifications)
            .WithOne(p=>p.User)
            .HasForeignKey(p=>p.UserId);
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}