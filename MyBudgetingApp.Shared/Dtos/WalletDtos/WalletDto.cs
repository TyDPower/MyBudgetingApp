using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetingApp.Shared.Dtos.WalletDtos
{
    public class WalletDto : MasterDtoClass
    {
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "Decimal(18,2)")] public decimal Balance { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Is_Shared { get; set; }
        public bool Is_Deleted { get; set; }
        public Guid Owner_FK_User_ID { get; set; }
    }

}
