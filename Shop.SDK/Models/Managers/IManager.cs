using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.SDK.Models.Managers
{
    public interface IManager
    {
        /// <summary>
        /// Получает сущность по идентификатору
        /// </summary>
        /// <returns></returns>
        IEntity GetById(Guid id);
        /// <summary>
        /// Возвращает все сущности
        /// </summary>
        /// <param name="limit">Максимальное количество вовзращаемых сущностей. -1 - без ограничений.</param>
        /// <returns></returns>
        IEnumerable<IEntity> GetAll(int limit = -1);
        /// <summary>
        /// Сохраняет сущность в транзакцию
        /// </summary>
        /// <param name="entity"></param>
        void SaveEntity(IEntity entity);
        /// <summary>
        /// Создает новую запись в базе данных внутри собственной транзакции
        /// </summary>
        /// <param name="entity"></param>
        void CreateEntity(IEntity entity);
        /// <summary>
        /// Возвращает тип сущности
        /// </summary>
        Type GetEntity { get; }
    }
}
