using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class Chat
    {
        public int Id { get; set; }


        public User? User { get; set; }

        public string? Nickname { get; set; }

        public ICollection<Message>? Messages { get; set; }

        [Required]
        public string? Server { get; set; }

    }
}
