using System;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;

namespace WebApiSessionEnabledRoutes
{
  public class EnableSessionForApiModule : IHttpModule
  {
    public void Init(HttpApplication context)
    {
      context.PostAuthorizeRequest += Context_PostAuthorizeRequest;
    }

    private static void Context_PostAuthorizeRequest(object sender, EventArgs e)
    {
      var application = (HttpApplication)sender;
      var context = new HttpContextWrapper(application.Context);

      var routeData = RouteTable.Routes.GetRouteData(context);
      if (routeData?.DataTokens[Constants.EnableReadOnlySessionKey] != null)
      {
        application.Context.SetSessionStateBehavior(SessionStateBehavior.ReadOnly);
      }
      else if (routeData?.DataTokens[Constants.EnableFullSessionKey] != null)
      {
        application.Context.SetSessionStateBehavior(SessionStateBehavior.Required);
      }

      application.Context.SetSessionStateBehavior(SessionStateBehavior.Required);
    }

    public void Dispose()
    {
    }
  }
}
