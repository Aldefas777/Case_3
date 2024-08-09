using ClassLibrary.Classes;
using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PermissionManagement.MVC.Models;
using System.Diagnostics;

namespace PermissionManagement.MVC.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CustumersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ICustumerRepository _costumerRepository;
        
        public CustumersController(ILogger<HomeController> logger, ICustumerRepository costumerRepository)
        {
            _logger = logger;
            _costumerRepository = costumerRepository;
        }

        public IActionResult Add(CustumerModel model)
        {
            _costumerRepository.AddCustumer(model);
            return View();
        }

        public IActionResult CustumersView(string search)
        {
            var model = _costumerRepository.GetCustumers(search);
            return View(model);
        }

        public IActionResult CustumersPerson(int id)
        {
            ViewBag.Id = id;
            var model = _costumerRepository.GetCustumer(id);
            return View(model);
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            var model = _costumerRepository.DeleteCustumer(id);
            return View(model);
        }

        public IActionResult Update(int Id, Custumers model)
        {
            ViewBag.Id = Id;

             _costumerRepository.UpdateCustumer(Id, model);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
