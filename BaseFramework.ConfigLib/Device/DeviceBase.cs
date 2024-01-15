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
    /// ����ί��ԭ��
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void AlarmTriggerEventDelegate(object sender, AlarmEventArgs e);
    public class DeviceBase
    {
        /// <summary>
        /// �豸����
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// �豸�Ƿ񼤻�
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// ��ǰ�豸������״̬
        /// </summary>
        [JsonIgnore]
        public bool IsConnected { get; set; }

        /// <summary>
        /// �Ƿ����״�����
        /// </summary>
        [JsonIgnore]
        public bool IsFirstConnect { get; set; } = true;

        /// <summary>
        /// ��������
        /// </summary>
        [JsonIgnore]
        public int ReConnectTime { get; set; } = 2000;

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [JsonIgnore]
        public int SleepTime { get; set; } = 10;

        /// <summary>
        /// ��С��
        /// </summary>
        [JsonIgnore]
        public int DataFormat { get; set; } = 0;

        /// <summary>
        /// �������
        /// </summary>
        [JsonIgnore]
        public int ErrorTimes { get; set; }

        /// <summary>
        /// �ݴ����
        /// </summary>
        [JsonIgnore]
        public int AllowErrorTimes { get; set; } = 3;

        /// <summary>
        /// ���߳�ȡ��Դ��־λ
        /// </summary>
        [JsonIgnore]
        public CancellationTokenSource Cts { get; set; }

        /// <summary>
        /// ��ʱ��
        /// </summary>
        [JsonIgnore]
        public Stopwatch Stopwatch { get; set; }

        /// <summary>
        /// ���й鵵�����ļ���
        /// </summary>
        [JsonIgnore]
        public List<VariableBase> StoreVarList { get; set; } = new List<VariableBase>();

        /// <summary>
        /// ���б����ļ���
        /// </summary>
        [JsonIgnore]
        public List<VariableBase> VarList { get; set; } = new List<VariableBase>();

        /// <summary>
        /// ���б���������ֵ�ļ���
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, object> CurrentValue { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// ��������ͨ��������ȡ������
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
        /// ʵʱ����
        /// </summary>
        /// <param name="variable"></param>
        public void Update(VariableBase variable)
        {
            //���´���
            if (CurrentValue.ContainsKey(variable.VarName))
            {
                CurrentValue[variable.VarName] = variable.VarValue;
            }
            else
            {
                CurrentValue.Add(variable.VarName, variable.VarValue);
            }

            //��������
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
                        //ͨ���¼���֪ͨ

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
                        //ͨ���¼���֪ͨ

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
        /// �����������¼�
        /// </summary>
        public event AlarmTriggerEventDelegate AlarmTriggerEvent;

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAlarmAckEvent(object sender, AlarmEventArgs e)
        {
            AlarmTriggerEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// �����Ƚ�
        /// </summary>
        /// <param name="current">��ǰֵ</param>
        /// <param name="set">����ֵ</param>
        /// <param name="last">����ֵ</param>
        /// <param name="isPositive">�����ػ����½���</param>
        /// <returns>�ȽϽ����1��ʾ������-1��ʾ������0��ʾ�ޱ仯</returns>
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
        /// ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ǰֵ
        /// </summary>
        public string CurrentValue { get; set; }

        /// <summary>
        /// ����˵��
        /// </summary>
        public string AlarmNote { get; set; }

        /// <summary>
        /// �����趨ֵ
        /// </summary>
        public string SetValue { get; set; }

        /// <summary>
        /// �Ƿ�Ϊ����
        /// </summary>
        public bool  IsTrigger { get; set; }
    }
}
