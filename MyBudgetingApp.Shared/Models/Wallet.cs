using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetingApp.Shared.Models
{
    public class Wallet : MasterClass
    {
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "Decimal(18,2)")] public decimal Balance { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsShared { get; set; }
        public bool IsDeleted { get; set; }

        public bool ValidateBalance(decimal transactionAmount, bool isDeposit, decimal currentBalance)
        {
            // Calculate the expected balance after the transaction
            decimal expectedBalance;
            if (isDeposit)
            {
                expectedBalance = this.Balance + transactionAmount;
            }
            else
            {
                expectedBalance = this.Balance - transactionAmount;
            }

            // If the expected balance does not match the current balance, return false
            if (expectedBalance != currentBalance)
            {
                return false;
            }

            return true;
        }

    }
}
