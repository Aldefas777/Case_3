using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PermissionManagement.MVC.Models;
using System.Diagnostics;

namespace PermissionManagement.MVC.Controllers
{
    public class CostumersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ICostumerRepository _costumerRepository;

        public CostumersController(ILogger<HomeController> logger, ICostumerRepository costumerRepository)
        {
            _logger = logger;
            _costumerRepository = costumerRepository;
        }

        public IActionResult Add(int Id, string names, string surname, string SecondName, string Aboniment)
        {
            _costumerRepository.AddUsers(Id, names, surname, SecondName, Aboniment);
            return View();
        }

        public IActionResult CostumersView(string search)
        {
            var model = _costumerRepository.GetUsers(search);
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            ViewBag.Id = id;
            var model = _costumerRepository.DeleteUser(id);
            return View(model);
        }

        public IActionResult Update(int? Id, string names, string surname, string SecondName, string Aboniment)
        {
            ViewBag.Id = Id;
            ViewBag.Names = names;
            _costumerRepository.UpdateUser(Id, names, surname, SecondName, Aboniment);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
