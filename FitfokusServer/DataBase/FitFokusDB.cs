using FitfokusServer.Models.DomainObjects.Responses;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitfokusServer.DataBase;

    public class FitFokusDB : DbContext
    {
        public FitFokusDB(DbContextOptions<FitFokusDB> options)
            : base(options)
        {
        }
    public DbSet<User> Users { get; set; } = default!;

    }

