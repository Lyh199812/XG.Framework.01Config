using Microsoft.Win32;












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ToolsLib
{
    /// <summary>
    /// 注册表
    /// </summary>
    public class RegeditHelper
    {
        private const string SUB_KEY = "SOFTWARE";
        private static readonly RegistryKey HKML;
        private static readonly RegistryKey SOFTWARE;

        static RegeditHelper()
        {
            //Win10 读写LocalMachine权限，没有访问权限
            HKML = Registry.CurrentUser;
            SOFTWARE = HKML.OpenSubKey(SUB_KEY, true);
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="name">名称</param>
        /// <returns>返回数据</returns>
        public static object ReadData(string node, string name)
        {
            RegistryKey tmp = SOFTWARE.OpenSubKey(node, true);
            object result = tmp?.GetValue(name);
            tmp?.Close();
            return result;
        }

        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="item">名称</param>
        /// <param name="value">值</param>
        public static void WriteData(string node, string item, object value)
        {
            RegistryKey tmp = SOFTWARE.CreateSubKey(node);
            tmp?.SetValue(item, value);
            tmp?.Close();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="item">名称</param>
        /// <param name="value">值</param>
        public static void DeleteNode(string node)
        {
            SOFTWARE.DeleteSubKey(node);
        }

    }
}
