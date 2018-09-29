using System;
using System.Collections.Generic;

namespace SwaggerApiDemo.CommonFuns
{
    /// <summary>
    /// 
    /// </summary>
    public class StringConversion
    {
        /// <summary>
        /// string转List
        /// </summary>
        /// <param name="parameter">英文逗号分隔的string字符串</param>
        /// <returns></returns>
        public static List<string> strList(string parameter)
        {
            var resultList = new List<string>();
            if (parameter != null && parameter != "")
            {
                resultList = new List<string>(parameter.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            }
            return resultList;
        }
    }
}