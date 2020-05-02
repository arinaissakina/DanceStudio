using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DanceStudio.Models
{
    public class Dance : IValidatableObject
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
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name.Length > 15)
            {
                yield return new ValidationResult("Dance name can't be more then 15 symbols.");
            }
        }

    }
}