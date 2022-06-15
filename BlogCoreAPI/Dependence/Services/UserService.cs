using BlogCoreAPI.Dependence.Reponsitorys;
using BlogCoreAPI.Dependence.Reponsitorys.UserRepository;
using BlogCoreAPI.Dependence.Services.Interface;
using BlogCoreAPI.Model;
using BlogCoreAPI.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public void AddNewUser(User user)
        {
            /* var complete = _userRepository.CheckEmail(user.Email);
             if(complete == null)
             {
                 user.IsDelete = false;
                 user.CreateAt = DateTime.Now;
                 _userRepository.Inser(user);
                 _userRepository.Save();
             }*/
            user.StatusUserId = 1;
            user.Roles = "User";
            user.IsDelete = false;
            user.CreateAt = DateTime.Now;
            _userRepository.Inser(user);
            _userRepository.Save();
        }

        public void ChangeIsDelete(User user)
        {
            user.IsDelete = !user.IsDelete;
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public void ChangeStatus(User user)
        {
            if(user.StatusUserId == 1)
            {
                user.StatusUserId = 2;
                _userRepository.Update(user);
                _userRepository.Save();
            }
            else
            {
                user.StatusUserId = 1;
                _userRepository.Update(user);
                _userRepository.Save();
            }
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetAllUserBySearch(string search)
        {
            return _userRepository.GetBySearch(search);
        }

        public User GetUser(string email, string passwork)
        {
            return _userRepository.GetUser(email, passwork);
        }

        public User GetUserById(int id)
        {
            var item = _userRepository.GetByID(id);
            var complete = new UserSpecification(item.IsDelete);
            if (complete != null)
            {
                return item;
            }
            return null;
        }

        public IEnumerable<User> GetUserByStatus(int status)
        {
            return _userRepository.GetByStatus(status);
        }

        public void Save()
        {
            _userRepository.Save();
        }

        public void UpdateUser(User user)
        {
            user.UpdateAt = DateTime.Now;
            _userRepository.Update(user);
            _userRepository.Save();
        }
    }
}
