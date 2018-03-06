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
        List<BaseManager<IIdentifyed>> _managers;

        private ManagerFactory()
        {
            _managers = new List<BaseManager<IIdentifyed>>();
            _loaded = false;
        }

        public static void Load()
        {
            if (Instance._loaded) return;

            Instance.RegisterManager(null);

            Instance._loaded = true;
        }

        public void RegisterManager(BaseManager<IIdentifyed> manager)
        {
            _managers.Add(manager);
        }

        public BaseManager<BaseEntity> GetManager(Type type)
        {
            return null;
        }
    }
}