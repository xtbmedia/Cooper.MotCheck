using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooper.MotCheck.Models;
using Cooper.MotCheck.Ui.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cooper.MotCheck.Ui.Controllers
{
    public class RemindersController : Controller
    {
        public IActionResult Register(string registration, DateTime motExpiryDate)
        {
            var viewModel = new RemindersRegistrationViewModel
            {
                Registration = registration,
                MotExpiryDate = motExpiryDate.Date
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Registrations([FromBody]ReminderRequest model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Delay(2500);

            var reminderId = System.Guid.NewGuid().ToString();
            return Created($"/registrations/{reminderId}", new
            {
                ReminderId = System.Guid.NewGuid().ToString()
            });

        }

    }
}