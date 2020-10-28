using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApplication.Entities;

namespace TestApplication.Context
{
  public class TestApplicationContext : DbContext
  {
    public TestApplicationContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<GiftCard> GiftCards { get; set; }
  }
}
