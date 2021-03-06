﻿
using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL.DTO
{
    public class UserDTO : IEntity
    {
        public UserDTO()
        {
            Roles = new List<RoleDTO>();
            TestResults = new List<TestResultDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public int Age { get; set; }
        public IList<RoleDTO> Roles { get; set; }
        public IList<TestResultDTO> TestResults { get; set; }

    }
}
