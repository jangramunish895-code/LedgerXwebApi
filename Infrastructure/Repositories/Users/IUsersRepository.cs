using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Users
{
    public interface IUsersRepository
    {
        public Task Add(User user);
        public Task<User> GetById(int id);
       public Task<List<User>> GetAll();
        public Task Update(User user);
        public Task DeleteById(int id);
    }
}
