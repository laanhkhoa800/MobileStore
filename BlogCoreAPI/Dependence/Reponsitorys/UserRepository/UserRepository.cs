using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private ApContext _apContext;
        public UserRepository(ApContext context) : base(context)
        {
            _apContext = context;
        }


        public IEnumerable<User> CheckEmail(string email)
        {
          return  _apContext.users.Where(u => u.Email.Contains(email));
        }

        public IEnumerable<User> GetBySearch(string search)
        {
            return _apContext.users.Where(u => u.IsDelete.Equals(false) && u.FirstName.Contains(search) || u.LastName.Contains(search) || u.Email.Contains(search) || u.Address.Contains(search) || u.NumberPhone.Contains(search));  
        }

        public IEnumerable<User> GetByStatus(int status)
        {
            return _apContext.users.Where(u => u.StatusUserId == status);
        }

        public   User GetUser(string email, string passwork)
        {
            return   _apContext.users.FirstOrDefault(u => u.Email == email && u.Passwork == passwork && u.StatusUserId == 1 && u.IsDelete == false);
        }
    }
}
