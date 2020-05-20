using Cooper.MotCheck.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services.Data.Implementation
{
    public class MockReminderService : IReminderService
    {
        private readonly List<ReminderRequest> dataStore;

        public MockReminderService()
        {
            dataStore = new List<ReminderRequest>();
        }

        public Task<int> CreateMotReminder(ReminderRequest model)
        {
            dataStore.Add(model);
            return Task.FromResult(dataStore.Count());
        }
    }
}
