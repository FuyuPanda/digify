
using Digify.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.Common;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Digify.Common;

namespace Digify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment webhost)
        {
            _logger = logger;
            _webHostEnvironment = webhost;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {

                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
                string npwpPath = "";
                if (model.npwpFile != null && model.npwpFile.Length > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.npwpFile.FileName);
                    string extension = Path.GetExtension(model.npwpFile.FileName);
                    string uniqueFileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    string filePath = Path.Combine(uploadPath, uniqueFileName);
                    npwpPath = filePath;

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.npwpFile.CopyToAsync(stream);
                    }
                }

                string poaPath = "";
                if (model.poaFile != null && model.poaFile.Length > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.poaFile.FileName);
                    string extension = Path.GetExtension(model.poaFile.FileName);
                    string uniqueFileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    string filePath = Path.Combine(uploadPath, uniqueFileName);
                    poaPath = filePath;

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.poaFile.CopyToAsync(stream);
                    }
                }


                RegistrationModel register = new RegistrationModel
                {
                    companyName = model.companyName,
                    directorName = model.directorName,
                    email = model.email,
                    npwpFile = npwpPath,
                    npwp = model.npwp,
                    poaFile = poaPath,
                    phone = model.phone,
                    picName = model.picName

                };
                try
                {
                    HttpClient client = new HttpClient();
                    var url = "https://localhost:7158/api/Registration";
                    var response = await client.PostAsJsonAsync(url, register);
                    response.EnsureSuccessStatusCode(); // Throws an error if response is not successful
                    var resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BaseResponse>(resp);
                    if(result.code==200)
                    {
                        TempData["Success"] = "Company has been registered successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Failed"] = "Failed to register a company!";
                        return RedirectToAction("Index");
                    }    

                }
                catch (Exception ex)
                {
                    TempData["Failed"] = "Failed to register a company!";
                    return RedirectToAction("Index");
                }
               
                
            }
            else
            {
                TempData["Failed"] = "Failed to register a company!";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}