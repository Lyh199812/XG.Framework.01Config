using Newtonsoft.Json;












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public  class OPCUAVariable : VariableBase
    {
        /// <summary>
        /// �������
        /// </summary>
        [JsonIgnore]
        public int ClientHandle { get; set; }

    }
}
