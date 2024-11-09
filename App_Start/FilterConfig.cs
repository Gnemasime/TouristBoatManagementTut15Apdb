using System.Web;
using System.Web.Mvc;

namespace TouristBoatManagementTut15Apdb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
