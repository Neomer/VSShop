using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels
{
    public class UserAuthViewModel
    {
        [Required]
        [Display(Name = "Эл. почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Длина пароля не должна превышать 50 символов")]
        [MinLength(5, ErrorMessage = "Пароль не должен быть короче 5 символов")]
        public string Password { get; set; }

        public string Captcha { get; set; }
    }
}