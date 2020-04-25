using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DanceStudio.Models
{
    public class Dance
    {
        public Dance()
        {
        }
        [Key]
        public long Id { get; set; }

        [Required]
        [DisplayName("Dance Name")]
        public string Name { get; set; }

        [DisplayName("List of Groups")]
        public IList<Group> Groups { get; set; }

    }
}