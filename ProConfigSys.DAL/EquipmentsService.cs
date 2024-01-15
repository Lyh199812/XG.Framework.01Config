using ProConfig.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace ProConfigSys.DAL
{
    /// <summary>
    /// 设备数据访问类
    /// </summary>
    public class EquipmentsService
    {
        #region 设备类型和协议类型查询
        /// <summary>
        /// 获取所有的设备类型
        /// </summary>
        /// <returns></returns>
        public List<EquipmentType> GetAllEType()
        {
            string sql = "select ETypeId,ETypeName from EquipmentType";
            List<EquipmentType> list = new List<EquipmentType>();
            SqlDataReader reader=SQLHelper.ExecuteReader(sql);
            while (reader.Read())
            {
                list.Add(new EquipmentType()
                {
                    ETypeId = (int)reader["ETypeId"],
                    ETypeName = reader["ETypeName"].ToString()
                });
            }
            reader.Close();
            return list;

        }



        /// <summary>
        /// 根据设备类型获取对应的协议类型
        /// </summary>
        /// <returns></returns>
        public List<ProtocolType> GetPTypeByEType(int eTypeId)
        {
            string sql = "select PTypeId,PTypeName from ProtocolType where ETypeId=@ETypeId";
            List<ProtocolType> list = new List<ProtocolType>();
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@ETypeId",eTypeId)
            };
                
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, sqlParameter);
            while (reader.Read())
            {
                list.Add(new ProtocolType()
                {
                    PTypeId = (int)reader["PTypeId"],
                    PTypeName = reader["PTypeName"].ToString()
                });
            }
            reader.Close();
            return list;

        }
        #endregion


        #region 新增设备

        /// <summary>
        /// 新增设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(Equipments model)
        {
            string sql = "Insert into Equipments([ProjectId], [ETypeId], [PTypeId], [EquipmentName], [IPAddress], [PortNo], [SerialNo], [BaudRate], [DataBit], [ParityBit], [StopBit], [OPCNodeName], [OPCServerName], [IsEnable], [Comments])";
            sql += " values(@ProjectId, @ETypeId, @PTypeId, @EquipmentName, @IPAddress, @PortNo, @SerialNo, @BaudRate, @DataBit, @ParityBit, @StopBit, @OPCNodeName, @OPCServerName, @IsEnable, @Comments)";
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@ProjectId",model.ProjectId),
                new SqlParameter("@ETypeId",model.ETypeId),
                new SqlParameter("@PTypeId",model.PTypeId),
                new SqlParameter("@EquipmentName",model.EquipmentName),
                new SqlParameter("@IPAddress",model.IPAddress),
                new SqlParameter("@PortNo",model.PortNo),
                new SqlParameter("@SerialNo",model.SerialNo),

                new SqlParameter("@BaudRate",model.BaudRate),
                new SqlParameter("@DataBit",model.DataBit),
                new SqlParameter("@ParityBit",model.ParityBit),
                new SqlParameter("@StopBit",model.StopBit),

                new SqlParameter("@OPCNodeName",model.OPCNodeName),
                new SqlParameter("@OPCServerName",model.OPCServerName),
                new SqlParameter("@IsEnable",model.IsEnable),
                new SqlParameter("@Comments",model.Comments)
            };
            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql, parameter));

        }

        /// <summary>
        /// 新增设备，同一项目验证是否设备重名
        /// </summary>
        /// <param name="eName">设备名称</param>
        /// <param name="pId">当前项目编号</param>
        /// <returns></returns>
        public bool IsRepeatForInsert(string eName, int pId)
        {
            string sql = "select count(*) from Equipments where EquipmentName =@EquipmentName and ProjectId=@ProjectId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@EquipmentName",eName),
                new SqlParameter("@ProjectId",pId)
            };
            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql, param)) == 0 ? false : true;
        }
        #endregion


        /// <summary>
        /// 根据项目编号，查询对应设备类型的设备信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public Dictionary<int,List<Equipments>> QueryEquipments(int projectId)
        {
            string sql = "select [EquipmentId], [ProjectId], Equipments.[ETypeId], Equipments.[PTypeId], [EquipmentName], "
                +
                "[IPAddress], [PortNo]," 
                +
                " [SerialNo], [BaudRate], [DataBit], [ParityBit], [StopBit], " 
                +
                "[OPCNodeName], [OPCServerName], [IsEnable], [Comments], ETypeName,PTypeName from Equipments";
            sql += " inner join EquipmentType on EquipmentType.ETypeId=Equipments.ETypeId";
            sql += " inner join ProtocolType on ProtocolType.PTypeId=Equipments.PTypeId";
            sql += " where ProjectId =@ProjectId";

            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@ProjectId",projectId) };

            SqlDataReader reader=SQLHelper.ExecuteReader(sql, param);
            //定义三个集合，分别用来封装不同设备类型的设备信息
            List<Equipments> list_Internet=new List<Equipments>();
            List<Equipments> list_SerialPort=new List<Equipments>();
            List<Equipments> list_OPC=new List<Equipments>();

            //定义字典集合，封装上面三个List集合
            Dictionary<int,List<Equipments>> dicResault = new Dictionary<int, List<Equipments>>
            {
                [100]=list_Internet,
                [101]=list_SerialPort,
                [102]=list_OPC
            };

            while(reader.Read())
            {
                Equipments model =new Equipments();
                //封装公共属性
                model.EquipmentId = (int)reader["EquipmentId"];
                model.EquipmentName = reader["EquipmentName"].ToString();
                model.ETypeId = (int)reader["ETypeId"];
                model.PTypeId = (int)reader["PTypeId"];
                model.ProjectId = (int)reader["ProjectId"];
                model.IsEnable = (int)reader["IsEnable"];
                model.Comments = reader["Comments"].ToString();
                model.ETypeName = reader["ETypeName"].ToString() ;
                model.PTypeName = reader["PTypeName"].ToString();


                //封装私有属性
                if(model.ETypeId==100)
                {
                    model.SN = list_Internet.Count + 1;
                    model.IPAddress = reader["IPAddress"].ToString();
                    model.PortNo = reader["PortNo"].ToString();
                    list_Internet.Add(model);

                }
                else if(model.ETypeId==101)
                {
                    model.SN = list_SerialPort.Count + 1;
                    model.SerialNo = reader["SerialNo"].ToString();
                    model.BaudRate = (int)reader["BaudRate"];
                    list_SerialPort.Add(model);
                }
                else if(model.ETypeId==102)
                {
                    model.SN = list_OPC.Count + 1;
                    model.OPCNodeName = reader["OPCNodeName"].ToString();
                    model.OPCNodeName = reader["OPCServerName"].ToString();
                    list_OPC.Add(model);
                }

            }

            reader.Close();
            return dicResault;

        }



        #region 修改设备

        /// <summary>
        /// 新增设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Equipments model)
        {
            string sql = "Update  Equipments set PTypeId=@PTypeId, [EquipmentName]=@EquipmentName, [IPAddress]=@IPAddress, [PortNo]=@PortNo, [SerialNo]=@SerialNo, [BaudRate]=@BaudRate, [DataBit]=@DataBit, [ParityBit]=@ParityBit, [StopBit]=@StopBit, [OPCNodeName]=@OPCNodeName, [OPCServerName]=@OPCServerName, [IsEnable]=@IsEnable, [Comments]=@Comments";
            sql += " where EquipmentId =@EquipmentId";
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@PTypeId",model.PTypeId),
                new SqlParameter("@EquipmentName",model.EquipmentName),
                new SqlParameter("@IPAddress",model.IPAddress),
                new SqlParameter("@PortNo",model.PortNo),
                new SqlParameter("@SerialNo",model.SerialNo),

                new SqlParameter("@BaudRate",model.BaudRate),
                new SqlParameter("@DataBit",model.DataBit),
                new SqlParameter("@ParityBit",model.ParityBit),
                new SqlParameter("@StopBit",model.StopBit),

                new SqlParameter("@OPCNodeName",model.OPCNodeName),
                new SqlParameter("@OPCServerName",model.OPCServerName),
                new SqlParameter("@IsEnable",model.IsEnable),
                new SqlParameter("@Comments",model.Comments),
                new SqlParameter("@EquipmentId",model.EquipmentId),
            };
            return Convert.ToInt32(SQLHelper.ExecuteNonQuery(sql, parameter));

        }

        /// <summary>
        /// 修改设备，同一项目验证是否设备重名
        /// 要求：同一个项目，修改的时候其他的设备名称不能和修改后的冲突
        /// </summary>
        /// <param name="eName">设备名称</param>
        /// <param name="pId">当前项目编号</param>
        /// <param name="eId">当前设备编号</param>
        /// <returns></returns>
        public bool IsRepeatForUpdate(string eName, int pId,int eId)
        {
            string sql = "select count(*) from Equipments where EquipmentName =@EquipmentName and ProjectId=@ProjectId and EquipmentId<>@EquipmentId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@EquipmentName",eName),
                new SqlParameter("@ProjectId",pId),
                new SqlParameter("@EquipmentId",eId)
            };
            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql, param)) == 0 ? false : true;
        }
        #endregion
    }
}
