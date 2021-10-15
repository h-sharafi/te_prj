using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Core;
using Domain.Entities;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] PagingParams param)
        {
            return HandelPageResult(await _unitOfWork.ProductService.GetProducts(param));

        }
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductSearch([FromQuery] ProductSearchDto productSearch)
        {
            return HandelPageResult(await _unitOfWork.ProductService.ProductSearch(productSearch, new PagingParams
            {
                PageNumber = productSearch.PageNumber,
                pageSize = productSearch.PageSize
            }));

        }
    }
}
