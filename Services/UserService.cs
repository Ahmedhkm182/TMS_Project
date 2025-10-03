using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.APP.Interface;
using TMS.Core.Entities;
using TMS.Infa.Repository;

namespace TMS.APP.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
            => await _repository.GetAllAsync();

        public async Task<User?> GetUserByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<User> CreateUserAsync(User user)
        {
            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _repository.UpdateAsync(user);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var users = await _repository.GetAllAsync();
            return users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }
    }
}
