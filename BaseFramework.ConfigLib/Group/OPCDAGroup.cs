using Newtonsoft.Json;












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public  class OPCDAGroup : GroupBase
    {
        /// <summary>
        /// 通信组句柄
        /// </summary>
        [JsonIgnore]
        public int ClientHandle { get; set; }

        /// <summary>
        /// 变量的集合
        /// </summary>
        public List<OPCDAVariable> VarList { get; set; } = new List<OPCDAVariable>();

    }
}
