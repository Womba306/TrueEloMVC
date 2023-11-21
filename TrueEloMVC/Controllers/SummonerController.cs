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
        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Index(User user, string summoner_region, string summoner_name)
        {

           
            var api = RiotApi.GetDevelopmentInstance("RGAPI-f944f559-6c6e-4bf5-b2fa-554415c7df9d");
            RiotSharp.Misc.Region region = (Region)Convert.ToInt32(summoner_region);
            try
            {
                var summoner = api.Summoner.GetSummonerByNameAsync(region, summoner_name).Result;
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return /*id(summoner.AccountId.ToString();*/  LocalRedirect($"/Summoner/id/{summoner.Region}/{summoner.AccountId}");
            }
            catch (Exception ex)
            {
                {
                    ViewBag.Message = "Not found... Try again";
                    return View();
                }
            }
        }


       
                        
        public IActionResult id(string RiotRegion,string RiotAccountId)
        {
            return View();
        }
    }
}
