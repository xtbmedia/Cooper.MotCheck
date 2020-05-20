using Cooper.MotCheck.Models;
using Cooper.MotCheck.Services.Data.Implementation.Contexts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services.Data.Implementation
{
    public class ReminderService : IReminderService
    {
        private readonly RemindersContext dataContext;

        public ReminderService(RemindersContext remindersContext)
        {
            dataContext = remindersContext;
        }

        public async Task<int> CreateMotReminder(ReminderRequest model)
        {
            var expiryDate = DateTime.Parse(model.MotExpiryDate);
            var dueDate = expiryDate.AddYears(1).AddDays(-30);

            var tableRow = new TableModels.Reminder { 
                Email = model.Email,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                MotExpiryDate = expiryDate,
                Registration = model.Registration,
                ReminderDueDate = dueDate
            };

            dataContext.Reminders.Add(tableRow);
            await dataContext.SaveChangesAsync();
            return tableRow.Id;            
        }
    }
}
