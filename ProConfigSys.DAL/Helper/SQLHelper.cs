using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfigSys.DAL
{
    /// <summary>
    /// 通用数据访问类
    /// </summary>
    internal class SQLHelper
    {
        //读取字符串
        private static string connString = BaseFramework.Common.StringSecurity.DESDecrypt(ConfigurationManager.ConnectionStrings["connString1"].ToString());


        /// <summary>
        /// 执行insert、update、delete类型的sql语句
        /// </summary>
        /// <param name="cmdText">sql语句或存储过程名称</param>
        /// <param name="paraArray">参数数组</param>
        /// <returns>受影响的行数</returns>
        /// <exception cref="Exception"></exception>
        public static int ExecuteNonQuery(string cmdText, SqlParameter[] paraArray=null)
        {
            SqlConnection conn=new SqlConnection(connString);
            SqlCommand cmd=new SqlCommand(cmdText, conn);
            if(paraArray != null)
            {
                cmd.Parameters.AddRange(paraArray);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //可以在这个地方写入日志（log文件）
                string errorMsg = $"{DateTime.Now}:执行 public static int ExecuteNonQuery(string cmdText, SqlParameter[] paraArray=null)发生异常：{ex.Message}";

                throw new Exception(errorMsg);
            }
            finally { conn.Close(); };
        }



        /// <summary>
        /// 执行单一结果查询
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="paraArray"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static object ExecuteScalar(string cmdText, SqlParameter[] paraArray = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (paraArray != null)
            {
                cmd.Parameters.AddRange(paraArray);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //可以在这个地方写入日志（log文件）
                string errorMsg = $"{DateTime.Now}:执行 public static object ExecuteScalar(string cmdText, SqlParameter[] paraArray = null)发生异常：{ex.Message}";

                throw new Exception(errorMsg);
            }
            finally { conn.Close(); };
        }


        /// <summary>
        /// 执行返回一个结果集的查询
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="paraArray"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static SqlDataReader ExecuteReader(string cmdText, SqlParameter[] paraArray = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (paraArray != null)
            {
                cmd.Parameters.AddRange(paraArray);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                //可以在这个地方写入日志（log文件）
                string errorMsg = $"{DateTime.Now}:执行  public static SqlDataReader ExecuteReader(string cmdText, SqlParameter[] paraArray = null)发生异常：{ex.Message}";

                throw new Exception(errorMsg);
            }
        }


        /// <summary>
        /// 返回包含一张数据表的数据集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataSet GetDataSet(string sql,string tableName=null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);    
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                if(tableName == null)
                {
                    da.Fill(ds);
                }
                else
                {
                    da.Fill(ds, tableName);
                }
                return ds;
            }
            catch (Exception ex)
            {
                //可以在这个地方写入日志（log文件）
                string errorMsg = $"{DateTime.Now}:执行   public static DataSet GetDataSet(string sql,string tableName=null)发生异常：{ex.Message}";

                throw new Exception(errorMsg);
            }
        }



        //sql1 table1  sql2 table2

        /// <summary>
        /// 执行查询，返回一个或多个表的DataSet
        /// </summary>
        /// <param name="dicTableAndSql"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataSet GetDataSet(Dictionary<string,string> dicTableAndSql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
               foreach(string tbName in dicTableAndSql.Keys)
                {
                    cmd.CommandText = dicTableAndSql[tbName];
                    da.Fill(ds,tbName);
                }
                return ds;
            }
            catch (Exception ex)
            {
                //可以在这个地方写入日志（log文件）
                string errorMsg = $"{DateTime.Now}:执行    public static DataSet GetDataSet(Dictionary<string,string> dicTableAndSql)发生异常：{ex.Message}";

                throw new Exception(errorMsg);
            }
        }
    }
}
