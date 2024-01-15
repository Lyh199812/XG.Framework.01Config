using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfig.Models
{
    /// <summary>
    /// �豸��Ϣ
    /// </summary>
    public class Equipments
    {
        public int SN { get; set; }
        public int EquipmentId { get; set; }//�豸Id
        public int ProjectId { get; set; }//��ĿId
        public string EquipmentName { get; set; }//�豸����
        public int ETypeId { get; set; }
        public int PTypeId { get; set; }

        //����������UI����ѡ�������Ҫ��Ĭ��ֵ
        public string IPAddress { get; set; } = string.Empty;
        public string PortNo { get; set; } = string.Empty;   //�˿ںţ������̫���� 
        public string SerialNo { get; set; } = string.Empty;   //���ں� ����Դ��ڣ�
        public int BaudRate { get; set; } = 0;//�����ʣ���Դ��ڣ�
        public int DataBit { get; set; } = 0;//����λ����Դ��ڣ�
        public string ParityBit { get; set; } = string.Empty;//У��λ����Դ��ڣ�
        public int StopBit { get; set; } = 0;//ֹͣλ����Դ��ڣ�      
        public string OPCNodeName { get; set; } = string.Empty; //�ڵ����ƣ����OPC
        public string OPCServerName { get; set; } = string.Empty; //�������ƣ����OPC
        public int IsEnable { get; set; } = 0;//������
        public string Comments { get; set; } = string.Empty; //��ע

        //��չ����1�����ø�Ĭ��ֵ��       Ϊ����ʾ��Ҫ 
        public string ETypeName { get; set; }//�豸����
        public string PTypeName { get; set; }//Э������



    }
}
