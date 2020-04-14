using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace esu_v.Controllers
{
    public class AboutController : Controller
    {
        //원장 인사말
        public IActionResult Index() => View();

        //센터의 전문가들
        public IActionResult Colleages() => View();

        public IActionResult ContactUs() => View();

        public IActionResult CooperateCenter() => View();
    }
}