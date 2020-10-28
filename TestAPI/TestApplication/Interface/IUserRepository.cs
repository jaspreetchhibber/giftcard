using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Entities;
using TestApplication.Model;

namespace TestApplication.Interface
{
  public interface IUserRepository
  {
    #region user
    Task<User> AuthenticateUser(string username, string password);
    #endregion

    #region giftcard
    Task<List<GiftCard>> GetGiftCardsByUserId(int userId);
    Task<Boolean> DeleteGiftCard(int giftcardId);
    Task<Boolean> UpdateGiftCard(GiftCard model);
    Task<GiftCard> GetGiftCardById(int giftcardId);
    Task<Boolean> AddGiftCard(GiftCardModel model);
    #endregion
  }
}
