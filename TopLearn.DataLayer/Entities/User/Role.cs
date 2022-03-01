using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayer.Entities.User
{
    public class Role
    {
        public Role()
        {

        }
        [Key]
        public int RoleId { get; set; }
        [Display(Name = "دسترسی کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]       
        public string RoleTiltle { get; set; }


        public virtual List<UserRole> UserRoles { get; set; }
    }
}
