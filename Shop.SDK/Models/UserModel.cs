using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Модель данных для сущности пользователя. Используется для регистрации, авторизации, аутентификации.
    /// </summary>
    public class UserModel : BaseEntity
    {
        /// <summary>
        /// E-Mail
        /// </summary>
        public virtual string Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public virtual string Password { get; set; }
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
        /// <summary>
        /// Корзины, созданные для пользователя
        /// </summary>
        public virtual IList<BasketModel> Baskets { get; set; }
    }
}