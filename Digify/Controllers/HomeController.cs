using Digify.Data.Entity;
using Digify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

namespace Digify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DigifyContext db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, DigifyContext ctx,IWebHostEnvironment webhost)
        {
            _logger = logger;
            db=ctx;
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
                var user = db.User.Where(a => a.npwp == model.npwp).FirstOrDefault();
                if (user == null)
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
                    if(model.poaFile != null && model.poaFile.Length > 0)
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

                    using (var dbcxtransaction = db.Database.BeginTransaction())
                    {

                        user = new User
                        {
                            directorName = model.directorName,
                            npwp = model.npwp,
                            companyName = model.companyName,
                            email = model.email,
                            npwpPath = npwpPath,
                            phoneNumber = model.phone,
                            picName = model.picName,
                            poaPath = poaPath
                        };
                        db.User.Add(user);
                        db.SaveChanges();
                        dbcxtransaction.Commit();
                        TempData["Success"] = "Company has been registered successfully!";
                        return RedirectToAction("Index");

                    }

                }
                else
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