using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace SwaggerApiDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class MyJson
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static HttpResponseMessage ObjectToJson(object obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string r = js.Serialize(obj);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(r, Encoding.UTF8, "text/json")
            };
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static HttpResponseMessage ObjectToJson(List<object> objs)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string r = js.Serialize(objs);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(r, Encoding.UTF8, "text/json")
            };
            return result;
        }
    }
}