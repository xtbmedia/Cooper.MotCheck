using Cooper.MotCheck.Models;
using System;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services
{
    public interface IReminderService
    {
        Task<int> CreateMotReminder(ReminderRequest model);
    }
}
