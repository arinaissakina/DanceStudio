using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

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
        [EmailAddress]
        [Remote(action: "VerifyEmail", controller: "Coach")]
        public string Email { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        public Group Group { get; set; }

    }
}