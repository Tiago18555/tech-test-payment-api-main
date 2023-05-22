using Microsoft.EntityFrameworkCore;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto;
using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Data;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Repositories.Impl
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductSell> Add(ProductSell item)
        {
            try
            {
                this._context.ProductSells.Add(item);
                this._context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
                //return GenericResponses.ServiceUnavailable();
            }

            return await _context.ProductSells.FindAsync(item.Id);
        }

        public async Task<List<T>> GetAll<T>(Func<ProductSell, T> predicate)
        {
            return await Task.FromResult(_context.ProductSells
                .Include(item => item.Product)
                .Select(predicate)
                .ToList());
        }

        public ProductSell GetById(long id)
        {
            return _context.ProductSells
                .Include(item => item.Product)
                .Where(item => item.Id == id)
                .FirstOrDefault();
        }

        public ProductSell Update(ProductSell sell)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ProductSell> AddRange(params ProductSell[] item)
        {
            this._context.ProductSells.AddRange(item);

            try
            {
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
                //return GenericResponses.ServiceUnavailable();
            }

            return _context.ProductSells.ToList();
        }
    }
}
