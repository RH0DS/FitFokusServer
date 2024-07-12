using FitfokusServer.Models.DomainObjects;
using FitfokusServer.Models.DomainObjects.MessageBoard;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitfokusServer.DataBase;

public class FitFokusDB : DbContext
{
    public FitFokusDB(DbContextOptions<FitFokusDB> options) : base(options)
    {

    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Result> Results => Set<Result>();
    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<Message> Messages => Set<Message>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Specify ON DELETE NO ACTION or ON DELETE SET NULL if desired

        // Other entity configurations...

        base.OnModelCreating(modelBuilder);
    }
}

