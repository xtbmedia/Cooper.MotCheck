using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooper.MotCheck.Models;
using Cooper.MotCheck.Ui.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cooper.MotCheck.Ui.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index(string registration, string manufacturer, string model, DateTime motExpiryDate)
        {
            var viewModel = new RemindersRegistrationViewModel
            {
                Registration = registration,
                Manufacturer = manufacturer,
                Model = model,
                MotExpiryDate = motExpiryDate.Date
            };

            return View(viewModel);
        }
    }
}