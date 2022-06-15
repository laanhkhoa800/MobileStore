using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetBySearch(string search);
        IEnumerable<User> GetByStatus(int status);

        IEnumerable<User> CheckEmail(string email);

        User GetUser(string email, string passwork);
    }
}
