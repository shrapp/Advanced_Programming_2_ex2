using System.ComponentModel.DataAnnotations;

namespace MessagesApp.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public DateTime Time { get; set; }


        [Required]
        public string Content { get; set; }


        [Required]
        public string Type { get; set; }

    }
}