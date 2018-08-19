using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SimpleHandler
/// </summary>
public class SimpleHandler : IHttpHandler
{
    public SimpleHandler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;

        foreach (string i in request.Headers.Keys)
        {
            response.Write($"<p><b>{i}</b>: {request.Headers[i]} </p>");
        }

        response.Write($"<p><b>File content</b>: </p>");

        using (StreamReader sr = new StreamReader(request.PhysicalApplicationPath + request.FilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                response.Write($"<p>{sr.ReadLine()} </p>");
            }            
        }
    }
}
