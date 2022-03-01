using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayer.Entities.Wallet
{
    public class Wallet
    {
        public Wallet()
        {

        }
        [Key]
        public int WalletId { get; set; }
        [Display(Name ="نوع تراکنش")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public int TypeId { get; set; }
        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }
        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;
        [Display(Name = "تاریخ پرداخت")]
        public DateTime CreatDate { get; set; }
        [Display(Name = "تایید شده")]
        public bool IsPay { get; set; }

        public  User.User User { get; set; }
        
        public WalletType? WalletType { get; set; }
    }
}
