using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseFramework.ConfigLib
{
    /// <summary>
    /// 报警委托原型
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void AlarmTriggerEventDelegate(object sender, AlarmEventArgs e);
    public class DeviceBase
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 设备是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 当前设备的连接状态
        /// </summary>
        [JsonIgnore]
        public bool IsConnected { get; set; }

        /// <summary>
        /// 是否是首次连接
        /// </summary>
        [JsonIgnore]
        public bool IsFirstConnect { get; set; } = true;

        /// <summary>
        /// 重连周期
        /// </summary>
        [JsonIgnore]
        public int ReConnectTime { get; set; } = 2000;

        /// <summary>
        /// 休眠时间
        /// </summary>
        [JsonIgnore]
        public int SleepTime { get; set; } = 10;

        /// <summary>
        /// 大小端
        /// </summary>
        [JsonIgnore]
        public int DataFormat { get; set; } = 0;

        /// <summary>
        /// 出错次数
        /// </summary>
        [JsonIgnore]
        public int ErrorTimes { get; set; }

        /// <summary>
        /// 容错次数
        /// </summary>
        [JsonIgnore]
        public int AllowErrorTimes { get; set; } = 3;

        /// <summary>
        /// 多线程取消源标志位
        /// </summary>
        [JsonIgnore]
        public CancellationTokenSource Cts { get; set; }

        /// <summary>
        /// 计时器
        /// </summary>
        [JsonIgnore]
        public Stopwatch Stopwatch { get; set; }

        /// <summary>
        /// 所有归档变量的集合
        /// </summary>
        [JsonIgnore]
        public List<VariableBase> StoreVarList { get; set; } = new List<VariableBase>();

        /// <summary>
        /// 所有变量的集合
        /// </summary>
        [JsonIgnore]
        public List<VariableBase> VarList { get; set; } = new List<VariableBase>();

        /// <summary>
        /// 所有变量名称与值的集合
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, object> CurrentValue { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 索引器，通过键名获取到数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [JsonIgnore]
        public object this[string key]
        {
            get
            {
                if (CurrentValue.ContainsKey(key))
                {
                    return CurrentValue[key];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 实时更新
        /// </summary>
        /// <param name="variable"></param>
        public void Update(VariableBase variable)
        {
            //更新处理
            if (CurrentValue.ContainsKey(variable.VarName))
            {
                CurrentValue[variable.VarName] = variable.VarValue;
            }
            else
            {
                CurrentValue.Add(variable.VarName, variable.VarValue);
            }

            //报警处理
            if (variable.HighAlarmEnable || variable.LowAlarmEnable)
            {
                float compareValue = 0.0f;

                if (variable.VarType.ToLower() == "bool")
                {
                    compareValue = Convert.ToBoolean(variable.VarValue) ? 1.0f : 0.0f;
                }
                else
                {
                    compareValue = Convert.ToSingle(variable.VarValue);
                }

                int compareResult = 0;

                if (variable.HighAlarmEnable)
                {
                    compareResult = Compare(compareValue, variable.HighAlarmValue, variable.HighAlarmCacheValue, true);

                    if (compareResult != 0)
                    {
                        //通过事件做通知

                        OnAlarmAckEvent(variable, new AlarmEventArgs()
                        {
                            Name=variable.VarName,
                            CurrentValue=variable.VarValue.ToString(),
                            SetValue=variable.HighAlarmValue.ToString(),
                            AlarmNote=variable.HighAlarmNote,
                            IsTrigger=compareResult==1
                        });
                    }

                    variable.HighAlarmCacheValue = compareValue;
                }

                else
                {
                    compareResult = Compare(compareValue, variable.LowAlarmValue, variable.LowAlarmCacheValue, false);

                    if (compareResult != 0)
                    {
                        //通过事件做通知

                        OnAlarmAckEvent(variable, new AlarmEventArgs()
                        {
                            Name = variable.VarName,
                            CurrentValue = variable.VarValue.ToString(),
                            SetValue = variable.LowAlarmValue.ToString(),
                            AlarmNote = variable.LowAlarmNote,
                            IsTrigger = compareResult == 1
                        });

                    }
                    variable.LowAlarmCacheValue = compareValue;
                }
            }       
        }

        /// <summary>
        /// 报警触发的事件
        /// </summary>
        public event AlarmTriggerEventDelegate AlarmTriggerEvent;

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAlarmAckEvent(object sender, AlarmEventArgs e)
        {
            AlarmTriggerEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// 报警比较
        /// </summary>
        /// <param name="current">当前值</param>
        /// <param name="set">设置值</param>
        /// <param name="last">缓存值</param>
        /// <param name="isPositive">上升沿还是下降沿</param>
        /// <returns>比较结果，1表示触发，-1表示消除，0表示无变化</returns>
        private int Compare(float current, float set, float last, bool isPositive)
        {
            if (isPositive)
            {
                if (current >= set && last < set)
                {
                    return 1;
                }
                if (current < set && last >= set)
                {
                    return -1;
                }
            }
            else
            {
                if (current <= set && last > set)
                {
                    return 1;
                }
                if (current > set && last <= set)
                {
                    return -1;
                }
            }
            return 0;
        }
    }

    public class AlarmEventArgs : EventArgs
    {
        /// <summary>
        /// 变量名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前值
        /// </summary>
        public string CurrentValue { get; set; }

        /// <summary>
        /// 报警说明
        /// </summary>
        public string AlarmNote { get; set; }

        /// <summary>
        /// 报警设定值
        /// </summary>
        public string SetValue { get; set; }

        /// <summary>
        /// 是否为触发
        /// </summary>
        public bool  IsTrigger { get; set; }
    }
}
