using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WCBackend.model;
using WCBackend.Models;

namespace WCBackend.Controllers
{
    [EnableCors("NUXT")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        d88ppm3o06b3t8Context _ctx;


        public HomeController(ILogger<HomeController> logger, d88ppm3o06b3t8Context ctx)
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
            var apikeyexists = _ctx.Configs.Where(r => r.Apikey.Contains(apikey)).Any();
            if (!apikeyexists)
            {
                return StatusCode(403, "Error. Statuscode 403. Apikey does not exist.");
            }

            Entry entry = new Entry();
            entry.Results = jsondata;
            try
            {
                _ctx.Entries.Add(entry);
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
            var apikeyexists = _ctx.Configs.Where(r => r.Apikey.Contains(apikey)).Any();
            if (!apikeyexists)
            {
                return StatusCode(403, "Error. Statuscode 403. Apikey does not exist.");
            }
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