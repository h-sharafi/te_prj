using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Extensions;
using Application.Core;
using Domain.Entities;
using DotNetCore.Results;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult HandelPageResult<T>(IResult<PagedList<T>> result)
        {
            if (result == null) return NotFound();
            if (result.Succeeded && result.Data != null)
            {
                Response.AddPaginationHeader(result.Data.CurrentPage, result.Data.PageSize, result.Data.TotalCount, result.Data.TotalPage);
                return Ok(result.Data.Items);
            }
            else if (result.Succeeded && result.Data == null)
                return NotFound();
            return BadRequest();
        }
    }
}
