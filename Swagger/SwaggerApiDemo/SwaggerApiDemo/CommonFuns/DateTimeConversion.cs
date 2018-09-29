using System;

namespace SwaggerApiDemo.CommonFuns
{
    /// <summary>
    /// 
    /// </summary>
    public class DateTimeConversion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string getStrDateTime(DateTime? dt)
        {
            string getDt = Convert.ToDateTime(dt).ToString("yyyy-MM-dd");

            return getDt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime getDtDateTime(DateTime? dt)
        {
            DateTime getDt = Convert.ToDateTime(dt);

            return getDt;
        }

    }
}