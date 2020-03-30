using Microsoft.AspNetCore.Mvc.Rendering;
using PeopleManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Group")]
        public string Group { get; set; }
        //public IEnumerable<SelectListItem> Groups { get; set; }

    }
}
