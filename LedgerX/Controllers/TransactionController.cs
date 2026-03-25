using Application.Dtos;
using Application.Transactions;
using Infrastructure;
using Infrastructure.Repositories.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionsApplication _transactionsApplication;

        public TransactionController(ITransactionsApplication transactionsApplication)
        {
            _transactionsApplication = transactionsApplication;
        }

        [HttpGet]
        public async Task<ActionResult<TransactionDto>> GetTransactions()
        {
            try
            {
                var transactions = await _transactionsApplication.GetAll();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddTransaction(CreateUpdateTransactionDto transactionDto)
        {
            try
            {
                await _transactionsApplication.Add(transactionDto);
                return Ok();
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
                var existingTransaction = await _transactionsApplication.GetById(id);
                if (existingTransaction == null)
                {
                    return NotFound();
                }

                await _transactionsApplication.Update(id, transactionDto);
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
                await _transactionsApplication.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetTransactionById(int id)
        {
            try
            {
                var transaction = await _transactionsApplication.GetById(id);
                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }

        }
    }
}
