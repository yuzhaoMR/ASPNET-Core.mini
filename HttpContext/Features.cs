using System;
using System.Collections.Specialized;
using System.IO;

namespace App.HttpContext
{
    public interface IHttpRequestFeature
    {
        Uri Url { get; }
        
        NameValueCollection Headers { get; }
        
        Stream Body { get; }
    }

    public interface IHttpResponseFeature
    {
        int StatusCode { get; set; }
        
        NameValueCollection Headers { get; }
        
        Stream Body { get; }
    }
}