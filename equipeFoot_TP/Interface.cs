using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipeFoot_TP
{
    public class Interface
    {
        public List<Team> CreatedTeam { get; set; }
        public List<Player> CreatedPlayer { get; set; }

        public Interface(List<Team> createdTeam, List<Player> createdPlayer)
        {
            CreatedTeam = createdTeam;
            CreatedPlayer = createdPlayer;
        }

        public void CreateTeam()
        {
            Console.Write("Comment voulez-vous appeler votre équipe ? : ");
            string teamName = Console.ReadLine();
            Console.Write("Quelle est la nationalité de votre équipe ? : ");
            string teamCountry = Console.ReadLine();

            CreatedTeam.Add(new Team(teamName, teamCountry, new List<Player>(), new List<Player>(), new List<Player>()));

            Console.WriteLine("Nouvelle équipe ajouté !");
        }
        public void CreatePlayer()
        {

        }
    }
}
