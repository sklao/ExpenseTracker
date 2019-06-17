using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Author: Savio Lao
/// Describes an an expense item.
/// </summary>

namespace ExpenseTracker.Models
{
    public class ExpenseItem
    {
        public int Id { get; set; } 
        public double Amount { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }

    }
}
