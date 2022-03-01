using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayer.Entities.User
{
    public class User
    {
        public User()
        {

        }
        [Key]
        public int UserId { get; set; }
        [Display(Name ="")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string UserName { get; set; }
        [Display(Name = "")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Password { get; set; }
        [Display(Name = "")]        
        public DateTime RegisterDate { get; set; }



        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<Wallet.Wallet>  Wallets { get; set; }

    }
}
