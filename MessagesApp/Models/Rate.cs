using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Rate
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int NumRate { get; set; }

        public string? Feedback { get; set; }

        public DateTime Time { get; set; }

        [Required]
        public string RaterName { get; set; }
    }
}
