











using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public  class OPCUAGroup : GroupBase
    {
        /// <summary>
        /// �����ļ���
        /// </summary>
        public List<OPCUAVariable> VarList { get; set; } = new List<OPCUAVariable>();

    }
}
