using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DanceStudio.Models
{
    public class Coach
    {
        public Coach()
        {
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        public Group Group { get; set; }

    }
}