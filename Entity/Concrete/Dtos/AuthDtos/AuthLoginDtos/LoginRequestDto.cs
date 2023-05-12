using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Dtos.AuthDtos.AuthLoginDtos
{
    public class LoginRequestDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
