using System;
using NHibernate;
using NHibernate.Cfg;
using UseNHibernate.Model;
using Iesi.Collections.Generic;
using UseNHibernate.Manager;
using System.Collections.Generic;

namespace UseNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserManager userManager = new UserManager();
            Console.WriteLine(userManager.CheckUser("C","7"));
            Console.WriteLine(userManager.CheckUser("C","8"));
            Console.ReadKey();
        }
    }
}
