using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Authentication.Models
{
    public class TblRefreshtoken
    {
        public string UserId { get; set; }
        public string TokenId { get; set; }
        public string RefreshToken { get; set; }
        public bool? IsActive { get; set; }
    }
}
