using FullAzazloUser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAzazloUser.Infrastructure.Data
{
    public class FullAzazloDBContext : DbContext
    {
        public FullAzazloDBContext(DbContextOptions<FullAzazloDBContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
