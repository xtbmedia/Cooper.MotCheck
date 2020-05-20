using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Ui.ViewModels
{
    public class RemindersRegistrationViewModel
    {
        public string Registration { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime MotExpiryDate { get; set; }
    }
}
