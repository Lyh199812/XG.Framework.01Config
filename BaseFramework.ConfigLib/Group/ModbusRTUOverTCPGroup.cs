











using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public  class ModbusRTUOverTCPGroup : GroupBase
    {
        /// <summary>
        /// ��ʼ��ַ
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// �����ļ���
        /// </summary>
        public List<ModbusRTUOverTCPVariable> VarList { get; set; } = new List<ModbusRTUOverTCPVariable>();

    }
}