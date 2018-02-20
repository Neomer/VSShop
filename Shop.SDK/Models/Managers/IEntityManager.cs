using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.SDK.Models.Managers
{
    public interface IEntityManager
    {
        T GetById<T>(Guid id) where T : class, IEntity;
        IEnumerable<T> GetAll<T>() where T : class, IEntity;
        void CreateEntity<T>(T entity) where T : class, IEntity;
        void CreateEntityUnsave<T>(T entity) where T : class, IEntity;
    }
}
