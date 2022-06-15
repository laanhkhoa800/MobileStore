using Ardalis.Specification;
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Specifications
{
    public class UserSpecification : Specification<User>
    {
        public UserSpecification(bool isDelete)
        {
            Query.Where(item => item.IsDelete.Equals(false));
        }
    }
    public class MailUserSpecification : Specification<User>
    {
        public MailUserSpecification(User user)
        {
            Query.Where(item => item.Email == user.Email);
        }
    }
}
