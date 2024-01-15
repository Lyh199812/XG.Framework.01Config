using Newtonsoft.Json;












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public  class VariableBase
    {
        /// <summary>
        /// 变量名称
        /// </summary>
        public string VarName { get; set; }

        /// <summary>
        /// 变量类型
        /// </summary>
        public string VarType { get; set; }

        /// <summary>
        /// 变量地址
        /// </summary>
        public string VarAddress { get; set; }

        /// <summary>
        /// 变量数值
        /// </summary>
        [JsonIgnore]
        public object VarValue { get; set; }

        /// <summary>
        /// 变量描述
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// 线性比例系数
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// 偏移量
        /// </summary>
        public float Offset { get; set; }

        /// <summary>
        /// 是否归档
        /// </summary>
        public bool ArchiveEnable { get; set; }

        /// <summary>
        /// 高报警启用
        /// </summary>
        public bool HighAlarmEnable { get; set; }

        /// <summary>
        /// 高报警设定值
        /// </summary>
        public float HighAlarmValue { get; set; }

        /// <summary>
        /// 高报警说明
        /// </summary>
        public string HighAlarmNote { get; set; }

        /// <summary>
        /// 高报警缓存值
        /// </summary>
        [JsonIgnore]
        public float HighAlarmCacheValue { get; set; }



        /// <summary>
        /// 低报警启用
        /// </summary>
        public bool LowAlarmEnable { get; set; }

        /// <summary>
        /// 低报警设定值
        /// </summary>
        public float LowAlarmValue { get; set; }

        /// <summary>
        /// 低报警说明
        /// </summary>
        public string LowAlarmNote { get; set; }

        /// <summary>
        /// 低报警缓存值
        /// </summary>
        [JsonIgnore]
        public float LowAlarmCacheValue { get; set; }

    }
}
