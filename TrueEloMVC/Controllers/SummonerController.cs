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
using Microsoft.Identity.Client;
using System;
using TrueEloMVC.Models.Sort;
using Remora.Discord.API.Objects;
using User = TrueEloMVC.Models.User;


namespace TrueEloMVC.Controllers
{
    public class SummonerController : Controller
    {
        //Подключение глобальных переменных
        GlobalVariables globalVariables = new GlobalVariables();


        UserContext db; 
        public SummonerController(UserContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string summoner_region, string summoner_name)
        {

            var api = RiotApi.GetDevelopmentInstance(globalVariables.riotApiDevKey);
            RiotSharp.Misc.Region region = (Region)Convert.ToInt32(summoner_region);
            try
            {
                var summoner =  api.Summoner.GetSummonerByNameAsync(region, summoner_name).Result;
                User user = new();
                user.Name = summoner_name;
                user.SummonerAccountId = summoner.AccountId.ToString();
                user.SummonerAccontRegion = summoner.Region.ToString();
                user.MMR = ;

                


                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                db.Update(user);
                return /*id(summoner.AccountId.ToString();*/ RedirectToAction( "Id", "Summoner", new {region = summoner.Region.ToString(), account_id = summoner.AccountId.ToString() });
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


        [Route("Summoner/Id/{region}/{account_id}")]
public async Task<IActionResult> Id(string region, string account_id)
        {
            User user = new User();
            return View(await db.Users.ToListAsync());
        }
        
        


        
        
    }
}
