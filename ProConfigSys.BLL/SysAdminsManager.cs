using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ProConfig.Models;
using ProConfigSys.DAL;
namespace ProConfigSys.BLL
{
    public class SysAdminsManager
    {
        private SysAdminsService adminService = new SysAdminsService();

        public SysAdmins AdminLogin(SysAdmins admin)
        {
            return adminService.AdminLogin(admin);
        }

        /// <summary>
        /// 保存密码
        /// </summary>
        /// <param name="sysAdmins"></param>
        public void SavePwd(SysAdmins sysAdmins)
        {
            adminService.SavePwd(sysAdmins);
        }

        /// <summary>
        /// 读取密码
        /// </summary>
        /// <returns></returns>
        public SysAdmins ReadPwd()
        {
           return adminService.ReadPwd();

        }

        /// <summary>
        /// 清除密码
        /// </summary>
        public void DeletePwd()
        {
           adminService.DeletePwd();
        }
    }
}
