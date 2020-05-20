using System;
using System.Collections.Generic;
using System.Text;

namespace Cooper.MotCheck.Models
{
    public class ReminderRequest
    {
        public string Email { get; set; }
        public string Registration { get; set; }
        public string MotExpiryDate { get; set; }
    }
}
