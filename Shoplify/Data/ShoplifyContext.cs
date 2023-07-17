using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoplify.Models;

namespace Shoplify.Data
{
    public class ShoplifyContext : DbContext
    {
        public ShoplifyContext (DbContextOptions<ShoplifyContext> options)
            : base(options)
        {
        }

        public DbSet<Shoplify.Models.Products> Products { get; set; } = default!;
        public DbSet<Shoplify.Models.Cart> Cart { get; set; } = default!;
        public DbSet<Shoplify.Models.Users> Users { get; set; } = default!;

    }
}
