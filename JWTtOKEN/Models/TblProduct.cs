using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Authentication.Models
{
    public class TblProduct
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
    }
}
