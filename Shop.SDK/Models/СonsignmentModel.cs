using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Модель для представления партии
    /// </summary>
    public class СonsignmentModel : IIdentifyed
    {
        /// <summary>
        /// Дата поступления
        /// </summary>
        public virtual DateTime CreationDate { get; set; }
        /// <summary>
        /// Позиции партии
        /// </summary>
        public IList<ConsignmentItemModel> Items { get; set; }        
    }
}