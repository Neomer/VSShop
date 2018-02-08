using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.SDK.Models;
using NHibernate.Tool.hbm2ddl;

namespace Shop.SDK.Core
{
    public class NHibernateHelper
    {
        #region Singleton
        private static NHibernateHelper _instance;
        public static NHibernateHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NHibernateHelper();
                }
                return _instance;
            }
        }
        #endregion

        private ISessionFactory _sessionFactory = null;

        private NHibernateHelper()
        {
            var configuration = new Configuration();
            var configurePath = HttpContext.Current.Server.MapPath(@"~\nhibernate.cfg.xml");
            configuration.Configure(configurePath);
            try
            {
                //configuration.AddAssembly(typeof(UserModel).Assembly);
            }
            catch (MappingException ex)
            {

            }
            new SchemaUpdate(configuration).Execute(true, true);
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            if (_sessionFactory != null)
            {
                return _sessionFactory.OpenSession();
            }
            else
            {
                throw new Exception("Фабрика сущностей не инициализирована!");
            }
        }

        public ISession GetCurrentSession()
        {

            ISession session = null;
            try
            {
                session = _sessionFactory.GetCurrentSession();
                if (session == null)
                {
                    session = OpenSession();
                }
            }
            catch (Exception)
            {
                session = OpenSession();
            }
            return session;
        }

    }
}