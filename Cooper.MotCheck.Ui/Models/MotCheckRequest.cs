using System.ComponentModel.DataAnnotations;

namespace Cooper.MotCheck.Ui.Models
{
    public class MotCheckRequest
    {
        [Required]
        public string Registration { get; set; }
    }
}
