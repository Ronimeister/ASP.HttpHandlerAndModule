using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AbcModule
/// </summary>
public class AbcModule : IHttpModule
{
    public AbcModule()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Dispose() { }

    public void Init(HttpApplication context)
    {
        context.BeginRequest +=
            (new EventHandler(Application_BeginRequest));
        context.EndRequest +=
            (new EventHandler(Application_EndRequest));
    }

    private void Application_BeginRequest(Object source, EventArgs e)
    {
        HttpApplication application = (HttpApplication)source;
        HttpContext context = application.Context;
        string filePath = context.Request.FilePath;
        string fileExtension =
            VirtualPathUtility.GetExtension(filePath);
        if (fileExtension.Equals(".abc"))
        {
            context.Response.Write($"HelloWorldModule: Beginning of Request - {DateTime.Now}<hr>");
        }
    }

    private void Application_EndRequest(Object source, EventArgs e)
    {
        HttpApplication application = (HttpApplication)source;
        HttpContext context = application.Context;
        string filePath = context.Request.FilePath;
        string fileExtension =
            VirtualPathUtility.GetExtension(filePath);
        if (fileExtension.Equals(".abc"))
        {
            context.Response.Write($"<hr>HelloWorldModule: End of Request - {DateTime.Now}");
        }
    }
}