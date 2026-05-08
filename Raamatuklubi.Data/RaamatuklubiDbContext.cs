using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raamatuklubi.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Raamatuklubi.Data
{
    public class RaamatuklubiDbContext : IdentityDbContext<ApplicationUser>
    {
        public RaamatuklubiDbContext(DbContextOptions<RaamatuklubiDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
