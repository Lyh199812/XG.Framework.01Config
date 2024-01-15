











using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BaseFramework.ToolsLib
{
    public class JsonHelper
    {
        /// <summary>
        /// 使用Newtonsoft.json.dll对象序列化成Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string EntityToJson<T>(T t)
        {
            try
            {
                return JsonConvert.SerializeObject(t);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 使用Newtonsoft.json.dll 将Json字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToEntity<T>(string json)
        {
            try
            {
                return (T)JsonConvert.DeserializeObject(json,typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 实体类转换成JSON字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string EntityToJson2<T>(T obj)
        {
            //序列化
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            MemoryStream msObj = new MemoryStream();
            //将序列化之后的Json格式数据写入流中
            js.WriteObject(msObj, obj);
            msObj.Position = 0;
            //从0这个位置开始读取流中的数据
            StreamReader sr = new StreamReader(msObj, Encoding.Default);
            string json = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            return json;
        }


        /// <summary>
        /// JSON字符串转换成实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToEntity2<T>(string json) where T : class
        {
            //反序列化
            using (var ms = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(T));
                T model = (T)deseralizer.ReadObject(ms);// //反序列化ReadObject
                return model;
            }
        }



    }
}
