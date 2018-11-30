using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract.Entities;
using Framework.Models.Result;

namespace Abstract.Service
{
    public interface IUserService
    {
         Task<List<Users>> GetPagedUsers(int skip,int take);
         Task<ValidationResult> Add(UserDto model);
         Task<ValidationResult> Update(UserDto model);
         Task<ValidationResult> Delete(int id);
         Task<UserDto> GetById(int id);

    }
}