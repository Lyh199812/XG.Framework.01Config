
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public enum MelsecType
    {
        FX3U,
        FX5U,
        Q
    }

    public class MelsecDevice : DeviceBase
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
        /// 协议类型
        /// </summary>
        public string ProtocolType { get; set; }

        /// <summary>
        /// 三菱CPU类型
        /// </summary>
        public MelsecType MelsecType { get; set; } = MelsecType.Q;


        /// <summary>
        /// 通信组集合
        /// </summary>
        public List<MelsecGroup> GroupList { get; set; } = new List<MelsecGroup>();

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
