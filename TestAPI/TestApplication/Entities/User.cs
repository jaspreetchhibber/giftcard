using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TestApplication.Entities
{
  public class User
  {
    [Key]
    [Required]
    public int UserId { get; set; }
    [MaxLength(250)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(250)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(250)]
    [Required]
    public string UserName { get; set; }
    [MaxLength(250)]
    public string Password { get; set; }
    public bool IsActive { get; set; }
  }
}
