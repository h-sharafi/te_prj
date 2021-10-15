using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Dto;
using DotNetCore.Results;
using DotNetCore.Validation;

namespace Application.User
{
    public class UserService : IUserService
    {
        public Task<IResult<long>> AddAsync(RegisterDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public string GetUsername()
        {
            throw new NotImplementedException();
        }
    }
}
