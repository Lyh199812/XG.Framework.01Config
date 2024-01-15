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

namespace BaseFramework.ProConfigSys
{
    public partial class FrmProjects : Form
    {
        public FrmProjects()
        {
            InitializeComponent();
        }

        public FrmProjects(Projects model):this()
        {
            this.Text = "[项目信息管理]-重命名项目";
            this.btnSave.Text = "重命名项目";
            this.txt_ProjectName.Text = model.ProjectName;

            pModelFroReName = model;
        }

        ProjectsManager pManager = new ProjectsManager();
        Projects pModelFroReName = null;//使用时如果是null,则表示增加，否则就是表示修改

        //调用业务

        private void btnSave_Click(object sender, EventArgs e)
        {
            //数据验证
            if(this.txt_ProjectName.Text.Length==0)
            {
                MessageBox.Show("请输入项目名称！","提示信息");
                this.txt_ProjectName.Focus();
                return;
            }
            //封装对象
            Projects model = new Projects()
            {
                ProjectName = txt_ProjectName.Text.Trim()
            };
            if(this.pModelFroReName == null)
            {
                if (pManager.IsRepeatForInsert(this.txt_ProjectName.Text.Trim()))
                {
                    MessageBox.Show("项目名称已经存在!", "提示信息");
                    this.txt_ProjectName.Focus();
                    return;
                }
                InsertModel(model);
            }
            else
            {
                if (pManager.IsRepeatForUpdate(this.txt_ProjectName.Text.Trim(),this.pModelFroReName.ProjectId))
                {
                    MessageBox.Show("其他项目已经使用此名称，不允许重复!", "提示信息");
                    this.txt_ProjectName.Focus();
                    return;
                }
                model.ProjectId=this.pModelFroReName.ProjectId;
                UpdateModel(model);

            }
           
          
        }

        #region [保存项目独立方法]-【新增、重命名】
        private void InsertModel(Projects model)
        {
            try
            {
                model.ProjectId = pManager.Insert(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库返回错误:" + ex.Message, "错误提示");
                return;
            }
            //返回数据
            this.Tag = model;
            this.DialogResult = DialogResult.OK;
        }


        private void UpdateModel(Projects model)
        {
            try
            {
                model.ProjectId = pManager.Update(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库返回错误:" + ex.Message, "错误提示");
                return;
            }
            //返回数据
            this.Tag = model.ProjectName;
            this.DialogResult = DialogResult.OK;
        }
        #endregion


    }
}
