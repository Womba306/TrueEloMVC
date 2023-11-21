using System.Collections.Generic;

namespace TrueEloMVC.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? MMR { get; set; }
        public List GameInTrueEloPlayedId { get; set; } = new(); // Тут надо фиксить, сейчас лень. но запихнуть список в дб не дает, надо чекать.
        //гуглить, как добавить список в дб c#. 


        public Riot Riot { get; set; }

    }
    public class Riot
    { 


        public string? SummonerAccountId { get; set; } // << RiotSumonnerAccountId
        public string? SummonerAccontRegion { get; set; } // << RiotSumonnerRegion
        public string? ClientLobbyId { get; set; } //tournament code 
       
       
    }
}
                                    