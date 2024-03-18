using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipeFoot_TP
{
    public class League
    {
        public string LeagueName { get; set; }
        public static List<Team> TeamInLeague { get; set; }

        //Possible marketplace pour mercato ?
        //public List<Player> PlayersToBuy { get; set; }

        public League(string leagueName, List<Team> teamInLeague, List<Player> playersToBuy)
        {
            LeagueName = leagueName;
            TeamInLeague = teamInLeague;
            //PlayersToBuy = playersToBuy;
        }

        public void DisplayLeagueTeam(Team myTeam)
        {
            Console.WriteLine("Club inscrits dans la ligue :\n");
            for (int i = 0; i < TeamInLeague.Count; i++)
            {
                if (TeamInLeague[i] != myTeam)
                {
                    Console.WriteLine($"{i+1} - {TeamInLeague[i].TeamName}.");
                }
            }
        }
        public Team ChooseTeamInLeague(string teamNumber)
        {
            return TeamInLeague[int.Parse(teamNumber)-1];
        }
    }
}
