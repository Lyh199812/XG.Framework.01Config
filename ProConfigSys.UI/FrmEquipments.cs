using BaseFramework.Common;
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
    public partial class FrmEquipments : Form
    {
        private EquipmentManager eManager=new EquipmentManager();
        private Projects m_Project=null;

        public bool isModfiy=false;//默认是false表示《新增》

        private Equipments update_model = null;//要修改的设备对象
        EquipmentType CurrentEType;
        public FrmEquipments(Projects project)
        {
            InitializeComponent();

            //绑定设备类型
            this.cmb_EType.DataSource = eManager.GetAllEType();
            this.cmb_EType.DisplayMember = "ETypeName";
            this.cmb_EType.ValueMember = "ETypeId";
            this.cmb_EType.SelectedIndex = -1;

            //绑定串口下拉框（其他的都已经直接设置）
            string[] partityItems = new string[] { "N", "0", "1" };
            this.cmb_ParityBit.Items.AddRange(partityItems);
            
            //显示设备信息
            this.m_Project = project;
            this.lblProjectName.Text = m_Project.ProjectName;

            //给串口配置设置默认值
            this.cmb_BaudRate.SelectedIndex = 0;
            this.cmb_DataBit.SelectedIndex = 0;
            this.cmb_ParityBit.SelectedIndex = 0;
            this.cmb_StopBit.SelectedIndex = 0;

        }

        public FrmEquipments(Projects project,Equipments model):this(project)
        {
            this.btn_Save.Text = "修改设备信息";
            this.Text = this.Text + "- [修改设备信息]";
            this.isModfiy = true;
            this.update_model= model;

            //显示要修改的信息
            this.txt_EquipmentName.Text=model.EquipmentName;
            this.cmb_EType.Text = model.ETypeName;
            this.cmb_PType.Text = model.PTypeName;
            this.txt_Commons.Text = model.Comments;
            this.ckb_IsEnable.Checked=Convert.ToBoolean(model.IsEnable);

            if(model.ETypeId==100)//以太网
            {
                this.txt_IPAddress.Text = model.IPAddress;
                this.txt_PortNo.Text= model.PortNo;
            }
            else if(model.ETypeId==101)//串口
            {
                this.cmb_SerialNo.Text = model.SerialNo;
                this.cmb_BaudRate.Text = model.BaudRate.ToString();
                this.cmb_DataBit.Text = model.DataBit.ToString();
                this.cmb_ParityBit.Text=model.ParityBit.ToString();
                this.cmb_StopBit.Text = model.StopBit.ToString();


            }
            else if(model.ETypeId==102)//opc
            {
                this.txt_OPCNodeName.Text = model.OPCNodeName;
                this.txt_OPCServerName.Text = model.OPCServerName;
            }
            //禁用设备类型（如果允许被修改，会造成程序太麻烦）
            this.cmb_EType.Enabled = false;
        }

        #region 设备类型选择联动
        private void cmb_EType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //复位
            {
                //禁用所有的分组
                this.gb_Internet.Enabled = this.gb_Com.Enabled = this.gb_OPC.Enabled = false;
                this.gb_Internet.BackColor = Color.FromArgb(((int)(byte)(128)), ((int)(byte)(255)), ((int)(byte)(255)));
                this.gb_Com.BackColor = Color.FromArgb(((int)(byte)(128)), ((int)(byte)(255)), ((int)(byte)(255)));
                this.gb_OPC.BackColor = Color.FromArgb(((int)(byte)(128)), ((int)(byte)(255)), ((int)(byte)(255)));

            }
            //根据设备类型同步绑定协议类型
            CurrentEType = this.cmb_EType.SelectedItem as EquipmentType;
            if (CurrentEType == null)
            {
                this.cmb_PType.DataSource = null;
                this.cmb_PType.SelectedIndex = -1;
                return;
            }
            if (this.cmb_EType.Text.Contains("以太网"))
            {
                this.gb_Internet.Enabled = true;
                this.gb_Internet.BackColor = Color.FromArgb(((int)(byte)(128)), ((int)(byte)(128)), ((int)(byte)(255)));
            }
            else if (this.cmb_EType.Text.Contains("串口"))
            {
                this.gb_Com.Enabled = true;
                this.gb_Com.BackColor = Color.FromArgb(((int)(byte)(128)), ((int)(byte)(128)), ((int)(byte)(255)));
            }
            else if (this.cmb_EType.Text.Contains("OPC"))
            {
                this.gb_OPC.Enabled = true;
                this.gb_OPC.BackColor = Color.FromArgb(((int)(byte)(128)), ((int)(byte)(128)), ((int)(byte)(255)));
            }
            this.cmb_PType.DataSource = eManager.GetPTypeByEType(CurrentEType.ETypeId);
            this.cmb_PType.DisplayMember = "PTypeName";
            this.cmb_PType.ValueMember = "PTypeId";
        }
        #endregion


        #region 保存设备信息
        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if(this.txt_EquipmentName.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入设备名称！","提示信息");
                this.txt_EquipmentName.Focus();
                return;
            }
            if(this.cmb_EType.SelectedIndex==-1)
            {
                MessageBox.Show("请选择设备类型！","提示信息");
                return;
            }
            if(this.cmb_PType.SelectedIndex==-1)
            {
                MessageBox.Show("请选择协议类型！","提示信息");
                return;
            }

            //如果是以太网类型
            if(Convert.ToInt32(this.cmb_EType.SelectedValue) == 100)
            {
                if(this.txt_IPAddress.Text.Trim().Length==0||this.txt_PortNo.Text.Length==0)
                {
                    MessageBox.Show("请填写完整的(以太网)配置信息！","验证提示");
                    return;
                }
                //格式验证（使用正则表达式）
                if(!DataValidate.IsIPAddress(this.txt_IPAddress.Text.Trim()))    
                {
                    MessageBox.Show("IP地址格式不符合要求！", "验证提示");
                    this.txt_IPAddress.SelectAll();
                    return;
                }

                if (!DataValidate.IsInteger(this.txt_PortNo.Text.Trim()))
                {
                    MessageBox.Show("端口号格式不符合要求！", "验证提示");
                    this.txt_PortNo.SelectAll();
                    return;
                }


            }
            else if (Convert.ToInt32(this.cmb_EType.SelectedValue) == 101)
            {
                if(this.cmb_SerialNo.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择端口号！", "验证提示");
                    return;
                }
            }
            else if (Convert.ToInt32(this.cmb_EType.SelectedValue) == 102)
            {
                if (this.txt_OPCNodeName.Text.Trim().Length == 0|| this.txt_OPCServerName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("请填写完整的OPC配置信息！", "提示信息");
                    return;
                }
            }

            #endregion

            #region 封装对象
            Equipments model = new Equipments()
            {
                EquipmentName = this.txt_EquipmentName.Text.Trim(),
                ProjectId = this.m_Project.ProjectId,
                ETypeId=Convert.ToInt32(this.cmb_EType.SelectedValue),
                PTypeId=Convert.ToInt32(this.cmb_PType.SelectedValue),
                Comments=this.txt_Commons.Text.Trim(),
                IsEnable=this.ckb_IsEnable.Checked?1:0,
                ETypeName=this.cmb_EType.Text.Trim(),
                PTypeName=this.cmb_PType.Text.Trim(),
            };

            if(Convert.ToInt32(this.cmb_EType.SelectedValue)==100)
            {
                model.IPAddress=this.txt_IPAddress.Text.Trim();
                model.PortNo=this.txt_PortNo.Text.Trim();
            }
            else if(Convert.ToInt32(this.cmb_EType.SelectedValue) == 101)
            {
                model.SerialNo=this.cmb_SerialNo.Text.Trim();
                model.BaudRate=Convert.ToInt32(this.cmb_BaudRate.Text.Trim());
                model.DataBit=Convert.ToInt32(this.cmb_DataBit.Text.Trim());
                model.ParityBit=this.cmb_ParityBit.Text.Trim();
                model.StopBit=Convert.ToInt32(this.cmb_StopBit.Text.Trim());
            }
            else if (Convert.ToInt32(this.cmb_EType.SelectedValue) == 102)
            {
                model.OPCNodeName=this.txt_OPCNodeName.Text.Trim();
                model.OPCServerName=this.txt_OPCServerName.Text.Trim();
            }
            #endregion
            
            
            if(!this.isModfiy)
            {
                bool IsRepeat = eManager.IsRepeatForInsert(this.txt_EquipmentName.Text.Trim(), this.m_Project.ProjectId);
                if(IsRepeat)
                {
                    MessageBox.Show("设备名称不能重复!","提示信息");
                    this.txt_EquipmentName.SelectAll();
                    return;
                }
                InsertModel(model);
            }
            else
            {
                bool IsRepeat = eManager.IsRepeatForUpdate(this.txt_EquipmentName.Text.Trim(), this.m_Project.ProjectId, update_model.EquipmentId);
                if (IsRepeat)
                {
                    MessageBox.Show("设备名称不能重复!", "提示信息");
                    this.txt_EquipmentName.SelectAll();
                    return;
                }
                model.EquipmentId=this.update_model.EquipmentId;//修改需要使用这个Id
                UpdateModel(model);
            }
        }

        #region [保存设备信息] - 新增
        public void InsertModel(Equipments model)
        {
            try
            {
                model.EquipmentId = eManager.Insert(model);//提交到数据库，并返回生成的ID
            }
            catch (Exception ex)
            {

                MessageBox.Show("数据库返回错误：" + ex.Message, "错误提示");
                return;
            }
            //给主窗体返回数据
            this.Tag = model;
            this.DialogResult=DialogResult.OK;

        }

        #endregion


        #region [保存设备信息] - 修改
        public void UpdateModel(Equipments model)
        {
            try
            {
                model.EquipmentId = eManager.Update(model);//提交到数据库，并返回生成的ID
            }
            catch (Exception ex)
            {

                MessageBox.Show("数据库返回错误：" + ex.Message, "错误提示");
                return;
            }
            //给主窗体返回数据
            this.Tag = model;
            this.DialogResult = DialogResult.OK;

        }

        #endregion
        #endregion

        private void cmb_SerialNo_DropDown(object sender, EventArgs e)
        {
            //string[] coms = System.IO.Ports.SerialPort.GetPortNames();
            //if (coms.Length > 0)
            //{
            //    this.cmb_SerialNo.DataSource = null;
            //    this.cmb_SerialNo.DataSource = coms;
            //}
            this.cmb_SerialNo.DataSource = null;
            this.cmb_SerialNo.DataSource = new string[] { "COM1", "COM2", "COM3", "COM4" };
        }
    }
}
