using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmsCommon
{
    public class SqlHelper
    {
        private static SqlDataAdapter da;
        private static SqlDataReader sdr;
        private static SqlConnection StrConn;
        private static SqlCommand cmd;
        private static DataSet ds;
        private static string sqlcon = "server=192.168.0.90;database=WMS;user id=sa;password=123456;";
        public SqlHelper()
        {
            //构造函数
            StrConn = new SqlConnection(sqlcon);
        }

        #region 数据库连接
        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns>返回</returns>
        public SqlConnection GetConn()
        {
            if (StrConn.State == ConnectionState.Closed)
            {
                StrConn.Open();
            }
            else if (StrConn.State == ConnectionState.Open)
            {
                StrConn.Close();
            }

            return StrConn;
        }
        #endregion

        /// <summary>
        /// 该方法传入SQL查询语句返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet DataSetSearch(string sql)
        {
            using (ds = new DataSet())
            {
                da = new SqlDataAdapter(sql, StrConn);
                da.Fill(ds);
                return ds;
            }
        }


        /// <summary>
        /// 该方法传入SQL查询语句返回DataTable
        /// </summary>
        /// <param name="sql">要执行的SQL</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                cmd = new SqlCommand(sql, GetConn());
                using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    dt.Load(sdr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 该方法传入SQL查询语句返回SqlDataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader reder(string sql)
        {
            try
            {
                cmd = new SqlCommand(sql, GetConn());
                sdr = cmd.ExecuteReader();
                return sdr;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        /// <summary>
        /// 数据增删改操作返回INT类型
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>返回</returns>
        public int insertEx(string sql)
        {
            try
            {
                cmd = new SqlCommand(sql, GetConn());
                int res = cmd.ExecuteNonQuery();
                return res;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public Object Finds(string sql)
        {
            try
            {
                cmd = new SqlCommand(sql, GetConn());
                object res = cmd.ExecuteScalar();
                return res;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


    }
}
