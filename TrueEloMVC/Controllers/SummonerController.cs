using Microsoft.AspNetCore.Mvc;
using RiotSharp;
using RiotSharp.Endpoints.StatusEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;
using Discord.Net;
using Discord.WebSocket;
using Remora.Discord.API.Abstractions.Gateway.Events;

namespace TrueEloMVC.Controllers
{
    public class SummonerController : Controller
    {
        


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public object Index(string summoner_region, string summoner_name)
        {
            var api = RiotApi.GetDevelopmentInstance("RGAPI-f944f559-6c6e-4bf5-b2fa-554415c7df9d");
            RiotSharp.Misc.Region region = (Region)Convert.ToInt32(summoner_region);
            try
            {
                var summoner = api.Summoner.GetSummonerByNameAsync(region, summoner_name).Result;
                return /*id(summoner.AccountId.ToString();*/  LocalRedirect($"/Summoner/id/{summoner.AccountId}");
            }
            catch (Exception ex)
            {
                {
                    ViewBag.Message = "Not found... Try again";
                    return View();
                }
            }
        }
                        
        public IActionResult id(string RiotAccountId)
        {
            return View();
        }
    }
}
