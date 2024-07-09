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
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public int SelectedCountry { get; set; }
        [Required]
        public int SelectedState { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
