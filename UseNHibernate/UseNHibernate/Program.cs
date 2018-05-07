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
            #region 
            //    var configration = new Configuration();
            //    configration.Configure();//解析配置文件    nhibernate.cfg.xml  
            //    configration.AddAssembly("UseNHibernate");//解析映射文件   userInfo.nbm.xml

            //    ISessionFactory sessionFactory =  null;
            //    ITransaction iTran = null;
            //    ISession session = null;

            //    try
            //    {
            //        sessionFactory = configration.BuildSessionFactory();
            //        session = sessionFactory.OpenSession();//打开一个跟数据库的会话

            //        //userInfo user = new userInfo() { Name = "1", Password = "1" };
            //        //session.Save(user);

            //        //事务（当数据库操作有一个不成功 整个操作都不成功）
            //        iTran = session.BeginTransaction();
            //        userInfo user1 = new userInfo() { Name = "wqeqw", Password = "wqeqwe" };
            //        userInfo user2 = new userInfo() { Name = "sadsad", Password = "dsaada" };

            //        session.Save(user1);
            //        session.Save(user2);
            //        iTran.Commit();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    finally
            //    {
            //        if (iTran != null)
            //        {
            //            iTran.Dispose();
            //        }
            //        if (session != null)
            //        {
            //            session.Close();
            //        }
            //        else if (sessionFactory != null)
            //        {
            //            sessionFactory.Close();
            //        }
            //    }
            //    Console.ReadKey();
            //}

            #endregion
            //userInfo user = new userInfo() { Id = 9};
            IUserManager userManager = new UserManager();
            // userManager.Remove(user);
            //userManager.Update(user);
            //userManager.Remove(user);
            //userInfo userInfo = userManager.GetById(7);
            //Console.WriteLine( userInfo.Name);
            //Console.WriteLine(userInfo.Password);
            //userInfo Info = userManager.GetByUserpassword("1");
            //Console.WriteLine(Info.Name);
            //Console.WriteLine(Info.Password);
            //Console.WriteLine(Info.Id);
            //Console.ReadKey();
            //ICollection<userInfo> listUser = userManager.GetAllUsers();
            //foreach (var u in listUser)
            //{
            //    Console.WriteLine(u.Id + u.Name + u.Password);
            //}
            Console.WriteLine(userManager.CheckUser("C","7"));
            Console.WriteLine(userManager.CheckUser("C","8"));
            Console.ReadKey();
        }
    }
}
