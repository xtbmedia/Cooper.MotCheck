using Cooper.MotCheck.Ui.Enumeration;
using System;

namespace Cooper.MotCheck.Ui.Models
{
    public class MotCheckResponse
    {
        public string Registration { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime MotExpiryDate { get; set; }
        public MotStatus Status { get; set; }

        public MotCheckResponse()
        {
            Status = MotStatus.Expired;
        }
    }
}
