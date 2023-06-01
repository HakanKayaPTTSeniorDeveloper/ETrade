﻿using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.UserDtos.UserGetByUserNameDtos
{
    public class UserGetByUserNameResponseDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
