using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.Core.Convertors
{
    public class Fixetext
    {
        public static string fixemail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
