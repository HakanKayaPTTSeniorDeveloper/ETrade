using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Dtos.AuthDtos.AuthLoginDtos
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime AccessTokenExpration { get; set; }
    }
}
