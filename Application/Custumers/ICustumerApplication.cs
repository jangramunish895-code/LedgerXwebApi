using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Custumers
{
    public interface ICustumerApplication
    {
        public Task Add(CreateUpdateCustomerDto input);

        public Task Update(int id, CreateUpdateCustomerDto input);
        public Task Delete(int id);
        public Task<List<CustumerDto>> GetAll();
        public Task<CustumerDto> GetById(int id);

    }
}
