﻿using System.Web;
using System.Web.Mvc;

namespace Lab2_1DV409
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}