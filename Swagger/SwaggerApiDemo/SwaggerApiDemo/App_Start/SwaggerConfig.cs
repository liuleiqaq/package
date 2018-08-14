using SwaggerApiDemo;
using Swashbuckle.Application;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwaggerApiDemo
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "SwaggerApiDemo");
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/SwaggerApiDemo.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
