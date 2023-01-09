using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetingApp.Shared.Dtos.PermissionDtos
{
    public class PermissionDto
    {
        public int ID { get; set; }
        public int FK_User_ID { get; set; }
        public int FK_Wallet_ID { get; set; }
        public int FK_Budget_ID { get; set; }
        public bool Delete { get; set; }
        public bool Share { get; set; }
        public bool Modify { get; set; }
        public bool View { get; set; }
    }
}
