using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WCBackend.DBContext;
using WCBackend.Models;

namespace WCBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        wcContext _ctx;


        public HomeController(ILogger<HomeController> logger, wcContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return StatusCode(403);
        }

        [HttpPost("postanswers/{jsondata}/{apikey}")]
        public IActionResult PostAnswers([FromForm] string jsondata, [FromForm] string apikey)
        {
            Config entry = new Config();
            entry.Results = jsondata;
            try
            {
                _ctx.Configs.Add(entry);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json("Error in HomeController::PostAnswers: " + ex);
            }
            return Json("Entry added successfully.");
        }

        [HttpGet("getanswers")]
        public IActionResult GetAnswers(string apikey)
        {
            List<Config> answers;
            try
            {
                answers = _ctx.Configs.ToList();
            }
            catch (Exception ex)
            {
                return Json("Error in HomeController::GetAnswers: " + ex);
            }
            return Json(answers);
        }

        public IActionResult GetFlagIcons()
        {
            return Json("");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}