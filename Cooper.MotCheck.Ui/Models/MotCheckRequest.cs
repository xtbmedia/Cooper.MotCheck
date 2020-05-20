using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Ui.Models
{
    public class MotCheckRequest
    {
        [Required]
        public string Registration { get; set; }
    }
}
