using Application.Dtos;
using Domain;
using Infrastructure.Repositories.Custumers;

namespace Application.Custumers
{
    public class CustumerApplication : ICustumerApplication
    {
        private readonly ICustumerRepository _custumerRepository;
        public CustumerApplication(ICustumerRepository custumerRepository)
        {
            _custumerRepository = custumerRepository;
        }
        public  async Task Add(CreateUpdateCustomerDto input)
        {
            Custumer custumer = new Custumer
            {
                Name = input.Name,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Notes = input.Notes,
                Balance = input.Balance,
                ProfilePicURL = input.ProfilePicURL
            };
            await _custumerRepository.Add(custumer);
        }

        public async Task Delete(int id)
        {
             await _custumerRepository.Delete(id);
        }

        public async Task<List<CustumerDto>> GetAll()
        {
           var custumers = await _custumerRepository.GetAll();
            return custumers.Select(c => new CustumerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Notes = c.Notes,
                Balance = c.Balance,
                ProfilePicURL = c.ProfilePicURL
            }).ToList();
        }

        public  async Task<CustumerDto> GetById(int id)
        {
            var custumer =  await _custumerRepository.GetById(id);
           var custumerDto = new CustumerDto
            {
                Id = custumer.Id,
                Name = custumer.Name,
                Email = custumer.Email,
                PhoneNumber = custumer.PhoneNumber,
                Notes = custumer.Notes,
                Balance = custumer.Balance,
                ProfilePicURL = custumer.ProfilePicURL
            };
            return custumerDto;

        }
        

        public Task Update(int id, CreateUpdateCustomerDto input)
        {
           var custumer = new Custumer
            {
                Id = id,
                Name = input.Name,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Notes = input.Notes,
                Balance = input.Balance,
                ProfilePicURL = input.ProfilePicURL
            };
            return _custumerRepository.Update(custumer);
        }
    }
}
