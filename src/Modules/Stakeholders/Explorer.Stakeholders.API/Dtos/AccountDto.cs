using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class AccountDto 
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }

        /*public AccountDto(long userId, string username, string password, string email, string role, bool isActive)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Email = email;
            Role = role;
            IsActive = isActive;
        }*/
    }

}



