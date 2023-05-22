using Microsoft.EntityFrameworkCore;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Data
{
    public partial class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ProductSell> ProductSells { get; set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }

    }
}
