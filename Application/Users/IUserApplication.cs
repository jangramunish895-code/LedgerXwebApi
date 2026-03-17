using Application.Dtos;
using Domain;
using Infrastructure.Repositories.Users;

namespace Application.Users
{
    public interface IUserApplication
    {
        public Task Add(CreateUpdateUserDto input);

        public Task Update(int id, CreateUpdateUserDto input);
        public Task Delete(int id);
        public Task<List<UserDto>> GetAll();
        public Task<UserDto> GetById(int id);
       
    }
}
