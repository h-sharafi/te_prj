using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using System.Threading.Tasks;
using Application.Core;
using Domain.Models.Dto;
using DotNetCore.Results;

namespace Application.Products
{
    public interface IProductService : IGenericRepository<Product>
    {
        Task<IResult<PagedList<Product>>> ProductSearch(ProductSearchDto productSearch , PagingParams pagingParams);
        Task<IResult<PagedList<Product>>> GetProducts(PagingParams pagingParams);
    }
}
