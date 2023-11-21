using Microsoft.AspNetCore.Mvc;
using RiotSharp;
using RiotSharp.Endpoints.StatusEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;
using Discord.Net;
using Discord.WebSocket;
using Remora.Discord.API.Abstractions.Gateway.Events;
using TrueEloMVC.Models;
using Microsoft.EntityFrameworkCore;


namespace TrueEloMVC.Controllers
{
    public class SummonerController : Controller
    {
        UserContext db; 
        public SummonerController(UserContext db)
        {
            this.db = db;
        }
        [HttpGet ]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string summoner_region, string summoner_name)
        {

           
            var api = RiotApi.GetDevelopmentInstance("RGAPI-f944f559-6c6e-4bf5-b2fa-554415c7df9d");
            RiotSharp.Misc.Region region = (Region)Convert.ToInt32(summoner_region);
            try
            {
                var summoner = api.Summoner.GetSummonerByNameAsync(region, summoner_name).Result;
                User user = new();
                user.Riot.SummonerAccontRegion = summoner.Region.ToString();
                user.Riot.SummonerAccountId = summoner.AccountId.ToString();

                db.Users.Add(user);
                db.SaveChanges();
                return /*id(summoner.AccountId.ToString();*/  RedirectToActionPermanent("id");
            }
            catch (RiotSharpException ex)
            {
                
                ViewBag.Message = ex.Message;
                return View();

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();

            }
        }



        public async Task<IActionResult> id()
        {
            return View(await db.Users.ToListAsync());
        }
    }
}
