using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Domain.Entities;
using Domain.Models.Dto;
using DotNetCore.Results;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class ProductService : GenericRepository<Product>, IProductService
    {

        public ProductService(DataContext context) : base(context) { }


        public async Task<IResult<PagedList<Product>>> ProductSearch(ProductSearchDto productSearch, PagingParams pagingParams)
        {
            IQueryable<Product> query = Query().AsNoTracking().Where(c => c.Color == productSearch.Color && c.Type == productSearch.Type).AsQueryable();
            return Result<PagedList<Product>>.Success(await PagedList<Product>.CreateAsync(query, pagingParams.PageNumber, pagingParams.pageSize));
        }

        public async Task<IResult<PagedList<Product>>> GetProducts(PagingParams pagingParams)
        {
            IQueryable<Product> query = Query().AsNoTracking().AsQueryable();
            PagedList<Product> result = await PagedList<Product>.CreateAsync(query, pagingParams.PageNumber, pagingParams.pageSize);
            return Result<PagedList<Product>>.Success(result);
        }
    }
}
