using System.ComponentModel.DataAnnotations;

namespace MessagesApp.Models
{
    public class Chat
    {
        [Key]
        public User User { get; set; }

        public string Nickname { get; set; }

        public ICollection<Message> Messages { get; set; }

        [Required]
        public string Server { get; set; }

    }
}
