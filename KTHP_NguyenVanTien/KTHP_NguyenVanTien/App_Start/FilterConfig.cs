﻿using System.Web;
using System.Web.Mvc;

namespace KTHP_NguyenVanTien
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
