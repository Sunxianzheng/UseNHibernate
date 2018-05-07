using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseNHibernate.Model;

namespace UseNHibernate.Manager
{
    //定义接口
    interface IUserManager
    {
        void Add(userInfo user);//增加用户
        void Update(userInfo user);//更新用户
        void Remove(userInfo user);//删除用户
        userInfo GetById(int id);//获取用户ID
        userInfo GetByUseraccount(string account);//获取用户 账号
        userInfo GetByUserpassword(string password);////获取用户 密码
        ICollection<userInfo> GetAllUsers();//获取所有的用户
        bool CheckUser(string account, string password);
    }
}
