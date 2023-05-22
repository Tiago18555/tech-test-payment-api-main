using Microsoft.EntityFrameworkCore;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVendedor;
using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Data;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Repositories.Impl
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DataContext _context;

        public SellerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<RegisterSellerResponseModel> Add(Seller seller)
        {
            this._context.Sellers.Add(seller);

            try
            {
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
                //return GenericResponses.ServiceUnavailable();
            }

            return await _context.Sellers
                .Where(x => x.Id == seller.Id)
                .Select(x => x.MapObjectTo(new RegisterSellerResponseModel()))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RegisterSellerResponseModel>> AddRange(params Seller[] seller)
        {
            this._context.Sellers.AddRange(seller);

            try
            {
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
                //return GenericResponses.ServiceUnavailable();
            }

            return await _context.Sellers
                .Select(x => x.MapObjectTo(new RegisterSellerResponseModel()))
                .ToListAsync();
        }

        public async Task<List<RegisterSellerResponseModel>> GetAll()
        {
            return await _context.Sellers
                .Select(x => x.MapObjectTo(new RegisterSellerResponseModel()))
                .ToListAsync();
        }

        public Seller GetById(long id)
        {
            return _context.Sellers.Find(id);
        }
    }
}
