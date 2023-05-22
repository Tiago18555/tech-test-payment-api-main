using Microsoft.EntityFrameworkCore;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto;
using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Data;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Repositories.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            try
            {
                this._context.Products.AddRange(product);
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return await _context.Products.FindAsync(product.Id);
        }

        public List<T> AddRange<T>(Func<Product, T> predicate, params Product[] product)
        {
            this._context.Products.AddRange(product);

            try
            {
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return _context
                .Products
                .Select(predicate)
                .ToList();
        }

        public async Task<List<T>> GetAll<T>(Func<Product, T> predicate)
        {
            return await Task.FromResult(_context.Products
                .Include(x => x.ProductSells)
                .Select(predicate)
                .ToList());
        }

        public Product GetById(long id)
        {
            return _context.Products
                .Where(x => x.Id == id)
                .First();
        }
    }
}
