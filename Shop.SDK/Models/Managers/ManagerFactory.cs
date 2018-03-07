using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.SDK.Models;
using Shop.SDK.Models.Managers;

namespace Shop.SDK.Models.Managers
{
    public sealed class ManagerFactory
    {
        #region Singleton
        private static ManagerFactory _instance = null;
        private static object syncRoot = new Object();
        public static ManagerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new ManagerFactory();
                    }
                }
                return _instance;
            }
        }
        #endregion

        private bool _loaded;
        IList<IManager> _managers;

        private ManagerFactory()
        {
            _managers = new List<IManager>();
            _loaded = false;
        }

        public static void Load()
        {
            if (Instance._loaded) return;

            Instance._loaded = true;
        }

        public void RegisterManager(IManager manager)
        {
            _managers.Add(manager);
        }

        /// <summary>
        /// Возвращает менеджер сущностей по типу сущности, если менеджер для сущности не зарегистрирован, то возвращается null.
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public IManager GetManager(Type entityType)
        {
            foreach (var item in _managers)
            {
                if (item.GetEntity == entityType)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Вовзвращает менеджер сущностей по типу менеджера, если менеджер не зарегистрирован ранее, то происходит его регистрация
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetManager<T>() where T : IManager, new()
        {
            foreach (var item in _managers)
            {
                if (item.GetType() == typeof(T))
                {
                    return (T)item;
                }
            }
            IManager manager = new T();
            RegisterManager(manager);
            return (T)manager;
        }
    }
}