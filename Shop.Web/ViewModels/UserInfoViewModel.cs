using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels
{
    /// <summary>
    /// Модель представления используется для редактирования профиля
    /// </summary>
    public class UserInfoViewModel
    {
        /// <summary>
        /// E-Mail
        /// </summary>
        public virtual string Email { get; set; }
        /// <summary>
        /// Указанная дата рождения
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public virtual DateTime RegisterDate { get; set; }
        /// <summary>
        /// Дата последнего визита
        /// </summary>
        public virtual DateTime? LastVisitDate { get; set; }
    }
}