using RiotSharp;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;

namespace TrueEloMVC.Models
{
    public class Summoner
    {
        public string RiotSummonerName { get; set; }
        public string RiotSummonerRegion { get; set; }
        public string RiotSummonerAccountId { get; set; }
        public string RiotSummonerIconId { get; set; }

    }
    
}