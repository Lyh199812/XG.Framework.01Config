using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProConfig.Models;

namespace ProConfigSys.DAL
{
    /// <summary>
    /// 项目数据访问类
    /// </summary>
    public class ProjectsService
    {
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(Projects model)
        {
            string sql = "insert into Projects(ProjectName) values (@ProjectName);select @@Identity";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ProjectName",model.ProjectName)
            };
            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql, sp));

        }


        /// <summary>
        /// 添加项目，验证项目名称是否重复
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public bool IsRepeatForInsert(string pName)
        {
            string sql = "select count(*) from Projects where ProjectName=@pName";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@pName",pName)
            };
            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql,param))==0?false:true;

        }


        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Projects model)
        {
            string sql = "update Projects set ProjectName=@ProjectName where ProjectId=@ProjectId";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProjectName",model.ProjectName),
                new SqlParameter("@ProjectId",model.ProjectId)
            };

            return Convert.ToInt32(SQLHelper.ExecuteNonQuery(sql,param));
        }


        /// <summary>
        /// 修改项目，验证项目名称是否重复
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public bool IsRepeatForUpdate(string pName,int PId)
        {
            string sql = "select count(*) from Projects where ProjectName=@pName and ProjectId<>@ProjectId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@pName",pName),
                new SqlParameter("@ProjectId",PId)
            };
            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql, param)) == 0 ? false : true;

        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            string sql = "delete from Projects where ProjectId=@ProjectId";

            SqlParameter[] sqlParameters = new SqlParameter[] 
            {
                new SqlParameter("@ProjectId",Id)
            };
            return SQLHelper.ExecuteNonQuery(sql, sqlParameters);
        }

        /// <summary>
        /// 查询项目信息
        /// </summary>
        /// <returns></returns>
        public List<Projects>Query()
        {
            string sql = "select ProjectName,ProjectId from Projects order by ProjectId ASC";

            SqlDataReader reader = SQLHelper.ExecuteReader(sql);

            List<Projects> list =new List<Projects>();
            int sn = 0;
            while(reader.Read())
            {
                sn++;
                list.Add(new Projects()
                {
                    SN = sn,
                    ProjectId = (int)reader["ProjectId"],
                    ProjectName = reader["ProjectName"].ToString()
                }) ;

            }
            reader.Close();
            return list;

        }


    }
}
