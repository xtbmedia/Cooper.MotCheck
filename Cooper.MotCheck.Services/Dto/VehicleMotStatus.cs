using System;
using System.Collections.Generic;
using System.Text;

namespace Cooper.MotCheck.Services.Dto
{
    public class VehicleMotStatus
    {
        public string Registration { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime MotExpiryDate { get; set; }
        public string Status { get; set; }
    }
}
