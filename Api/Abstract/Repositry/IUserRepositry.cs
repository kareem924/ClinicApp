using Abstract.Entities;
using Framework.UnitOfWork;

namespace Abstract.Repositry
{
    public interface IUserRepositry:IBasicRepositrory<Users>
    {
        Users Get(string userName, string hashedPassword);
        Users Get(string email);

    }
}