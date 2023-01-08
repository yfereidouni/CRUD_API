using CRUD_API.Models.Contacts;
using CRUD_API.Models.Locations;
using CRUD_API.Models.Phones;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.SQL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<Phone>? Phones { get; set; }
    public DbSet<PhoneType>? PhoneTypes { get; set; }
    public DbSet<Location>? Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //modelBuilder.Entity<Phone>()
        //    .HasKey(e => new { e.AId, e.BId });

        //modelBuilder.Entity<Phone>()
        //    .HasOne(e => e.PhoneType)
        //    .WithMany(e => e.)
        //    .HasForeignKey(e => e.AId)
        //    .OnDelete(DeleteBehavior.Cascade); // <= This entity has cascading behaviour on deletion

        //modelBuilder.Entity<AB>()
        //    .HasOne(e => e.B)
        //    .WithMany(e => e.ABs)
        //    .HasForeignKey(e => e.BId)
        //    .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion


        //modelBuilder.Entity<Phone>().HasKey(p => new { p.ContactId, p.PhoneTypeId });

        //modelBuilder.Entity<Phone>()
        //    .HasOne<PhoneType>(sc => sc.PhoneType)
        //    .WithMany(s => s.Phones)
        //    .HasForeignKey(sc => sc.PhoneTypeId);


        //modelBuilder.Entity<Phone>()
        //    .HasOne<Contact>(sc => sc.Contact)
        //    .WithMany(s => s.Phones)
        //    .HasForeignKey(sc => sc.ContactId);

        //modelBuilder.Entity<Contact>()
        //    .HasMany(c => c.Phones)
        //    .WithOne(e => e.Contact).
        //    .IsRequired();

        //modelBuilder.Entity<Location>()
        //    .HasMany(c => c.Contacts)
        //    .WithOne(e => e.Location).
        //    .IsRequired();

        //modelBuilder.Entity<PhoneType>()
        //    .HasMany(c => c.Phones)
        //    .WithOne(e => e.PhoneType).
        //    .IsRequired();


        //modelBuilder.Entity<Phone>()
        //    .HasOne(pt => pt.PhoneType)
        //    .WithMany(c => c.Phones)
        //    .HasForeignKey(pt => pt.PhoneTypeId);

        //modelBuilder.Entity<Phone>()
        //    .HasOne(c => c.Contact)
        //    .WithMany(ph => ph.Phones)
        //    .HasForeignKey(c => c.ContactId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Contact>()
        //    .HasOne(l => l.Location)
        //    .WithMany(c => Contacts)
        //    .HasForeignKey(c => c.LocationId)
        //    .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
