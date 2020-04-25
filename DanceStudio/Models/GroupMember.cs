using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DanceStudio.Models
{
    
    public class GroupMember
    {
        public GroupMember()
        {
        }
        
        [Required]
        [DisplayName("Group Id")]
        public long GroupId { get; set; }
        
        [ForeignKey("CourseId")]
        public Group Group { get; set; }

        [Required]
        [DisplayName("Member Id")]
        public long MemberId { get; set; }
        
        [ForeignKey("MemberId")]
        public Member Member { get; set; }
        

    }
}