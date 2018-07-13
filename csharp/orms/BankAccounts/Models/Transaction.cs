using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int user_Id { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}