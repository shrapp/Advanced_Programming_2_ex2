using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key, Required]
        public string Username { get; set; }

        public ICollection<Chat> Chats { get; set; }

        [Required]
        public string Password { get; set; }

        public string Picture { get; set; }

    }
}