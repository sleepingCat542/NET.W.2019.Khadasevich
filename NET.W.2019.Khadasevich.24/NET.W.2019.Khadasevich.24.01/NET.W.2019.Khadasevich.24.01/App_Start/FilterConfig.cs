using System.Web;
using System.Web.Mvc;

namespace NET.W._2019.Khadasevich._24._01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
