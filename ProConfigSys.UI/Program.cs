using BaseFramework.ProConfigSys;
using ProConfig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //测试加密解密
            /*
             *    string connString = "Server = .;Database = ProConfigDB;User ID = sa;Password = pwd123;Trusted_Connection = true;TrustServerCertificate=true";
            //fo/s7UDDccRtwIuVsrgdyUPodZ1Q8+weYh+pc4IyEEsNlyRQPrvWKoIyV9oDSHX541BgN8kmdDhWszOrCjGQt+2PVX0t4ruDvgh1ZY8xzwSufHiJ47IPRylH52fbxChWfTGTihf9tsegQHsx/d6VhT2TFQWK4QoE
            string connString2 = BaseFramework.Common.StringSecurity.DESEncrypt(connString);
            string connString3= BaseFramework.Common.StringSecurity.DESDecrypt(connString2);
             */

            //显示登录窗体
            FrmAdminLogin frmAdminLogin = new FrmAdminLogin();
            DialogResult rst= frmAdminLogin.ShowDialog();
            if (rst == DialogResult.OK)
            {
                //在这个Run方法中运行的窗体是项目的主窗体，主窗体关闭，整个项目就关闭
                Application.Run(new FrmMain());

            }
            else
            {
                Application.Exit();
            }
        }

        //用于保存当前登录用户的变量
        public static SysAdmins currentAdmin = null;

    }
}
