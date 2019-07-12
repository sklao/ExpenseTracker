using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using Newtonsoft.Json;
using ExpenseTracker.Services;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseItemController : ControllerBase
    {
        IExpenseItemService _expenseItemService;

        public ExpenseItemController(IExpenseItemService expenseItemService)
        {
            _expenseItemService = expenseItemService ?? throw new ArgumentNullException(nameof(expenseItemService));
        }


        [HttpGet("all")]
        public async Task<IEnumerable<ExpenseItem>> AllExpenseItems() 
        {
            //if (_context.ExpenseItems.Count<ExpenseItem>() == 0)
            //{
            //    return BadRequest();
            //}
            //return _context.ExpenseItems;

            return await _expenseItemService.ReadAllAsync();
        }

        // GET: ExpenseItem
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseItem>> GetExpenseItem(int id)
        {
            //var expenseItem = await _context.ExpenseItems.FindAsync(id);

            //if (expenseItem == null)
            //{
            //    NotFound();
            //}

            //return expenseItem;
            return await _expenseItemService.GetAsync(id);
        }

        // PUT: ExpenseItem
        [HttpPost("Add")]
        public async Task<ActionResult<int>> Add(ExpenseItem item)
        {
            //_context.ExpenseItems.Add(item);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetExpenseItem), new { id = item.Id }, item);

            return await _expenseItemService.CreateAsync(item);
        }

        // PUT: ExpenseItem
        [HttpPut("Update")]
        public async Task<ActionResult<int>> Update(ExpenseItem item)
        {
            //_context.ExpenseItems.Add(item);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetExpenseItem), new { id = item.Id }, item);

            return await _expenseItemService.UpdateAsync(item);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _expenseItemService.DeleteAsync(id);
        }

    }
}