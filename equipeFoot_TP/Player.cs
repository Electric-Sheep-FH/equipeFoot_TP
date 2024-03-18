using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipeFoot_TP
{
    public class Player
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int ShirtNumber { get; set; }
        public bool Substitute { get; set; }
        public bool Wounded { get; set; }
        public Role Role { get; set; }
        public List<Fault> ListOfCard { get; set; }
        public Team Team { get; set; }
        public List<Team> TeamList { get; set; }

        public Player(string lastname, string firstname, int shirtNumber, Role role, Team team, bool substitute, bool wounded)
        {
            Lastname = lastname;
            Firstname = firstname;
            ShirtNumber = shirtNumber;
            Role = role;
            Team = team;
            ListOfCard = new List<Fault>();
            TeamList = new List<Team>();
            Substitute = substitute;
            Wounded = wounded;

            if (Substitute)
                Team.SubsitutePlayers.Add(this);
            else
                Team.PlayerList.Add(this);

            TeamList.Add(team);
        }

        public void GiveFaultCard(Fault colorOfCard)
        {
            int indexPlayer = Team.GetPlayerIndex(this, Team.PlayerList);
            
            if (ListOfCard.Count < 2)
            {
                ListOfCard.Add(colorOfCard);
            
                if (colorOfCard.CardColor == "Carton rouge")
                {
                    Team.ExcludePlayer.Add(this);
                    Team.PlayerList.Remove(this);
                    Console.WriteLine("\n###########################################################################################\n");
                    Console.WriteLine($"EXCLUSION : {Firstname} {Lastname} a pris un carton rouge, il est exclu de l'équipe !");
                    Console.WriteLine("\n###########################################################################################\n");
                }
                else if (ListOfCard.Count == 2 && colorOfCard.CardColor == "Carton jaune")
                {
                    Team.ExcludePlayer.Add(this);
                    Team.PlayerList.Remove(this);
                    Console.WriteLine("\n###########################################################################################\n");
                    Console.WriteLine($"EXCLUSION : {Firstname} {Lastname} a pris un deuxième carton jaune, il est exclu de l'équipe !");
                    Console.WriteLine("\n###########################################################################################\n");
                } else if (colorOfCard.CardColor == "Carton jaune")
                {
                    Console.WriteLine("\n###########################################################################################\n");
                    Console.WriteLine($"FAUTE : {Firstname} {Lastname} a pris un carton jaune, attention, au prochain c'est l'exclusion !");
                    Console.WriteLine("\n###########################################################################################\n");
                }
            }
        }
        public void WoundPlayer(bool exclusion)
        {
            Wounded = true;
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");
            Console.WriteLine($"{Firstname} {Lastname} s'est blessé !");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");
            if (exclusion)
            {
                Team.ExcludePlayer.Add(this);
                Team.PlayerList.Remove(this);
            }
        }
        public void TransferPlayer(Team myTeam,Team teamOut)
        {
            Team = myTeam;
            TeamList.Add(Team);
            if(Substitute)
            {
                myTeam.SubsitutePlayers.Add(this);
                teamOut.SubsitutePlayers.RemoveAt(teamOut.GetPlayerIndex(this,teamOut.SubsitutePlayers));
            } else
            {
                Substitute = true;
                myTeam.SubsitutePlayers.Add(this);
                teamOut.PlayerList.RemoveAt(teamOut.GetPlayerIndex(this, teamOut.PlayerList));
            }
            Console.Clear();
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");
            Console.WriteLine($"TRANSFERT OK : {Firstname} {Lastname} quitte {TeamList[TeamList.Count()-2].TeamName} pour {Team.TeamName} !");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("Appuyez sur n'importe quelle touche pour retourner à la page d'accueil...");
            string pause = Console.ReadLine();

        }
        public void DisplayTransferedTeam()
        {
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");
            Console.WriteLine($"{Firstname} {Lastname} à joué dans les clubs suivants :\n");
            for (int i = 0; i < TeamList.Count-1; i++) 
            {
                Console.WriteLine($"- {TeamList[i].TeamName}.");
            }
            Console.WriteLine($"\nIl joue actuellement au club suivant : {TeamList[TeamList.Count-1].TeamName}");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");
        }
    }
}
