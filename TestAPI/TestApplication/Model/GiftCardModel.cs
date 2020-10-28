using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Model
{
  public class GiftCardModel
  {
    public int? GiftCardId { get; set; }
    public string GiftCardNumber { get; set; }
    public int Value { get; set; }
    public string Type { get; set; }
    public bool Status { get; set; }
    public int? UserId { get; set; }
  }
}
