using ProConfig.Models;
using ProConfigSys.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace BaseFramework.ProConfigSys
{
    public partial class FrmAdminLogin : Form
    {
        public FrmAdminLogin()
        {
            InitializeComponent();


            //检查是否保存了密码
            SysAdmins adminObj = adminManager.ReadPwd();
            if(adminObj != null )
            {
                this.txtAccount.Text = adminObj.SysAccount;
                this.txtPassword.Text = adminObj.AdminPwd;
                this.ckbSavePwd.Checked = true;
            }
            else
            {
                this.txtPassword.Clear();
                this.txtAccount.Clear();
                this.ckbSavePwd.Checked= false;
                this.txtAccount.Focus();

            }
        }
        private SysAdminsManager adminManager= new SysAdminsManager();
        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmAdminLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void FrmAdminLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void FrmAdminLogin_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //用户登录
        private void btnLoginSys_Click(object sender, EventArgs e)
        {
            if(this.txtAccount.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入登录账号！","提示信息");
                this.txtAccount.Focus();
                return;
            }

            if (this.txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入密码！", "提示信息");
                this.txtPassword.Focus();
                return;
            }

            //[2]封装对象
            SysAdmins admin = new SysAdmins()
            {
                SysAccount = this.txtAccount.Text,
                AdminPwd = this.txtPassword.Text
            };
            //[3]调用业务逻辑
            try
            {
                admin = adminManager.AdminLogin(admin);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"登录错误");
                return;
            }
            //[4]验证登录是否成功
            if(admin != null)
            {
                Program.currentAdmin=admin;
                //如果项目中还有其他的要求，可以在这里处理
                //账号有效性判断......
                //登录日志.......

                //保存用户登录信息，方便下次自动输入
                if(this.ckbSavePwd.Checked)
                {
                    adminManager.SavePwd(admin);
                }
                else
                {
                    adminManager.DeletePwd();
                }
                //设置窗体返回值
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("登录账号或密码错误","错误提示");
            }

        }
    }
}
