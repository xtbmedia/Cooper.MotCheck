using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cooper.MotCheck.Services.Data.Implementation.TableModels
{
    public class Reminder
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string Registration { get; set; }
        [Required, MaxLength(50)]
        public string Manufacturer { get; set; }
        [Required ,MaxLength(50)]
        public string Model { get; set; }
        [Required]
        public DateTime MotExpiryDate { get; set; }
        [Required]
        public DateTime ReminderDueDate { get; set; }
        [Required, MaxLength(250)]
        public string Email { get; set; }
    }
}
