using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetingApp.Shared.Models
{
    public class Permission : MasterClass
    {
        public int FK_User_ID { get; set; }
        public int FK_Wallet_ID { get; set; }
        public int FK_Budget_ID { get; set; }
        public bool Can_Delete { get; set; }
        public bool Can_Share { get; set; }
        public bool Can_Modify { get; set; }
        public bool Can_View { get; set; }
    }
}
