
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    public  class Project
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 西门子设备集合
        /// </summary>
        public List<SiemensDevice> SiemensList { get; set; } = new List<SiemensDevice>();

        /// <summary>
        /// 三菱设备集合
        /// </summary>
        public List<MelsecDevice> MelsecList { get; set; } = new List<MelsecDevice>();

        public List<MelsecFXSerialDevice> MelsecFXSerialList { get; set; } = new List<MelsecFXSerialDevice>();

        /// <summary>
        /// 欧姆龙设备集合
        /// </summary>
        public List<OmronDevice> OmronList { get; set; } = new List<OmronDevice>();

        public List<OmronHostlinkDevice> OmronHostlinkList { get; set; } = new List<OmronHostlinkDevice>();
        /// <summary>
        /// ModbusRTU设备集合
        /// </summary>
        public List<ModbusRTUDevice> ModbusRTUList { get; set; } = new List<ModbusRTUDevice>();

        /// <summary>
        /// ModbusASCII设备集合
        /// </summary>
        public List<ModbusASCIIDevice> ModbusASCIIList { get; set; } = new List<ModbusASCIIDevice>();

        /// <summary>
        /// ModbusTCP设备集合
        /// </summary>
        public List<ModbusTCPDevice> ModbusTCPList { get; set; } = new List<ModbusTCPDevice>();


        /// <summary>
        /// ModbusRTUOverTCP设备集合
        /// </summary>
        public List<ModbusRTUOverTCPDevice> ModbusRTUOverTCPList { get; set; } = new List<ModbusRTUOverTCPDevice>();


        /// <summary>
        /// OPCDA设备集合
        /// </summary>
        public List<OPCDADevice> OPCDAList { get; set; } = new List<OPCDADevice>();


        /// <summary>
        /// OPCUA设备集合
        /// </summary>
        public List<OPCUADevice> OPCUAList { get; set; } = new List<OPCUADevice>();

    }
}
