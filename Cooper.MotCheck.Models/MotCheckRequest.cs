using System.ComponentModel.DataAnnotations;

namespace Cooper.MotCheck.Models
{
    public class MotCheckRequest
    {
        [Required]
        public string Registration { get; set; }
    }
}
