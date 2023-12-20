using RiotSharp;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Misc;
namespace TrueEloMVC.EloLogic
{

    public class MMRCounter
    {
        GlobalVariables globalVariables = new();
        public int ConverLPToMMR(Summoner summoner)
        {
            var api = RiotApi.GetDevelopmentInstance(globalVariables.riotApiDevKey);
            var leagueEntries = api.League.GetLeaguePositionsAsync(summoner.Region, summoner.Id);
           
            return 1;
        }
    }
}
