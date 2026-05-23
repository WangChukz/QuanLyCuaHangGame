using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangGame.DAL.Repositories;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class UserService
    {
        private UnitOfWork unitOfWork;

        public UserService()
        {
            unitOfWork = new UnitOfWork();
        }

        public bool Authenticate(string username, string password)
        {
            var user = unitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.Username == username && u.IsActive);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    SessionContext.CurrentUserId = user.Id;
                    SessionContext.CurrentUserName = user.FullName;
                    SessionContext.CurrentRole = user.Role;
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return unitOfWork.UserRepository.GetAll();
        }

        public void AddUser(User user, string plainPassword)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            user.CreatedAt = DateTime.Now;
            unitOfWork.UserRepository.Insert(user);
            unitOfWork.Save();
        }

        public void UpdateUser(User user)
        {
            unitOfWork.UserRepository.Update(user);
            unitOfWork.Save();
        }

        public void ChangePassword(int userId, string newPlainPassword)
        {
            var user = unitOfWork.UserRepository.GetById(userId);
            if (user != null)
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPlainPassword);
                unitOfWork.Save();
            }
        }
    }
}
