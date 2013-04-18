using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Notebook
{
    class HtmlUtil
    {
        public HtmlUtil()
        {
        }

        /// <summary>
        /// 获取url对应的页面html内容
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>页面内容</returns>
        public string getHtmlContent(String url) 
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("UTF-8"));
            string html = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return html;
        }
    }
}
