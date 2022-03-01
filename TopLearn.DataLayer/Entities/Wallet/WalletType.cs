using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayer.Entities.Wallet
{
    public class WalletType
    {
        public WalletType()
        {

        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeId { get; set; }
        [Required]
        public string TypeTitle { get; set; } = string.Empty;

        
        public  List<Wallet>? Wallets { get; set; }
        
    }
}
