using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BaseFramework.Common
{
    /// <summary>
    /// 基于正则表达式的验证类
    /// </summary>
    public class DataValidate
    {
        //正则表达式：其实就是对数据格式的一个使用特殊符号的约束
       
        /// <summary>
        /// 验证IP地址
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string txt)
        {
            Regex reg = new Regex(@"\d+\.\d+\.\d+\.\d");
            return reg.IsMatch(txt);
        }

        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsInteger(string txt)
        {
            return  new Regex(@"^[1-9]\d*$").IsMatch(txt);
        }

    }
}
