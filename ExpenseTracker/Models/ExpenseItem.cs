using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Author: Savio Lao
/// Describes an an expense item.
/// </summary>

namespace ExpenseTracker.Models
{
    [Table("ExpenseItems")]
    public class ExpenseItem
    {
        [Required(ErrorMessage = "ID is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Amount is required.")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public int Category { get; set; }
        public Category ExpenseItemCategory { get; set; }

    }
}
