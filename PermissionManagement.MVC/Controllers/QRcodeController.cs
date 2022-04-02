using ClassLibrary.Classes;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ClassLibrary;
using ClassLibrary.Interfaces;

namespace PermissionManagement.MVC.Controllers
{
    public class QRcodeController : Controller
    {
        public IQRClass _qRClass;

        public QRcodeController(IQRClass qRClass)
        {
            _qRClass = qRClass;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string inputText)
        {
            ViewBag.QRCode = _qRClass.Create(inputText);

                return View();
        }
    }
}
