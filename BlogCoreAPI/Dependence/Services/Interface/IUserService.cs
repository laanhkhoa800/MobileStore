
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services.Interface
{
    public interface IUserService 
    {
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetAllUserBySearch(string search);
        User GetUserById(int id);
        IEnumerable<User> GetUserByStatus(int status);
        User GetUser(string email, string passwork);
        void ChangeStatus(User user);

        void AddNewUser(User user);
        void UpdateUser(User user);
        void ChangeIsDelete(User user);

        void Save();

    }
}
