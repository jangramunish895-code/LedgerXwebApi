using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transactions
{
    public interface ITransactionsApplication
    {
        public Task Add(CreateUpdateTransactionDto input);

        public Task Update(int id, CreateUpdateTransactionDto input);
        public Task Delete(int id);
        public Task<List<TransactionDto>> GetAll();
        public Task<TransactionDto> GetById(int id);

    }
}
