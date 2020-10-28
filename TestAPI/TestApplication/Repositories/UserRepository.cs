using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Interface;
using TestApplication.Context;
using TestApplication.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TestApplication.Model;

namespace TestApplication.Repositories
{
  public class UserRepository:IUserRepository
  {
    private TestApplicationContext _context;
    private IMapper _mapper;
    public UserRepository(TestApplicationContext context)
    {
      _context = context;
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<GiftCard, GiftCardModel>().ReverseMap();
      });
      _mapper = config.CreateMapper();
    }

    #region user
    public async Task<User> AuthenticateUser(string username,string password)
    {
      try
      {
        var user =await _context.Users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == password).FirstOrDefaultAsync();
        if (user != null)
        {
          return user;
        }
        else
        {
          return null;
        }
      }
      catch(Exception ex)
      {
        return null;
      }
    }
    #endregion

    #region giftcards
    public async Task<List<GiftCard>> GetGiftCardsByUserId(int userId)
    {
      try
      {
        var giftcards = await _context.GiftCards.Where(x => x.UserId==userId && x.Status==true).ToListAsync();
        if (giftcards.Count>0)
        {
          return giftcards;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        return null;
      }
    }
    public async Task<Boolean> DeleteGiftCard(int giftcardId)
    {
      try
      {
        var giftcard = await _context.GiftCards.Where(x => x.GiftCardId == giftcardId).FirstOrDefaultAsync();
        if (giftcard!=null)
        {
          giftcard.Status = false;
          _context.GiftCards.Update(giftcard);
          await _context.SaveChangesAsync();
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }
    public async Task<Boolean> UpdateGiftCard(GiftCard model)
    {
      try
      {
        if (model != null)
        {
          _context.GiftCards.Update(model);
          await _context.SaveChangesAsync();
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }
    public async Task<GiftCard> GetGiftCardById(int giftcardId)
    {
      try
      {
        var giftcard = await _context.GiftCards.Where(x => x.GiftCardId == giftcardId).FirstOrDefaultAsync();
        if (giftcard!=null)
        {
          return giftcard;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        return null;
      }
    }
    public async Task<Boolean> AddGiftCard(GiftCardModel model)
    {
      try
      {
        if (model != null)
        {
          var giftcard = _mapper.Map<GiftCard>(model);
          if (giftcard != null)
          {
            _context.GiftCards.Add(giftcard);
            await _context.SaveChangesAsync();
            return true;
          }
          return false;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }
    #endregion
  }
}
