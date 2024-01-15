using Newtonsoft.Json;












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public  class GroupBase
    {
        /// <summary>
        /// 通信组的名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 通信组是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 出错次数
        /// </summary>
        [JsonIgnore]
        public int ErrorTimes { get; set; }

        /// <summary>
        /// 容错次数
        /// </summary>
        [JsonIgnore]
        public int AllowErrorTimes { get; set; } = 3;

        /// <summary>
        /// 通信结果
        /// </summary>
        [JsonIgnore]
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// 采集时间
        /// </summary>
        [JsonIgnore]
        public string AcquisitionTime { get; set; }


    }
}
