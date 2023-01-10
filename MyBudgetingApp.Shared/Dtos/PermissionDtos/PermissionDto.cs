using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetingApp.Shared.Dtos.PermissionDtos
{
    public class PermissionDto : MasterDtoClass
    {
        public Guid FK_User_ID { get; set; }
        public Guid FK_Wallet_ID { get; set; }
        public Guid FK_Budget_ID { get; set; }
        public bool Can_Delete { get; set; }
        public bool Can_Share { get; set; }
        public bool Can_Modify { get; set; }
        public bool Can_View { get; set; }
        public bool Is_Active { get; set; }
    }
}
