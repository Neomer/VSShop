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
    }
}