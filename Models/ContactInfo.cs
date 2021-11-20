using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Identity4Example.Models
{
    public class ContactInfo
    {

        public int Id { get; set; }

        public DateTime GetDate { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please")]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = " Name")]
        public string Name { get; set; }



        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address or phone number")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tell")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid No")]
        public string Tell { get; set; }


        [Required]
        [Display(Name = "Cell Phone")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid No")]
        public string CellPhone { get; set; }


        [Required(ErrorMessage = "Adress is required.")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Address")]
        public string ResidentialAddress { get; set; }


        [Required]
        [Display(Name = "Province")]
        public string Province { get; set; }


        [Required]
        [Display(Name = "Subject")]
        public string TypeOfProduct { get; set; }

        [Required]
        [Display(Name = "Time")]
        [StringLength(50)]
        public string Time { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}