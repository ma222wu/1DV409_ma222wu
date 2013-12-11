using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2_1DV409.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {

    }

    
    public class Contact_Metadata
    {
        [MaxLength(50, ErrorMessage = "Your e-mail adress must be shorter than 51 characters")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail adress")]
        string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        [MaxLength(50, ErrorMessage = "Your first name must be shorter than 51 characters")]
        string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        [MaxLength(50, ErrorMessage = "Your last name must be shorter than 51 characters")]
        string LastName { get; set; }
    }
}