using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Dto;
using DotNetCore.Results;

namespace Application.User
{
   public interface IUserService
    {
        Task<IResult<long>> AddAsync(RegisterDto model);

        Task<IResult> DeleteAsync(long id);

        Task<UserModel> GetAsync(long id);
        string GetUsername();


    }
}
