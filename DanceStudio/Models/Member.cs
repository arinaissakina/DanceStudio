using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DanceStudio.Models
{
    public class Member
    {
        public Member()
        {
        }
        
        [Key]
        public long Id { get; set; }

        [Required]
        [DisplayName("Member Name")]
        public string Name { get; set; }

        [Required]
        [NotContainsLetters]
        [DisplayName("Member PhoneNumber")]
        public string PhoneNumber { get; set; }

        [DisplayName("List of Groups")]
        public IList<GroupMember> GroupMembers { get; set;}
    }
    
    public class NotContainsLettersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                String stringValue = value.ToString();
                if (stringValue.Any(char.IsLetter) == false)
                    return ValidationResult.Success;     
            }

            return new ValidationResult("Phone number can't contain letters.");
        }
    }
}