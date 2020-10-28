using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Entities;
using TestApplication.Interface;
using TestApplication.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApplication.Controllers
{
  //[Route("api/[controller]")]
  [ApiController]
  [Route("[controller]")]
  [EnableCors("MyPolicy")]
  public class AccountController : ControllerBase
  {
    private readonly IUserRepository _userRepository;
    private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    public AccountController(IUserRepository userRepository)
    {


      _userRepository = userRepository;
    }

    [HttpGet]
    [Route("/Account/Login")]
    public IEnumerable<WeatherForecast> Get()
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }
    [Route("/Account/Login")]
    [HttpPost]
    public async Task<User> Login(string username, string password)
    {
      var result = await _userRepository.AuthenticateUser(username, password);
      return result;
    }
    [HttpGet]
    [Route("/Account/GetGiftCards/{userId}")]
    public async Task<List<GiftCard>> GetGiftCards(int userId)
    {
      var result = await _userRepository.GetGiftCardsByUserId(userId);
      return result;
    }
    [HttpDelete]
    [Route("/Account/DeleteGiftCard/{giftcardId}")]
    public async Task<Boolean> DeleteGiftCard(int giftcardId)
    {
      var result = await _userRepository.DeleteGiftCard(giftcardId);
      return result;
    }
    [HttpPut]
    [Route("/Account/UpdateGiftCard")]
    public async Task<Boolean> UpdateGiftCard(GiftCard giftCard)
    {
      var result = await _userRepository.UpdateGiftCard(giftCard);
      return result;
    }
    [HttpGet]
    [Route("/Account/GetGiftCardById/{giftcardId}")]
    public async Task<GiftCard> GetGiftCardById(int giftcardId)
    {
      var result = await _userRepository.GetGiftCardById(giftcardId);
      return result;
    }
    [HttpPost]
    [Route("/Account/AddGiftCard")]
    public async Task<Boolean> AddGiftCard([FromBody]GiftCardModel giftCard)
    {
      var result = await _userRepository.AddGiftCard(giftCard);
      return result;
    }
  }
}
