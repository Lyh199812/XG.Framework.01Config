











using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using Newtonsoft.Json;

namespace BaseFramework.ConfigLib
{
    public class ModbusASCIIDevice : DeviceBase
    {
        /// <summary>
        /// 端口号
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 校验位
        /// </summary>
        public Parity Parity { get; set; }

        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits  { get; set; }

        /// <summary>
        /// 是否为短地址
        /// </summary>
        public bool IsShortAddress { get; set; }

        /// <summary>
        /// 通信组集合
        /// </summary>
        public List<ModbusASCIIGroup> GroupList { get; set; } = new List<ModbusASCIIGroup>();

        
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
