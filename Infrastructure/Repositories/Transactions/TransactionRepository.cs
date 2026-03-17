using Domain;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly DataContext _context;
        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Transaction input)
        {
         _context.Transactions.Add(input);
            await _context.SaveChangesAsync();
        }

       

        public async Task DeleteById(int id)
        {
          var transaction =  _context.Transactions.Find(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Transaction>> GetAll()
        {
          return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetById(int id)
        {
           return await _context.Transactions.FindAsync(id);
        }

        public async Task Update(Transaction transaction)
        {
          _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
