using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProConfig.Models;
using ProConfigSys.DAL;

namespace ProConfigSys.BLL
{
    public class EquipmentManager
    {
        EquipmentsService eService = new EquipmentsService();
        #region 设备类型和协议类型查询
        /// <summary>
        /// 获取所有的设备类型
        /// </summary>
        /// <returns></returns>
        public List<EquipmentType> GetAllEType()
        {
            return eService.GetAllEType();

        }



        /// <summary>
        /// 根据设备类型获取对应的协议类型
        /// </summary>
        /// <returns></returns>
        public List<ProtocolType> GetPTypeByEType(int eTypeId)
        {
            return eService.GetPTypeByEType(eTypeId);

        }
        #endregion



        /// <summary>
        /// 新增设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(Equipments model)
        {
            return eService.Insert(model);

        }

        /// <summary>
        /// 新增设备，同一项目验证是否设备重名
        /// </summary>
        /// <param name="eName">设备名称</param>
        /// <param name="pId">当前项目编号</param>
        /// <returns></returns>
        public bool IsRepeatForInsert(string eName, int pId)
        {
            return eService.IsRepeatForInsert(eName, pId);
        }

        public Dictionary<int, List<Equipments>> QueryEquipments(int projectId)
        {
            return eService.QueryEquipments(projectId);
        }

        #region 修改设备

        /// <summary>
        /// 修改设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Equipments model)
        {
            return eService.Update(model);

        }

        /// <summary>
        /// 修改设备，同一项目验证是否设备重名
        /// 要求：同一个项目，修改的时候其他的设备名称不能和修改后的冲突
        /// </summary>
        /// <param name="eName">设备名称</param>
        /// <param name="pId">当前项目编号</param>
        /// <param name="eId">当前设备编号</param>
        /// <returns></returns>
        public bool IsRepeatForUpdate(string eName, int pId, int eId)
        {
            return eService.IsRepeatForUpdate(eName, pId, eId);
        }
        #endregion
    }
}
