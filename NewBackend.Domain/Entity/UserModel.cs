using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBackend.Domain.Entity
{

    [Table("tbl_UserDetails_Suman")]
    public class UserModel
    {
        
        public int UserID { get; set; }
       
        [Required(ErrorMessage = " First Name is required")]
        [MaxLength(50, ErrorMessage = "Atmost 50 characters are allowed")]
        public string FirstName { get; set; } 


        [Required(ErrorMessage = " First Name is required")]
        [MaxLength(50, ErrorMessage = "Atmost 50 characters are allowed")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }


        [Required]
        public bool Gender { get; set; }

        [Required]
        public int SelectedCountry { get; set; }

        [Required]
        public int SelectedState { get; set; }

        [Required]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}", ErrorMessage = "Password should contain one uppercase,one lowercase ,a number and a special character")]
        public string Password { get; set; }


    }
}
