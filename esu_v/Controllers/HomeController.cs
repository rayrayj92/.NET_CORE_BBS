using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using esu_v.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esu_v.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly EsuContext _context;
        public HomeController(EsuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var boards = _context.Boards.OrderByDescending(x => x.Id).Take(4);

            return View(await boards.ToListAsync());
        }
    }
}