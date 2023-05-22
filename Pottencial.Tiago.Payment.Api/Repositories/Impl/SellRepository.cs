using Microsoft.EntityFrameworkCore;
using Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda;
using Pottencial.Tiago.Payment.Api.Application.UseCases.BuscarVenda;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda;
using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Data;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Repositories.Impl
{
    public class SellRepository : ISellRepository
    {
        private readonly DataContext _context;

        public SellRepository(DataContext context)
        {
            _context = context;
        }

        public CreateOrderResponseModel Add(Sell sell)
        {
            try
            {
                this._context.Sells.Add(sell);
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
                //return GenericResponses.ServiceUnavailable();
            }

            return _context
                .Sells
                .Include(x => x.Seller)
                .Include(x => x.ProductSells)
                .ThenInclude(x => x.Product)
                .Where(x => x.Id == sell.Id)
                .Select(x => x.MapObjectTo(new CreateOrderResponseModel())) 
                .FirstOrDefault();
        }

        public async Task<List<FindOrderResponseModel>> GetAll()
        {
            return await _context
                .Sells
                .Include(x => x.Seller)
                .Include(x => x.ProductSells)
                .ThenInclude(x => x.Product)
                .Select(x => x.MapObjectTo(new FindOrderResponseModel()))
                .ToListAsync();
        }        

        public FindOrderResponseModel GetById(long id)
        {
            return _context
                .Sells
                .Include(x => x.Seller)
                .Include(x => x.ProductSells)
                .ThenInclude(x => x.Product)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => x.MapObjectTo(new FindOrderResponseModel()))
                .FirstOrDefault();
        }

        public UpdateOrderResponseModel Update(Sell sell)
        {
            try
            {
                _context.Sells.Update(sell);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            var res = _context
                .Sells
                .Where(x => x.Id == sell.Id)
                .Select(x => x.MapObjectTo(new UpdateOrderResponseModel()))
                .FirstOrDefault();

            return res;
        }
    }

}
