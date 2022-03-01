using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.Core.DTOs
{
    public class ChangePassWordViewModel
    {
        [Display(Name = "رمز عبور قبلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.Password)]
        public string OldPassWord { get; set; }
        [Display(Name = "رمز عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = " تکرار رمز عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "تکرار رمز صحیح نمی باشد")]
        public string RePassword { get; set; }
    }
}
