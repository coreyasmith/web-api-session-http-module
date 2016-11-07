using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApiSessionEnabledRoutes
{
  public static class HttpRouteCollectionExtensions
  {
    public static IHttpRoute MapHttpSessionRoute(this HttpRouteCollection routes,
      string name, string routeTemplate, bool readOnlySession,
      object defaults = null, object constraints = null, HttpMessageHandler handler = null)
    {
      if (routes == null) throw new ArgumentNullException(nameof(routes));

      var dataTokens = new HttpRouteValueDictionary();
      if (readOnlySession)
      {
        dataTokens[Constants.EnableReadOnlySessionKey] = true;
      }
      else
      {
        dataTokens[Constants.EnableFullSessionKey] = true;
      }

      var route = routes.CreateRoute(routeTemplate, new HttpRouteValueDictionary(defaults), new HttpRouteValueDictionary(constraints), dataTokens, handler);
      routes.Add(name, route);

      return route;
    }
  }
}
