using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HRapplication.Areas.Identity.Data;


public class HRapplicationUser : IdentityUser
{
    [Required]
    [Range(10000000000, 99999999999, ErrorMessage = "The ID number must be 11 digits.")]
    public long IdNumber { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50")]
    public string LastName { get; set; }

    [Column(TypeName = "nvarchar(10")]
    public string Gender { get; set; }


    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
}






