using Microsoft.EntityFrameworkCore;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Data
{
    public partial class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .HasIndex(s => s.Cpf)
                .IsUnique();
            modelBuilder.Entity<Seller>()
                .HasIndex(s => s.Email)
                .IsUnique();


            modelBuilder.Entity<ProductSell>()
                .HasOne(p => p.Product)
                .WithMany(ps => ps.ProductSells)
                .HasForeignKey(p => p.ProductId);
                //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSell>()
                .HasOne(p => p.Sell)
                .WithMany(ps => ps.ProductSells)
                .HasForeignKey(p => p.SellId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
