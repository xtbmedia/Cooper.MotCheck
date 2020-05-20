using System;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services
{
    public interface IMotReminderService
    {
        Task<bool> CreateMotReminder(string registration, string reminderEmail, DateTime motExpiry);
    }
}
