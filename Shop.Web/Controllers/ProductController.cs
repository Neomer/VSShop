﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(Guid id)
        {
            return View();
        }
    }
}