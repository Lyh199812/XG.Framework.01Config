using ProConfig.Models;
using ProConfigSys.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace BaseFramework.ProConfigSys
{
    public partial class FrmMain : Form
    {
        ProjectsManager pManager=new ProjectsManager();
        private EquipmentManager eManager=new EquipmentManager();
        public FrmMain()
        {
            InitializeComponent();
            //显示当前登录用户
            this.lblCurrentAdmin.Text = Program.currentAdmin.AdminName;

            this.dgv_Projects.AutoGenerateColumns = false;//禁止自动生成列
            this.dgv_Internet.AutoGenerateColumns= false;
            this.dgv_SerialPort.AutoGenerateColumns= false;
            this.dgv_OPC.AutoGenerateColumns = false;

            //默认显示全部项目信息
            this.projectList = pManager.Query();
            if(this.projectList.Count!=0 )
            {
                this.dgv_Projects.DataSource = this.projectList;
                this.btnDeleteProject.Enabled =this.btnReNameProject.Enabled= true;
            }
            else
            {
                this.btnDeleteProject.Enabled = this.btnReNameProject.Enabled = false;
            }
        }
        //用户退出
        /*
         * 要求：退出前询问，确保数据安全
         * 关于窗体关闭的理解；如果主窗体在运行中，打开了
         * 其他的窗体，其他窗体关闭，意味着这个被关闭的窗体
         * 不再显示了，很多时候，并不是这个窗体对象完全消失
         */

        //窗体关闭之前确认
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出询问",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(result==DialogResult.Cancel)
            {
                e.Cancel = true;//窗体取消关闭
            }

        }

        //窗体关闭之后（可以做一些清理的工作、临时数据的保存等）
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        //保存当前新增加的项目
        private List<Projects> projectList = new List<Projects>();

        #region [项目]-新增
        //创建新项目
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            FrmProjects frm = new FrmProjects();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Projects newProject = (Projects)frm.Tag;
                newProject.SN = this.projectList.Count + 1;
                //添加到集合并显示
                projectList.Add(newProject);
                this.dgv_Projects.DataSource = null;
                this.dgv_Projects.DataSource = projectList;

            }
        }


        #endregion


        #region [项目]-重命名
        private void btnReNameProject_Click(object sender, EventArgs e)
        {
            int pId = Convert.ToInt32( this.dgv_Projects.CurrentRow.Cells["ProjectId"].Value);

            Projects model = null;
            for(int i = 0;i<this.projectList.Count;i++)
            {
                if (projectList[i].ProjectId == pId)
                {
                    model = projectList[i]; break;
                }
            }
            //显示修改窗体
            FrmProjects frm = new FrmProjects(model);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                model.ProjectName = frm.Tag.ToString();
                this.dgv_Projects.Refresh();
            }
        }
        #endregion

        #region [项目]-删除
        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            int pId = Convert.ToInt32(this.dgv_Projects.CurrentRow.Cells["ProjectId"].Value.ToString());
            
            //删除确认
            if(MessageBox.Show("是否确认删除当前选中的项目？\r\n删除时会同时把所有设备、通讯组、变量信息一同删除!","删除警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.Cancel)
            {
                return;
            }
            try//从数据库删除
            {
                pManager.Delete(pId);
            }
            catch (Exception ex )
            {

                MessageBox.Show("数据库返回错误:" + ex.Message, "错误提示");
                return;
            }
            //从集合删除
            Projects pro = null;
            foreach (var item in this.projectList)
            {
                if (item.ProjectId == pId)
                {
                    pro = item; break;
                }
            }
            this.projectList.Remove(pro);
            //更新显示列表
            this.dgv_Projects.DataSource = null;
            if(this.projectList.Count > 0)
            {
                //如果集合中没有数据，就不要绑定，否则会出现错误！
                this.dgv_Projects.DataSource = projectList;

            }
        }

        #endregion


        public List<Equipments> equipmentList_Internet = new List<Equipments>();
        public List<Equipments> equipmentList_SerialPort = new List<Equipments>();
        public List<Equipments> equipmentList_OPC = new List<Equipments>();

        #region [设备管理]-新增设备
        private void butAddEquipment_Click(object sender, EventArgs e)
        {
            //判断是否选择一个项目          
            Projects project = this.dgv_Projects.CurrentRow.DataBoundItem as Projects;
            if (project == null)
            {
                MessageBox.Show("请先选择项目名称！", "提示信息");
                return;
            }
            FrmEquipments frm =new FrmEquipments(project);
            DialogResult result= frm.ShowDialog();
            if(result == DialogResult.OK)//如果设备信息添加成功
            {
                Equipments model = (Equipments)frm.Tag;
                if(model.ETypeId==100)
                {
                    model.SN=equipmentList_Internet.Count;
                    equipmentList_Internet.Add(model);
                    this.dgv_Internet.DataSource = null;
                    this.dgv_Internet.DataSource = equipmentList_Internet;
                }
                else if(model.ETypeId==101)
                {
                    model.SN = equipmentList_SerialPort.Count;
                    equipmentList_SerialPort.Add(model);
                    this.dgv_SerialPort.DataSource = null;
                    this.dgv_SerialPort.DataSource = equipmentList_SerialPort;
                }
                else if(model.ETypeId==102)
                {
                    model.SN = equipmentList_OPC.Count;
                    equipmentList_OPC.Add(model);
                    this.dgv_OPC.DataSource = null;
                    this.dgv_OPC.DataSource = equipmentList_OPC;
                }
            }
            
        }
        #endregion


    

        private void dgv_Projects_SelectionChanged(object sender, EventArgs e)
        {
            if(this.dgv_Projects.Rows.Count != 0 && this.dgv_Projects.CurrentRow !=null) 
            {
                int projectId = Convert.ToInt32(this.dgv_Projects.CurrentRow.Cells["ProjectId"].Value);
                ShowCurrentEquipments(projectId);
            }
            //同时个通信组和变量列表清空
            this.dgv_CG.DataSource = null;
            this.dgv_Variables.DataSource = null;
        }

        //定义存储设备信息的集合
        Dictionary<int, List<Equipments>> equipmentQueryDic = null;
        //List<Equipments> list_Internet = null;
        //List<Equipments> list_SerialPort = null;
        //List<Equipments> list_OPC = null;

        private void ShowCurrentEquipments(int projectId)
        {
            //查询，并分别放到三个集合中
            equipmentQueryDic=eManager.QueryEquipments(projectId);
            equipmentList_Internet = equipmentQueryDic[100];
            equipmentList_SerialPort = equipmentQueryDic[101];
            equipmentList_OPC = equipmentQueryDic[102];

            this.dgv_Internet.DataSource = null;
            this.dgv_SerialPort.DataSource = null;
            this.dgv_OPC.DataSource = null;

            if(equipmentList_Internet.Count > 0)
            {
                this.dgv_Internet.DataSource= equipmentList_Internet;
            }

            if(equipmentList_SerialPort.Count > 0)
            {
                this.dgv_SerialPort.DataSource= equipmentList_SerialPort;
            }

            if(equipmentList_OPC.Count > 0)
            {
                this.dgv_OPC.DataSource= equipmentList_OPC;
            }

        }


        #region [设备管理]-修改设备信息
        private void tmsi_update_Internet_Click(object sender, EventArgs e)
        {
            if (this.dgv_Internet.Rows.Count == 0 || this.dgv_Internet.CurrentRow == null)
            {
                return;
            }

            int equipmentId = Convert.ToInt32(this.dgv_Internet.CurrentRow.Cells["EquipmentId"].Value);
            UpdateEquipment(equipmentId, this.equipmentList_Internet, dgv_Internet);



        }

        private void tmsi_update_SerialPort_Click(object sender, EventArgs e)
        {
            if (this.dgv_SerialPort.Rows.Count == 0 || this.dgv_Internet.CurrentRow == null)
            {
                return;
            }

            int equipmentId = Convert.ToInt32(this.dgv_SerialPort.CurrentRow.Cells["EquipmentId2"].Value);
            UpdateEquipment(equipmentId, this.equipmentList_SerialPort, dgv_SerialPort);

        }

        private void tmsi_update_OPC_Click(object sender, EventArgs e)
        {
            if (this.dgv_OPC.Rows.Count == 0 || this.dgv_Internet.CurrentRow == null)
            {
                return;
            }

            int equipmentId = Convert.ToInt32(this.dgv_OPC.CurrentRow.Cells["EquipmentId3"].Value);
            UpdateEquipment(equipmentId, this.equipmentList_OPC, dgv_OPC);

        }

        private void UpdateEquipment(int equipmentId, List<Equipments> modelList, DataGridView dgv)
        {
            /*方法抽取的口诀
             * 抽取不变的，封装变化的；不变的作为方法体，变化
             * 的作为参数
             */

            //循环当前对应设备集合，根据Id找到对象
            int Index = 0;//当前要修改的对象在集合中的索引（修改后刷新使用）
            Equipments model = null;//当前要修改的对象
            for (int i = 0; i < modelList.Count; i++)
            {
                if (modelList[i].EquipmentId == equipmentId)
                {
                    model = modelList[i];
                    Index = i;
                    break;
                }
            }
            if (model == null)
            {
                MessageBox.Show("未选中对象");
                return;
            }

            //封装当前设备对应的项目
            Projects project = new Projects()
            {
                ProjectId = Convert.ToInt32(this.dgv_Projects.CurrentRow.Cells["ProjectId"].Value),
                ProjectName = this.dgv_Projects.CurrentRow.Cells["ProjectName"].Value.ToString()
            };
            //显示要修改的窗体
            FrmEquipments frm = new FrmEquipments(project, model);
            DialogResult result = frm.ShowDialog();
            //根据返回结果，同步更新显示
            if(result == DialogResult.OK)
            {
                dgv.DataSource = null;//这个清空一定要先写,放到后面就会出错


            }
        }
        #endregion

    }
}
