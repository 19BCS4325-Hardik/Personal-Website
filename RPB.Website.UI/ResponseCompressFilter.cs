using System.IO.Compression;
using System.Web;
using System.Web.Mvc;

namespace RPB.Website.UI
{
    public class ResponseCompressFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = HttpContext.Current.Response;
            var acceptEncodingHeader = HttpContext.Current.Request.Headers["Accept-Encoding"];
            if (!string.IsNullOrEmpty(acceptEncodingHeader) &&
                ((acceptEncodingHeader.Contains("gzip") || acceptEncodingHeader.Contains("deflate"))))
            {
                response.Headers.Remove("Content-Encoding");
                if (acceptEncodingHeader.Contains("gzip"))
                {
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                    response.AppendHeader("Content-Encoding", "gzip");
                }
                else
                {
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                    response.AppendHeader("Content-Encoding", "deflate");
                }
            }
        }
    }
}