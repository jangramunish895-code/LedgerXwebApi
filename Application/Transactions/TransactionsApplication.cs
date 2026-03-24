using Application.Dtos;

using Domain;
using Infrastructure.Repositories.Transactions;

namespace Application.Transactions
{
    public class TransactionsApplication : ITransactionsApplication

    {
        private readonly ITransactionRepository _transactionsRepository;
      

        public TransactionsApplication(ITransactionRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
           
        }

        public async Task Add(CreateUpdateTransactionDto input)
        {
            Transaction transactions = new Transaction
            {
                CustomerId = input.CustomerId,
                TransactionType = input.TransactionType,
                Amount = input.Amount,
                Description = input.Description
            };

            await _transactionsRepository.Add(transactions);
        }
        public  async Task Delete(int id)
        {
           await _transactionsRepository.DeleteById(id);
        }

        public async Task<List<TransactionDto>> GetAll()
        {
            var transactions = await _transactionsRepository.GetAll();
            return transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                CustomerId = t.CustomerId,
                TransactionType = t.TransactionType,
                Amount = t.Amount,
                Description = t.Description
            }).ToList();
        }

        public async Task<TransactionDto> GetById(int id)
        {
            var transaction = await _transactionsRepository.GetById(id);
            return new TransactionDto
            {
                Id = transaction.Id,
                CustomerId = transaction.CustomerId,
                TransactionType = transaction.TransactionType,
                Amount = transaction.Amount,
                Description = transaction.Description
            };
        }

        public Task Update(int id, CreateUpdateTransactionDto input)
        {
            var transaction = new Transaction
            {
                Id = id,
                CustomerId = input.CustomerId,
                TransactionType = input.TransactionType,
                Amount = input.Amount,
                Description = input.Description
            };
            return _transactionsRepository.Update(transaction);
        }
    }
}
