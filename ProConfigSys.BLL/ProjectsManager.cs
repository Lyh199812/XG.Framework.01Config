using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProConfig.Models;
using ProConfigSys.DAL;

namespace ProConfigSys.BLL
{
    public class ProjectsManager
    {
        ProjectsService pService=new ProjectsService();
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(Projects model)
        {
            return pService.Insert(model);
        }


        /// <summary>
        /// 添加项目，验证项目名称是否重复
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public bool IsRepeatForInsert(string pName)
        {
           return pService.IsRepeatForInsert(pName);

        }


        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Projects model)
        {
           return pService.Update(model);
        }


        /// <summary>
        /// 修改项目，验证项目名称是否重复
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public bool IsRepeatForUpdate(string pName, int PId)
        {
           return pService.IsRepeatForUpdate(pName, PId);

        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            return pService.Delete(Id);
        }

        /// <summary>
        /// 查询项目信息
        /// </summary>
        /// <returns></returns>
        public List<Projects> Query()
        {
           return pService.Query();

        }


    }
}
