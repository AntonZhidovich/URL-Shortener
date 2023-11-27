using Microsoft.AspNetCore.Mvc;
using URLShortenerApp.Data;
using URLShortenerApp.Models;
using URLShortenerApp.Shortener;

namespace URLShortenerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _dbContext;
        private readonly IUrlShortener _urlShortener;

        public HomeController(AppDBContext dbContext, IUrlShortener urlShortener)
        {
            _dbContext = dbContext;
            _urlShortener = urlShortener;
        }

        public IActionResult RedirectFromShortUrl(int Id)
        {
            URL? uRL = _dbContext.URLs.FirstOrDefault(u => u.Id == Id);
            if (uRL is null)
            {
                return NotFound();
            }
            uRL.Clicks++;
            _dbContext.SaveChanges();
            return Redirect(uRL.FullURL);
        }

        public IActionResult Index()
        {
            IEnumerable<URL> uRLs = _dbContext.URLs.OrderByDescending(u => u.Created);
            ViewBag.uRLs = uRLs;
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            URL uRL = new URL();
            uRL.Created = DateTime.Now;
            uRL.ShortURL = _urlShortener.Generate();
			ViewData["Title"] = "Create URL";
            ViewData["CurrentAction"] = "Generate Short URL";
			return View("Edit", uRL);
        }

        [HttpPost]
        public IActionResult Create(URL uRL)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Add(uRL);
                    _dbContext.SaveChanges();
                }
                catch
                {
                    return BadRequest();
                }
            }

            return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult Update(int Id)
		{
			URL? uRL = _dbContext.URLs.FirstOrDefault(u => u.Id == Id);
			if (uRL is null)
			{
				return NotFound();
			}

			ViewData["Title"] = "Edit URL";
			ViewData["CurrentAction"] = "Edit short URL";
			return View("Edit", uRL);
		}

        [HttpPost]
        public IActionResult Update(URL uRL)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.URLs.Update(uRL);
                    _dbContext.SaveChanges();
                }
                catch
                {
                    return BadRequest();
                }
            }

            return RedirectToAction("Index");
        }

		public IActionResult Delete(int Id)
        {
            URL? uRL = _dbContext.URLs.FirstOrDefault(u => u.Id == Id);
            if (uRL is null)
            {
                return BadRequest();
            }

            _dbContext.URLs.Remove(uRL);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult GetShortURL()
		{
			string shortUrl = _urlShortener.Generate();
			return Json(shortUrl);
		}
	}
}
