using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Service;
using Framework.Models.Result;

namespace Application.User
{
    public class UsersService : IUserService
    {
        public Task<ValidationResult> Add(UserDto model)
        {
            throw new System.NotImplementedException();
        }

        public Task<ValidationResult> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Users>> GetPagedUsers(int skip, int take)
        {
            throw new System.NotImplementedException();
        }

        public Task<ValidationResult> Update(UserDto model)
        {
            throw new System.NotImplementedException();
        }
    }
}