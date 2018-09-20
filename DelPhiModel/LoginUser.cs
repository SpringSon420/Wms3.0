using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmsModel
{
    public class LoginUser
    {
        public LoginUser() { }
        public LoginUser(string loginId, string passWord)
        {
            this.LoginId = loginId;
            this.PassWord = passWord;
        }
        public string LoginId { get; set; }//用户名
        public string PassWord { get; set; }//密码

    }
}
