using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Products;
using Domain.Entities;
using Persistence;

namespace Application
{
    public interface IUnitOfWork
    {
        IProductService ProductService { get; }
        Task<int> SaveChangeAsync();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            ProductService = new ProductService(context);
        }

        public IProductService ProductService { get; private set; }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
