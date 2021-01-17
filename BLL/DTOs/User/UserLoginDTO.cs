using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.User
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "ველი აუცილებელია")]
        [UIHint("username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "ველი აუცილებელია")]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
