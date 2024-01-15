using Newtonsoft.Json;












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public  class OPCDAVariable: VariableBase
    {
        /// <summary>
        /// 变量句柄
        /// </summary>
        [JsonIgnore]
        public int ClientHandle { get; set; }

        /// <summary>
        /// 所在通信组句柄
        /// </summary>
        [JsonIgnore]
        public int GroupHandle { get; set; }

    }
}
