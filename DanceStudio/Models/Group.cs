using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DanceStudio.Models
{
    public class Group
    {
        public Group()
        {
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Group name can't be more than 15 symbols.")]
        [DisplayName("Group Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Coach Id")]
        public long CoachId { get; set; }

        [Required]
        [DisplayName("Dance Id")]
        public long DanceId { get; set; }

        [ForeignKey("CoachId")]
        public Coach Coach { get; set; }

        [ForeignKey("DanceId")]
        public Dance Dance { get; set; }

        [DisplayName("List of Members")]
        public IList<GroupMember> GroupMembers { get; set; }

    }
    
}