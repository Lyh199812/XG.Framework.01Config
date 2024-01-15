using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfig.Models
{
    /// <summary>
    /// π‹¿Ì‘±
    /// </summary>
    [Serializable]
    public class SysAdmins
    {
        public int SysAdminId { get; set; }
        public string SysAccount { get; set; }
        public string AdminName { get; set; }
        public string AdminPwd { get; set; }
    }
}
