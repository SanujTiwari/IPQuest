using IPQuest.Data;
using Microsoft.AspNetCore.Mvc;

namespace IPQuest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Topics()
        {
            var topics = _context.Topics.ToList();

            return View(topics);
        }
        public IActionResult Topic(int id)
        {
            var topic = _context.Topics.FirstOrDefault(t => t.Id == id);

            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }
    }
}