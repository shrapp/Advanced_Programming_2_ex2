using System.ComponentModel.DataAnnotations;

namespace MessagesApp.Models
{
    public class Rate
    {
        public int Id { get; set; } 

        [Required]
        public int Number { get; set; }

        public string Text { get; set; }


        public string Name { get; set; }

        [Required]
        public DateTime Time { get; set; }

    }
}
