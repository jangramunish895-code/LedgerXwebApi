using Application.Dtos;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _context;

        public TransactionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<TransactionDto>> GetTransactions()
        {
            try
            {
                var transactions = await _context.Transactions
                    .Select(t => new TransactionDto
                    {
                        Id = t.Id,
                        CustomerId = t.CustomerId,
                        TransactionType = t.TransactionType,
                        Amount = t.Amount,
                        Description = t.Description
                    })
                    .ToListAsync();
                return Ok(transactions);

            }
            catch (Exception ex)
            {

                return StatusCode(400, "An error occurred ");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateUpdateTransactionDto>> AddTransaction(CreateUpdateTransactionDto transactionDto)
        {
            try
            {
                var transaction = new Domain.Transaction
                {
                    CustomerId = transactionDto.CustomerId,
                    TransactionType = transactionDto.TransactionType,
                    Amount = transactionDto.Amount,
                    Description = transactionDto.Description
                };
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                return Ok(transactionDto);
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }


        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CreateUpdateTransactionDto>> UpdateTransaction(int id, CreateUpdateTransactionDto transactionDto)
        {
            try
            {
                var existingTransaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
                if (existingTransaction == null)
                {
                    return NotFound();
                }

                existingTransaction.CustomerId = transactionDto.CustomerId;
                existingTransaction.TransactionType = transactionDto.TransactionType;
                existingTransaction.Amount = transactionDto.Amount;
                existingTransaction.Description = transactionDto.Description;

                await _context.SaveChangesAsync();
                return Ok(transactionDto);
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            try
            {
                var transaction = await _context.Transactions.FindAsync(id);
                if (transaction == null)
                {
                    return NotFound();
                }
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }
        }

    }
}
