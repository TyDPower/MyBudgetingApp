using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetingApp.Shared.Dtos.WalletDtos
{
    public class WalletDto
    {
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "Decimal(18,2)")] public decimal Balance { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsShared { get; set; }
    }

}
