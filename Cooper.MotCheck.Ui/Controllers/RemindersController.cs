using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooper.MotCheck.Models;
using Cooper.MotCheck.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cooper.MotCheck.Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService reminderService;

        public RemindersController(IReminderService reminderService)
        {
            this.reminderService = reminderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReminderRequest model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reminderId = await reminderService.CreateMotReminder(model);
            return CreatedAtAction("get", reminderId, new
            {
                ReminderId = System.Guid.NewGuid().ToString()
            });

        }
    }
}