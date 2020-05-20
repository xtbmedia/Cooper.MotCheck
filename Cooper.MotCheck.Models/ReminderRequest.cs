using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cooper.MotCheck.Models
{
    public class ReminderRequest
    {
        [Required]
        public string Registration { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string MotExpiryDate { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
