
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{

    public class OPCUADevice : DeviceBase
    {
        /// <summary>
        /// 服务器URL地址
        /// </summary>
        public string ServerUrl { get; set; }


        /// <summary>
        /// 通信组集合
        /// </summary>
        public List<OPCUAGroup> GroupList { get; set; } = new List<OPCUAGroup>();

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
