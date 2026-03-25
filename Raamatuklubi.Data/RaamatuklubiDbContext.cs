using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raamatuklubi.Data
{
    public class RaamatuklubiDbContext : DbContext
    {
        public RaamatuklubiDbContext(DbContextOptions<RaamatuklubiDbContext> options) : base(options) { }
    }
}
