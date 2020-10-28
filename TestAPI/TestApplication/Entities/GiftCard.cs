using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Entities
{
  public class GiftCard
  {
    [Key]
    [Required]
    public int GiftCardId { get; set; }
    [MaxLength(250)]
    [Required]
    public string GiftCardNumber { get; set; }    
    [Required]
    public int Value { get; set; }
    [MaxLength(250)]
    [Required]
    public string Type { get; set; }
    public bool Status { get; set; }
    public int UserId { get; set; }
  }
}
