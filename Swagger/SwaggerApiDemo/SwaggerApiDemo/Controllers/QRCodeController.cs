
using SwaggerApiDemo.Tools;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        [HttpPost]
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
            //Bitmap image = QRCodeHelper.CreateQRCodeWithLogo(content, logopath);
            Bitmap image = QRCodeHelper.CreateQRCodeWithLogo(string.Format("{0}?taskid={1}", Config.CodeScanUrl, strTaskID), logopath);//生成二维码logo图片

            string pictureName = "/" + strTaskID + ".png"; //图片保存的命名
            string filePath = strPhysicsPath.TrimEnd('\\') + pictureName;
            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

            string retfilePath = CommonFunPaths.GetFullPath(CommonFunPaths.urlConvertor(filePath));
            return retfilePath;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<string> Getlist()
        {
            var list1 = new List<string>() { "1", "2", "3", "4" };
            var list2 = new List<string>() { "1", "2", "3", "4" };


            var list3 = list1.Intersect(list2).ToList();

            return list3;
        }



    }



}
