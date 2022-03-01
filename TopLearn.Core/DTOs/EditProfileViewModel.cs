using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.Core.DTOs
{
    public class EditProfileViewModel
    {
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [EmailAddress]
        public string Email { get; set; }
        //[Display(Name = "")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }
    }
}
