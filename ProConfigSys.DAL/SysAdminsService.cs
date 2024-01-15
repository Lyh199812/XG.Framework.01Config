using ProConfig.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProConfigSys.DAL
{

    /// <summary>
    /// 管理员登录数据范围类
    /// </summary>
    public class SysAdminsService
    {
        public SysAdmins AdminLogin (SysAdmins admin)
        {
            //[1] 封装SQL语句
            string sql = "select SysAdminId,AdminName from SysAdmins where SysAccount=@SysAccount and AdminPwd=@AdminPwd";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SysAccount",admin.SysAccount),
                new SqlParameter("@AdminPwd",admin.AdminPwd)
            };
            //[2]提交查询
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, param);
            //[3]判断登录是否正确,如果正确则封装Id和Name
            if(reader.Read())
            {
                admin.SysAdminId = Convert.ToInt32(reader["SysAdminId"]);
                admin.AdminName = reader["AdminName"].ToString();
            }
            else
            {
                admin = null;//表示当前账号或密码不正确
            }
            reader.Close();
            return admin;


        }
    
    
        /// <summary>
        /// 保存密码
        /// </summary>
        /// <param name="sysAdmins"></param>
        public void SavePwd(SysAdmins sysAdmins)
        {
            //[1]创建文件流
            FileStream fs=new FileStream("sysAdmins.obj",FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, sysAdmins);//这里的序列化，就是把内存中的SysAdmins对象保存到文件）；
            fs.Close();
        }

        /// <summary>
        /// 读取密码
        /// </summary>
        /// <returns></returns>
        public SysAdmins ReadPwd()
        {
            if(!File.Exists("sysAdmins.obj"))
            {
                return null;
            }
            FileStream fs = new FileStream("sysAdmins.obj", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            SysAdmins admin= (SysAdmins)bf.Deserialize(fs);//反序列化
            fs.Close();
            return admin;
                
        }

        /// <summary>
        /// 清除密码
        /// </summary>
        public void DeletePwd()
        {
            if(File.Exists("sysAdmins.obj"))
            {
                File.Delete("sysAdmins.obj");
            }
        }
    }
}
