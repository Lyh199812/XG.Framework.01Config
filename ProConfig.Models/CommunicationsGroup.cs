using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.Models
{
    /// <summary>
    /// ͨ����
    /// </summary>
    public class CommunicationsGroup
    {
        public int  SN  { get; set; }
        public int CGId { get; set; }
        public int EquipmentId { get; set; }  
        public string CGName { get; set; }
        public string StartAddress { get; set; }
        public int CGLength { get; set; }
        public int IsEnable { get; set; }
        public string Comments { get; set; }

        //��չ����
        public string EquipmentName { get; set; }


    }
}
