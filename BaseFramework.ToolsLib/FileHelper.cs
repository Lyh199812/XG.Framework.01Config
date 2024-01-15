











using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.ToolsLib
{
    public class FileHelper
    {
        #region 1.文本文件读写


        public static void WriteToTxt(string path, string content, bool isAppend = false)
        {
            //【1】创建文件流
            FileStream fileStream = new FileStream(path, isAppend ? FileMode.Append : FileMode.Create);

            //【2】创建写入器
            StreamWriter streamWriter = new StreamWriter(fileStream);

            //【3】以流的形式写入数据
            streamWriter.Write(content);

            //【4】关闭写入器
            streamWriter.Close();

            //【5】关闭文件流
            fileStream.Close();
        }


        public static string ReadFromTxt(string path)
        {
            //判断文件是否存在
            if (!File.Exists(path))
            {
                return string.Empty;
            }

            //【1】创建文件流
            FileStream fileStream = new FileStream(path, FileMode.Open);

            //【2】创建读取器
            StreamReader streamReader = new StreamReader(fileStream);

            //【3】以流的方式读取
            string content = streamReader.ReadToEnd();

            //【4】关闭读取器
            streamReader.Close();

            //【5】关闭文件流
            fileStream.Close();

            return content;

        }

        #endregion

        #region 2.对象序列化文件

        /// <summary>
        /// 序列化一个对象到一个文件中
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public static void SerializeObject(object obj, string path)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(path, FileMode.Create);

                BinaryFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(fileStream, obj);

            }
            catch (Exception ex)
            {
                throw new Exception("序列化对象出错：" + ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }


        public static T DeSerializeObject<T>(string path)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(path, FileMode.Open);

                BinaryFormatter binaryFormatter = new BinaryFormatter();

                return (T)binaryFormatter.Deserialize(fileStream);

            }
            catch (Exception ex)
            {
                throw new Exception("反序列化对象出错：" + ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }


        #endregion

        #region 3.对象序列化字符串

        /// <summary>
        /// 将对象序列化成字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObjToString(object obj)
        {
            IFormatter formatter = new BinaryFormatter();

            string result = string.Empty;

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);

                byte[] bytes = stream.ToArray();

                result = Convert.ToBase64String(bytes);

                stream.Flush();

            }
            return result;
        }

        /// <summary>
        /// 将字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeSerializeObjFromString<T>(string str) where T : class
        {
            IFormatter formatter = new BinaryFormatter();

            byte[] bytes = Convert.FromBase64String(str);

            T obj = null;

            using (MemoryStream stream = new MemoryStream(bytes, 0, bytes.Length))
            {
                obj = (T)formatter.Deserialize(stream);
            }

            return obj;
        }

        #endregion

        #region 4.文件的基本操作

        /// <summary>
        /// 文件复制
        /// </summary>
        /// <param name="srcFileName"></param>
        /// <param name="desFileName"></param>
        public static void CopyFile(string srcFileName, string desFileName)
        {
            if (File.Exists(desFileName))
            {
                File.Delete(desFileName);
            }

            File.Copy(srcFileName, desFileName);

        }


        /// <summary>
        /// 文件移动
        /// </summary>
        /// <param name="srcFileName"></param>
        /// <param name="desFileName"></param>
        public static void MoveFile(string srcFileName, string desFileName)
        {
            if (File.Exists(srcFileName))
            {
                if (File.Exists(desFileName))
                {
                    File.Delete(desFileName);
                }

                File.Move(srcFileName, desFileName);
            }
        }

        /// <summary>
        /// 文件删除
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        #endregion


        #region 5.文件夹的相关操作

        /// <summary>
        /// 获取指定目录下的所有文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        /// <summary>
        /// 获取指定目录下的所有子目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void CreateDirectory(string path)
        {
             Directory.CreateDirectory(path);
        }

        /// <summary>
        /// 删除指定目录下的所有子目录和文件
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            directory.Delete(true);
        }


        #endregion

    }
}
