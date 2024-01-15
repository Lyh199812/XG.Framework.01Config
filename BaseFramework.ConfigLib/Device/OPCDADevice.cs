using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public class OPCDADevice : DeviceBase
    {
        /// <summary>
        /// 服务节点
        /// </summary>
        public string ServerNode { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string   ServerName  { get; set; }


        /// <summary>
        /// 通信组集合
        /// </summary>
        public List<OPCDAGroup> GroupList { get; set; } = new List<OPCDAGroup>();

        /// <summary>
        /// 变量初始化
        /// </summary>
        public void Init()
        {
            foreach (var gp in GroupList)
            {
                foreach (var variable in gp.VarList)
                {
                    VarList.Add(variable);

                    if (variable.ArchiveEnable)
                    {
                        StoreVarList.Add(variable);
                    }

                    if (CurrentValue.ContainsKey(variable.VarName))
                    {
                        CurrentValue[variable.VarName] = "NA";
                    }
                    else
                    {
                        CurrentValue.Add(variable.VarName, "NA");
                    }
                }
            }
        }

    }
}
