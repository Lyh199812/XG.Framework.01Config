using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfig.Models
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class Variables
    {
        public int SN { get; set; }//������ʾʹ��
        public int VariableId { get; set; }//����ID       
        public string VariableName { get; set; }//��������
        public int CGId { get; set; }//ͨ����ID
        public string StartAddress { get; set; }//��ʼ��ַ
        public string DataType { get; set; }//��������
        public bool IsMaxAlarm { get; set; } = false;//�Ƿ��������ޱ���
        public bool IsMinAlarm { get; set; } = false;//�Ƿ��������ޱ���
        public string AlarmMax { get; set; } = string.Empty;//�������� (ʵ��Ҫ���Ǹ�����)
        public string AlarmMin { get; set; } = string.Empty;//��������  (ʵ��Ҫ���Ǹ�����)
        public bool IsFiled { get; set; }//�Ƿ�鵵
        public float Scale { get; set; }//���Ա���
        public float Offset { get; set; }//����ƫ��

        public string AlarmMaxNote { get; set; } = string.Empty; //�������޽ڵ�˵��
        public string AlarmMinNote { get; set; } = string.Empty; //�������޽ڵ�˵��

        public string Comments { get; set; }//��ע 
    }
}
