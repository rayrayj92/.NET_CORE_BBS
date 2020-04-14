using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace esu_v.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Process() => View();
    }
}