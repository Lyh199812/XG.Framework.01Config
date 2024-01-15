



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;

namespace BaseFramework.ConfigLib
{
    public class OmronHostlinkDevice : DeviceBase
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
        /// 单元号
        /// </summary>
        public byte UnitNo { get; set; }

        /// <summary>
        /// PC单元号
        /// </summary>
        public byte SA2 { get; set; }

        /// <summary>
        /// 等待响应时间
        /// </summary>
        public byte ResponseWaitTime { get; set; }

        /// <summary>
        /// 通信组集合
        /// </summary>
        public List<OmronHostlinkGroup> GroupList { get; set; } = new List<OmronHostlinkGroup>();

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
