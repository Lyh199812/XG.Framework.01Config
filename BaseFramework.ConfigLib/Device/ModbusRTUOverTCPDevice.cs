using Newtonsoft.Json;












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{

    public class ModbusRTUOverTCPDevice : DeviceBase
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }


        /// <summary>
        /// 是否为短地址
        /// </summary>
        public bool IsShortAddress { get; set; }

        /// <summary>
        /// 通信组集合
        /// </summary>
        public List<ModbusRTUOverTCPGroup> GroupList { get; set; } = new List<ModbusRTUOverTCPGroup>();

        /// <summary>
        /// 循环次数
        /// </summary>
        [JsonIgnore]
        public int CycleTimes { get; set; }

        /// <summary>
        /// 设置循环次数
        /// </summary>
        [JsonIgnore]
        public int CheckCycleTimes { get; set; } = 10;

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
