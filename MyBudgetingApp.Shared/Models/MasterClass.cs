using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetingApp.Shared.Models
{
    public class MasterClass
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
