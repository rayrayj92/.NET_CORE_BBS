using esu_v.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace esu_v.Infrastructure
{
    public class EsuContext : IdentityDbContext<AdminUser>
    {
        public EsuContext(DbContextOptions<EsuContext> options) : base(options) { }
        public DbSet<Board> Boards { get; set; }
    }
}
