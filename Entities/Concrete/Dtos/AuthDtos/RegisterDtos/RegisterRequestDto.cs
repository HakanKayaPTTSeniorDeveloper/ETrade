﻿using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.AuthDtos.RegisterDtos
{
    public class RegisterRequestDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
