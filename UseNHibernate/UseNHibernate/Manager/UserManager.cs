using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseNHibernate.Model;

namespace UseNHibernate.Manager
{
    class UserManager : IUserManager
    {
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user"></param>
        public void Add(userInfo user)
        {
            //调用NhibernateHelper 辅助类中的方法 会自动关闭  
            using (ISession session = NhibernateHelper.openSession())
            {
                //开启一个事务  会自动释放
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);//保存user  
                    transaction.Commit();//事务的提交  
                }
            }
        }

        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <returns></returns>
        public ICollection<userInfo> GetAllUsers()
        {
            using (ISession session = NhibernateHelper.openSession())
            {
                IList<userInfo> users = session.CreateCriteria(typeof(userInfo)).List<userInfo>();
                return users;
            }
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="id"></param>
        public userInfo GetById(int id)
        {
            using (ISession session = NhibernateHelper.openSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    userInfo user = session.Get<userInfo>(id);
                    transaction.Commit();
                    return user;
                }
            }
        }

        /// <summary>
        /// 获取用户 账号
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public userInfo GetByUseraccount(string account)
        {
            using (ISession session = NhibernateHelper.openSession())
            {
                //     用来指定查询哪个表   创建的是一个配置条件  
                ICriteria critria = session.CreateCriteria(typeof(userInfo));
                //添加查询条件  
                critria.Add(Restrictions.Eq("Name", account));
                // 进行查询  只得到一个查询结果
                userInfo user = critria.UniqueResult<userInfo>();
                return user;
            }
        }

        /// <summary>
        /// 获取用户 密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public userInfo GetByUserpassword(string password)
        {
            using (ISession session = NhibernateHelper.openSession())
            {
                ICriteria icriteria = session.CreateCriteria(typeof(userInfo));
                icriteria.Add(Restrictions.Eq("Password", password));
                userInfo user = icriteria.UniqueResult<userInfo>();
                return user;
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        public void Remove(userInfo user)
        {
            using (ISession session = NhibernateHelper.openSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        public void Update(userInfo user)
        {
            using (ISession session = NhibernateHelper.openSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// 检查用户
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUser(string account, string password)
        {
            using (ISession session = NhibernateHelper.openSession())
            {
                userInfo user = session.CreateCriteria(typeof(userInfo))
                    .Add(Restrictions.Eq("Name", account))
                    .Add(Restrictions.Eq("Password", password))
                    .UniqueResult<userInfo>();
                if (user == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
