using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Platform.Common.Helper
{
    /// <summary>
    /// Http协议公共类
    /// author:chenhm
    /// time:2017-08-29
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// Http协议Get方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string HttpGet(string url, string param)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url + param);
                req.Method = "GET";
                WebResponse wr = req.GetResponse();
                StreamReader sr = new StreamReader(wr.GetResponseStream());
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Http协议Post方法
        /// </summary>
        /// <param name="url">目标地址</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static string HttpPost(string url, string param)
        {
            byte[] bs = Encoding.UTF8.GetBytes(param);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;


            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            WebResponse wr = req.GetResponse();
            StreamReader sr = new StreamReader(wr.GetResponseStream());
            return sr.ReadToEnd();
        }

        /**
         * 
         * 大汉三同发送短信Post 发送请求数据
         * 
         * 
         * **/
        public static string PostMethodConnServer(String iServerURL, String iPostData)
        {
            String result = null;
            byte[] _buffer = Encoding.GetEncoding("utf-8").GetBytes(iPostData);
            HttpWebRequest _req = (HttpWebRequest)WebRequest.Create(iServerURL);
            _req.Method = "Post";
            _req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            _req.ContentLength = _buffer.Length;
            Stream _stream = null;
            Stream _resStream = null;
            StreamReader _resSR = null;
            try
            {
                _stream = _req.GetRequestStream();
                _stream.Write(_buffer, 0, _buffer.Length);
                _stream.Flush();
                HttpWebResponse _res = (HttpWebResponse)_req.GetResponse();

                //获取响应
                _resStream = _res.GetResponseStream();
                _resSR = new StreamReader(_resStream, Encoding.GetEncoding("utf-8"));
                result = _resSR.ReadToEnd();
                //MessageBox.Show(_resSR.ReadToEnd());
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "调用异常", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (_stream != null)
                {
                    _stream.Close();
                }
                if (_resSR != null)
                {
                    _resSR.Close();
                }
                if (_resStream != null)
                {
                    _resStream.Close();
                }
            }
            return result;
        }
        /// <summary>
        /// post提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string HttpsPost(string url, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
        }


        /// <summary>
        /// 需要WebService支持Post调用
        /// </summary>
        public static XmlDocument PostWebService(string URL, string MethodName, Hashtable Pars)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL + "/" + MethodName);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            SetWebRequest(request);
            byte[] data = EncodePars(Pars);
            WriteRequestData(request, data);
            return ReadXmlResponse(request.GetResponse());
        }

        /// <summary>
        /// 需要WebService支持Get调用
        /// </summary>
        public static XmlDocument GetWebService(string URL, string MethodName, Hashtable Pars)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL + "/" + MethodName + "?" + ParsToString(Pars));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            SetWebRequest(request);
            return ReadXmlResponse(request.GetResponse());
        }

        /// <summary>
        /// 设置凭证与超时时间
        /// </summary>
        /// <param name="request"></param>
        private static void SetWebRequest(HttpWebRequest request)
        {
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 10000;
        }

        private static void WriteRequestData(HttpWebRequest request, byte[] data)
        {
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
        }

        private static byte[] EncodePars(Hashtable Pars)
        {
            return Encoding.UTF8.GetBytes(ParsToString(Pars));
        }

        private static String ParsToString(Hashtable Pars)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string k in Pars.Keys)
            {
                if (sb.Length > 0)
                {
                    sb.Append("&");
                }
                //sb.Append(HttpUtility.UrlEncode(k) + "=" + HttpUtility.UrlEncode(Pars[k].ToString()));
            }
            return sb.ToString();
        }

        private static XmlDocument ReadXmlResponse(WebResponse response)
        {
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            sr.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(retXml);
            return doc;
        }

        private static void AddDelaration(XmlDocument doc)
        {
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.InsertBefore(decl, doc.DocumentElement);
        }

        /// <summary>
        /// 设置https证书校验机制,默认返回True,验证通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受
        }

        /// <summary>
        /// 支持http和https
        /// author:wxch
        /// data:2018-8-6 09:14:13
        /// </summary>
        /// <param name="strFileToUpload"></param>
        /// <param name="strUrl"></param>
        /// <param name="strFileFormName"></param>
        /// <param name="querystring"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static async Task<string> MyUploader(string strFileToUpload, string strUrl, string strFileFormName, NameValueCollection querystring, CookieContainer cookies)
        {
            string postdata;
            postdata = "?";
            if (querystring != null)
            {
                foreach (string key in querystring.Keys)
                {
                    postdata += key + "=" + querystring.Get(key) + "&";
                }
            }
            //Uri uri = new Uri(strUrl + postdata);

            Uri oUri = new Uri(strUrl + postdata);

            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");

            // The trailing boundary string
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");

            // The post message header
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append(strFileFormName);
            sb.Append("\"; filename=\"");
            sb.Append(Path.GetFileName(strFileToUpload));
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            string strPostHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);

            // The WebRequest
            HttpWebRequest oWebrequest = (HttpWebRequest)WebRequest.Create(oUri);

            //如果是发送HTTPS请求  
            if (strUrl.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                oWebrequest = WebRequest.Create(oUri) as HttpWebRequest;
                oWebrequest.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                oWebrequest = WebRequest.Create(oUri) as HttpWebRequest;
            }

            oWebrequest.ContentType = "multipart/form-data; boundary=" + strBoundary;
            oWebrequest.Method = "POST";

            // This is important, otherwise the whole file will be read to memory anyway...
            oWebrequest.AllowWriteStreamBuffering = false;

            // Get a FileStream and set the final properties of the WebRequest
            FileStream oFileStream = new FileStream(strFileToUpload, FileMode.Open, FileAccess.Read);
            long length = postHeaderBytes.Length + oFileStream.Length + boundaryBytes.Length;
            oWebrequest.ContentLength = length;
            Stream oRequestStream = oWebrequest.GetRequestStream();

            // Write the post header
            oRequestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            // Stream the file contents in small pieces (4096 bytes, max).
            byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)oFileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = oFileStream.Read(buffer, 0, buffer.Length)) != 0)
                oRequestStream.Write(buffer, 0, bytesRead);
            oFileStream.Close();

            // Add the trailing boundary
            oRequestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            WebResponse oWResponse = oWebrequest.GetResponse();
            Stream s = oWResponse.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            var sReturnString = sr.ReadToEndAsync();

            // Clean up
            oFileStream.Close();
            oRequestStream.Close();
            s.Close();
            sr.Close();

            return await sReturnString;
        }

    }
}
