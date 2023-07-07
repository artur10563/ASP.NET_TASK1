using ASP.NET_TASK1.Models;
using ASP.NET_TASK1.Models.DirModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASP.NET_TASK1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DirsContext _context;

        public HomeController(ILogger<HomeController> logger, DirsContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: HOME
        [HttpGet]
        public IActionResult Index(int IdParent = 1)
        {
            var parent = _context.Dirs.FirstOrDefault(d => d.Id == IdParent);
            var children = _context.DirRelations.Include("Child").Include("Parent").ToList().Where(dr => dr.Id_Parent == parent.Id);
            var model = (parent, children);

            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}