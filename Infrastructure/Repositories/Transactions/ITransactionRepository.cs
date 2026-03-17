


using Domain;

namespace Infrastructure.Repositories.Transactions;

public interface ITransactionRepository
{
    public Task Add(Transaction input);
    public Task<Transaction> GetById(int id);
    public Task<List<Transaction>> GetAll();
    public Task Update(Transaction transaction);
    public Task DeleteById(int id);

  
}
