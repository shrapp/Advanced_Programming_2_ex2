﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Rate
    {
        [Required]
        public int Number { get; set; }    

        public string Text { get; set; }    


        public string Name { get; set; }    

        [Required]
        public DateTime Time { get; set; }    

    }
}