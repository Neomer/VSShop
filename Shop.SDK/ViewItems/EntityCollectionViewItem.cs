using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.SDK.Models;
using Shop.SDK.Models.Managers;

namespace Shop.SDK.ViewItems
{
    /// <summary>
    /// Элемент представления для отображения списка сущностей определенного типа
    /// </summary>
    public class EntityCollectionViewItem : IEntityCollectionViewItem
    {
        private Type _entityType = null;
        private IManager _manager = null;

        public EntityCollectionViewItem(Type entityType)
        {
            _entityType = entityType;
            _manager = ManagerFactory.Instance.GetManager(entityType);
            if (_manager == null)
            {
                throw new Exception("Менеджер для указанной сущности не найден!");
            }
        }

        public Type EntityType
        {
            get
            {
                return _entityType;
            }
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}