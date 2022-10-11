using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WCBackend.model;
using WCBackend.Models;

namespace WCBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        da33cbrr9f9g7gContext _ctx;


        public HomeController(ILogger<HomeController> logger, da33cbrr9f9g7gContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return StatusCode(403);
        }

        [HttpPost("postanswers/{jsondata}")]
        public IActionResult PostAnswers([FromForm] string jsondata)
        {
            Entry entry = new Entry();
            entry.Results = jsondata;
            try
            {
                _ctx.Entries.Add(entry);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json("Error in HomeController::GetAnswers: " + ex);
            }
            return Json("Entry added successfully.");
        }    
        
        [HttpGet("getanswers")]
        public IActionResult GetAnswers(string jsondata)
        {
            Entry entry = new Entry();
            entry.Results = jsondata;
            List<Entry> answers;
            try
            {
                answers = _ctx.Entries.Where(r => r.Results.Contains("pedo")).ToList();
            }
            catch(Exception ex)
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