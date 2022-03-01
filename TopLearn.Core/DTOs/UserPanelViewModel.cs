using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.Core.DTOs
{
    public class UserPanelViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Wallet { get; set; }
    }
}
