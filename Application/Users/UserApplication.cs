using Application.Dtos;

using Domain;
using Infrastructure.Repositories.Users;


namespace Application.Users
{
    public class UserApplication : IUserApplication
    {
        private readonly IUsersRepository _userRepository;
    

        public UserApplication(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
          
        }

        public async Task Add(CreateUpdateUserDto input)
        {
            User user = new User
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Address1 = input.Address1,
                Address2 = input.Address2,
                City = input.City,
                State = input.State,
                Country = input.Country,
                PinCode = input.PinCode,
                Password = input.Password
            };
            await _userRepository.Add(user);
        }

        public  async Task Delete(int id)
        {
            await _userRepository.DeleteById(id);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Role = u.Role.ToString(),
                City = u.City,
                Country = u.Country,
                Address1 = u.Address1,
                Address2= u.Address2,

            }).ToList();
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            var userDto = new UserDto
            { 



               
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country,
                    Role = user.Role.ToString(),
                    Address1 = user.Address1,
                    Address2 = user.Address2
            };
            return userDto;
        }
        public Task Update(int id, CreateUpdateUserDto input)
        {
            var user = new User
            {
                Id = id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Address1 = input.Address1,
                Address2 = input.Address2,
                City = input.City,
                State = input.State,
                Country = input.Country,
                PinCode = input.PinCode,
                Password = input.Password
            };
            return _userRepository.Update(user);
        }


    }
}
