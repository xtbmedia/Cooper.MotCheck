using Cooper.MotCheck.Models.Enumeration;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cooper.MotCheck.Models
{
    public class MotCheckResponse
    {
        public string Registration { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [DisplayName("Expiry Date")]
        public DateTime MotExpiryDate { get; set; }
        public MotStatus Status { get; set; }

        public MotCheckResponse()
        {
            Status = MotStatus.Expired;
        }
    }
}
