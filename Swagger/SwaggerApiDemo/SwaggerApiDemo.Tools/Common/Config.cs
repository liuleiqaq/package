using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace SwaggerApiDemo.Tools
{
    public class Config
    {

        private static Dictionary<string, object> data = new Dictionary<string, object>();
        private static object _lock = new object();

        private Config()
        {
        }

        /// <summary>
        /// 附件文件的路径
        /// </summary>
        public static string AccPath
        {
            get
            {
                return GetConfig("AccSavePath");
            }
        }

        /// <summary>
        /// Api站点地址
        /// </summary>
        public static string ApiUrl
        {
            get
            {
                return GetConfig("ApiUrl");
            }
        }

        /// <summary>
        /// 扫码跳转地址
        /// </summary>
        public static string CodeScanUrl
        {
            get
            {
                return GetConfig("CodeScanUrl");
            }
        }

        /// <summary>
        /// 二维码Logo保存路径
        /// </summary>
        public static string LogoPath
        {
            get
            {
                return GetConfig("LogoPath");
            }
        }

        /// <summary>
        /// 获取配置值
        /// </summary>
        /// <param name="strKey">键</param>
        /// <param name="strDefaultValue">默认值</param>
        /// <returns></returns>
        public static string GetConfig(string strKey, string strDefaultValue = null)
        {
            string strValue = HttpContext.Current != null ? (string)HttpContext.Current.Application[strKey] : (data.ContainsKey(strKey) ? (string)data[strKey] : null);
            if (string.IsNullOrEmpty(strValue))
            {
                strValue = ConfigurationManager.AppSettings[strKey];
                if (string.IsNullOrEmpty(strValue) && !string.IsNullOrEmpty(strDefaultValue))
                {
                    strValue = strDefaultValue;
                }

                if (HttpContext.Current != null)
                {
                    HttpApplicationState application = HttpContext.Current.Application;
                    application.Lock();
                    application[strKey] = strValue;
                    application.UnLock();
                }
                else
                {
                    lock (_lock)
                    {
                        data[strKey] = strValue;
                    }
                }
            }

            return strValue;
        }
    }
}
