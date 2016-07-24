using System.Web;
using System.Web.Mvc;

namespace Hackathon2016.HomeGenie.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
