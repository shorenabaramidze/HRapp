using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRapplication.Models.DBEntities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
 
        [Range(10000000000, 99999999999, ErrorMessage = "The ID number must be 11 digits.")]
        public long IdNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Position { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }

        public DateTime RetireDate { get; set; }

        public long TelNumber { get; set; }

    }
}
