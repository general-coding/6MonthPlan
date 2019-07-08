using System.Web;
using System.Web.Mvc;

namespace ExtensionMethods.Advanced.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
