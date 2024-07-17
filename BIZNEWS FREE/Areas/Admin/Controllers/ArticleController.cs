using BIZNEWS_FREE.Data;
using BIZNEWS_FREE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BIZNEWS_FREE.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ArticleController : Controller
    {
        private readonly AppDbContext _context;

        public ArticleController(AppDbContext context)
        {
            _context = context;
        }

        //GET: /Admin/Article/Index
        public IActionResult Index()
        {
            var articles = _context.Articles.ToList();
            return View(articles);
        }


        // Get: /Admin/Article/Create
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var tags = _context.Tags.ToList();
            ViewData["tags"] = tags;                        //siyahida olan melumati bura gonderir
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");     //arxada select opsion yaradir
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Article article, IFormFile file, List<int> tagIds)
        {
            return View(article);
        }
    }
}
