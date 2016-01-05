using System;
using System.Collections.Specialized;

namespace WcfFrameWork.Services.Filters
{
    public class MonitorLog
    {
        public string FuncName
        {
            get;
            set;
        }

        public DateTime ExecuteStartTime
        {
            get;
            set;
        }
        public DateTime ExecuteEndTime
        {
            get;
            set;
        }
        /// <summary>
        /// Form 表单数据
        /// </summary>
        public string Params
        {
            get;
            set;
        }

        /// <summary>
        /// 获取监控指标日志
        /// </summary>
        /// <param name="mtype"></param>
        /// <returns></returns>
        public string GetLoginfo()
        {
            string top = "Operation执行监控：";
            string Msg = @"
            {0}
            FuncName：{1}
            开始时间：{2}
            结束时间：{3}
            总 时 间：{4}秒
            操作参数：{5}
                    ";
            return string.Format(Msg,
                top,
                FuncName,
                ExecuteStartTime,
                ExecuteEndTime,
                (ExecuteEndTime - ExecuteStartTime).TotalSeconds,
                Params
                );
        }

        /// <summary>
        /// 获取Post 或Get 参数
        /// </summary>
        /// <param name="Collections"></param>
        /// <returns></returns>
        public string GetCollections(NameValueCollection Collections)
        {
            string Parameters = string.Empty;
            if (Collections == null || Collections.Count == 0)
            {
                return Parameters;
            }
            foreach (string key in Collections.Keys)
            {
                Parameters += string.Format("{0}={1}&", key, Collections[key]);
            }
            if (!string.IsNullOrWhiteSpace(Parameters) && Parameters.EndsWith("&"))
            {
                Parameters = Parameters.Substring(0, Parameters.Length - 1);
            }
            return Parameters;

        }

    }
}
