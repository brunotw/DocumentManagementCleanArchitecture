using DocumentManagement.MVC.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DocumentManagement.MVC.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Documents()
        {
            string url = "https://localhost:7175/api/document/download/file1.txt";
            using (HttpClient client = new HttpClient())
            {
                var result =  await client.GetStringAsync(url);
            }


            List<DocumentViewModel> documents = new List<DocumentViewModel>
            {
                new DocumentViewModel{FIleName= "File1", Extension= ".txt" },
                new DocumentViewModel{FIleName= "File2", Extension= ".txt" },
            };

            return View(documents);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}