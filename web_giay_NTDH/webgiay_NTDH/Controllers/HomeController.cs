﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webgiay_NTDH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();// Trả về View Index trong thư mục Views/Home
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}