using System;
using System.Collections.Generic;
using System.Text;
using BullsAndCows.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BullsAndCows.Data
{
    public class BACContext:IdentityDbContext<User>
    {
        public BACContext(DbContextOptions<BACContext> dbContextOptions)
            :base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Guess>().HasOne(a => a.GuessOutcome).WithOne(a => a.Guess).
                HasForeignKey<Guess>(a => a.GuessOutcomeId).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Guess>().HasOne(a => a.Game).WithMany(a => a.Guesses).
                HasForeignKey(a => a.GameId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Guess>().HasOne(a => a.GuessOutcome).WithOne(a => a.Guess).
                HasForeignKey<Guess>(a => a.GuessOutcomeId).OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Guess> Guesses { get; set; }

    }
}
