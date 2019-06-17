using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using Newtonsoft.Json;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseItemController : ControllerBase
    {
        ExpenseTrackerContext _context;

        //Contructor
        public ExpenseItemController(ExpenseTrackerContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public  ActionResult<IEnumerable<ExpenseItem>> AllExpenseItems() 
        {
            if (_context.ExpenseItems.Count<ExpenseItem>() == 0)
            {
                return BadRequest();
            }
            return _context.ExpenseItems;
        }

        // GET: ExpenseItem
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseItem>> GetExpenseItem(long id)
        {
            var expenseItem = await _context.ExpenseItems.FindAsync(id);

            if (expenseItem == null)
            {
                NotFound();
            }

            return expenseItem;
        }
        

        // PUT: ExpenseItem
        [HttpPut("Create")]
        public async Task<ActionResult<ExpenseItem>> Create(ExpenseItem item)
        {
            _context.ExpenseItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpenseItem), new { id = item.Id }, item);
        }

    }
}