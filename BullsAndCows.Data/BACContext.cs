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
        public DbSet<Game> Games { get; set; }
    }
}
