using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace UseNHibernate
{
    class NhibernateHelper
    {
        private static ISessionFactory _isessionFactory;

        private static ISessionFactory IsessionFactory
        {
            get
            {
                if (_isessionFactory == null)
                {
                    var configration = new Configuration();
                    configration.Configure();
                    configration.AddAssembly("UseNHibernate");
                    _isessionFactory = configration.BuildSessionFactory();  
                }
                return _isessionFactory;
            }
        }
        public static ISession openSession()
        {
            return IsessionFactory.OpenSession();
        }
    }
}
