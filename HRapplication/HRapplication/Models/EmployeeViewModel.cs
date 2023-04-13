using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRapplication.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Range(10000000000, 99999999999, ErrorMessage = "The ID number must be 11 digits.")]
        [DisplayName ("Id Number")]
        public long IdNumber { get; set; }

        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Birthdate")]
        public DateTime Birthdate { get; set; }


        [DisplayName("Position")]
        public string Position { get; set; }


        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Retire Date")]
        public DateTime RetireDate { get; set; }

        [DisplayName("Phone Number")]
        public long TelNumber { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
