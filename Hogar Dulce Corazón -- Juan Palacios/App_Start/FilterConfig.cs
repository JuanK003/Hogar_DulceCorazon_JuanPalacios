using System.Web;
using System.Web.Mvc;

namespace Hogar_Dulce_Corazón____Juan_Palacios
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
