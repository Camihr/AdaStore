﻿using Microsoft.AspNetCore.Mvc;

namespace AdaStore.Api.Controllers
{
    public class CartItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}