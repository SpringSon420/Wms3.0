using WmsCommon;
using WmsModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelPhiCommon;

namespace WmsBLL
{
   public static class LoginManager
    {
        public static bool CheckLogin(LoginUser loginUser)
        {
            return CheckIdPwd(loginUser) == 1 ? true : false;
        }


        public static int CheckIdPwd(LoginUser loginUser)
        {
            SqlHelper sqlHelper = new SqlHelper();
            Encryption encryption = new Encryption();
            string sql = "select * from MC.user_ where uname='"+loginUser.LoginId+"' and upwd='"+ encryption.MD5Encrypt(loginUser.PassWord) + "' ";
            DataTable dt = sqlHelper.ExecuteQuery(sql);
            if (dt!=null&&dt.Rows.Count>0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static string GetPro(string login_name)
        {
            SqlHelper sqlHelper = new SqlHelper();
            string sql = " select privilege from MC.user_ where uname='" + login_name+ "'";
            int r=(int)sqlHelper.Finds(sql);
            string res = r.ToString();
            return res;
        }
    }
}
