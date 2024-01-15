
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;

namespace BaseFramework.ConfigLib
{
    public class MelsecFXSerialDevice : DeviceBase
    {
        /// <summary>
        /// �˿ں�
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// У��λ
        /// </summary>
        public Parity Parity { get; set; }

        /// <summary>
        /// ����λ
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// ֹͣλ
        /// </summary>
        public StopBits StopBits  { get; set; }

        /// <summary>
        /// ͨ���鼯��
        /// </summary>
        public List<MelsecFXSerialGroup> GroupList { get; set; } = new List<MelsecFXSerialGroup>();

        /// <summary>
        /// ������ʼ��
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