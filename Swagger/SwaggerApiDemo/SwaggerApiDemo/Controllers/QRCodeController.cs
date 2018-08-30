using SwaggerApiDemo.Tools;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Http;

namespace SwaggerApiDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class QRCodeController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTaskID"></param>
        /// <returns></returns>
        public string GenerateErCodesByTaskId(string strTaskID)
        {
            string strPhysicsPath = HttpContext.Current.Server.MapPath(Config.AccPath + "Temp/QrCodeImages");//图片保存地址
            if (!Directory.Exists(strPhysicsPath))
            {
                Directory.CreateDirectory(strPhysicsPath);
            }
            //删除已经生成的taskid的图片
            DirectoryInfo sourceInfo = new DirectoryInfo(strPhysicsPath);
            FileInfo[] fileInfo = sourceInfo.GetFiles();
            foreach (FileInfo fiTemp in fileInfo)
            {
                var path = strPhysicsPath.TrimEnd('\\') + "/" + fiTemp.Name;
                File.Delete(path);
            }
            string content = "http://www.baidu.com";
            string logopath = HttpContext.Current.Server.MapPath(Config.LogoPath + "Images/logo.png");
            Bitmap image = QRCodeHelper.CreateQRCodeWithLogo(content, logopath);

            string pictureName = "/" + strTaskID + ".png"; //图片保存的命名
            string filePath = strPhysicsPath.TrimEnd('\\') + pictureName;
            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

            string retfilePath = CommonFuns.GetFullPath(CommonFuns.urlConvertor(filePath));
            return retfilePath;
        }
    }
}
