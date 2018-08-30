using System.Web;

namespace SwaggerApiDemo.Tools
{
    public class CommonFuns
    {
        /// <summary>
        /// 获取虚拟路径的全路径
        /// </summary>
        /// <param name="strPath">文件路径</param>
        /// <returns></returns>
        public static string GetFullPath(string strPath)
        {
            if (string.IsNullOrEmpty(strPath))
            {
                return string.Empty;
            }
            else if (strPath.Substring(0, 7).ToLower() == "http://" || strPath.Substring(0, 8).ToLower() == "https://")
            {
                return strPath;
            }
            else
            {
                return Config.ApiUrl.TrimEnd('/') + "/" + strPath.TrimStart('~', '/');
            }
        }

        /// <summary>  
        /// 绝对路径转相对路径(本地路径转换成URL相对路径)
        /// </summary>  
        /// <param name="strUrl"></param>  
        /// <returns></returns>  
        public static string urlConvertor(string strUrl)
        {
            string tmpRootDir = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录  
            string urlPath = strUrl.Replace(tmpRootDir, ""); //转换成相对路径  
            urlPath = urlPath.Replace(@"/", @"/");
            return urlPath;
        }

        #region 物理路径和相对路径的转换

        //相对路径转换成服务器本地物理路径 
        public static string urlconvertorlocal(string imagesurl1)
        {
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = tmpRootDir + imagesurl1.Replace(@"/", @"\"); //转换成绝对路径
            return imagesurl2;
        }
        #endregion
    }
}
