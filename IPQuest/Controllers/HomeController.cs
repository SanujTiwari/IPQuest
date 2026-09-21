using IPQuest.Data;
using IPQuest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Quiz(int id)
        {
            var questions = _context.Questions
                .Where(q => q.TopicId == id)
                .Include(q => q.AnswerOptions)
                .ToList();

            var topic = _context.Topics.FirstOrDefault(t => t.Id == id);

            if (topic == null || questions.Count == 0)
            {
                return NotFound();
            }

            ViewBag.Topic = topic;

            return View(questions);
        }
    }
}