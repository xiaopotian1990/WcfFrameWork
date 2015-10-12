using System;

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
        public object[] Params
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
                GetCollections(Params)
                );
        }

        /// <summary>
        /// 获取Post 或Get 参数
        /// </summary>
        /// <param name="Collections"></param>
        /// <returns></returns>
        public string GetCollections(object[] Collections)
        {
            string result = "";
            foreach (var a in Collections)
            {
                result += a.ToString() + "|";
            }
            return result;
        }

    }
}
