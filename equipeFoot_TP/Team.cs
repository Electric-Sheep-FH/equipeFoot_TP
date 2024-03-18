using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace equipeFoot_TP
{
    public class Team
    {
        public string TeamName { get; set; }
        public string Nationality { get; set; }
        public List<Player> PlayerList { get; set; }
        public List<Player> SubsitutePlayers {  get; set; }
        public List<Player> ExcludePlayer { get; set; }

        public Team(string teamName, string nationality, List<Player> playerList, List<Player> sustitutePlayer, List<Player> excludePlayer)
        {
            TeamName = teamName;
            Nationality = nationality;
            PlayerList = playerList;
            SubsitutePlayers = sustitutePlayer;
            ExcludePlayer = excludePlayer;
            if (Nationality == "Français")
            {
                League.TeamInLeague.Add(this);
            }
        }

        public void DisplayTeamPlayers(List<Player> listPlayers)
        {
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");
            if (listPlayers.Count() > 0)
            {
                if (listPlayers == SubsitutePlayers)
                {
                    Console.WriteLine($"L'équipe remplacante de {TeamName} est composé de :\n");
                    for (int i = 0; i < listPlayers.Count(); i++)
                    {
                        Console.WriteLine($"{i+1} - \"{listPlayers[i].Lastname} {listPlayers[i].Firstname}\", {listPlayers[i].Role} au numéro {listPlayers[i].ShirtNumber}");

                    }
                } else if (listPlayers == PlayerList)
                {
                    Console.WriteLine($"L'équipe titulaire de {TeamName} est composé de :\n");
                    for (int i = 0; i < listPlayers.Count(); i++)
                    {
                        Console.WriteLine($"{i + 1} - \"{listPlayers[i].Lastname} {listPlayers[i].Firstname}\", {listPlayers[i].Role} au numéro {listPlayers[i].ShirtNumber}");

                    }
                } else if (listPlayers == ExcludePlayer)
                {
                    Console.WriteLine($"Les joueurs suivant de {TeamName} ont été exclus : ");
                    foreach(Player player in listPlayers)
                    {
                        if (player.Wounded)
                        {
                            Console.WriteLine($"- \"{player.Lastname} {player.Firstname}\", {player.Role} au numéro {player.ShirtNumber} s'est bléssé.");
                        }
                        else
                        {
                            Console.WriteLine($"- \"{player.Lastname} {player.Firstname}\", {player.Role} au numéro {player.ShirtNumber} a été exclu suite à des cartons.");
                        }
                    }
                }
            } else
            {
                Console.WriteLine("Il n'y a actuellement pas de joueurs dans cette catégorie !");
            }
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");
        }

        public void DisplayIndividualsStats(List<Player> playerList)
        {
            Console.WriteLine("Entrez le numéro d'un joueur pour consulter les détails, autrement, appuyez sur n'importe quelle touche pour revenir en arrière : ");
            string backOrStats = Console.ReadLine();
            Console.Clear();
            if (int.TryParse(backOrStats,out int parsedChoice))
            {
                for (int i = 0; i < playerList.Count(); i++)
                {
                    if (parsedChoice-1 == i)
                    {
                        Console.WriteLine($"Nom : {playerList[i].Lastname}\nPrénom : {playerList[i].Firstname}\nNuméro de maillot : {playerList[i].ShirtNumber}\nPoste : {playerList[i].Role}");
                        if (playerList[i].TeamList.Count > 1)
                        {
                            Console.WriteLine("\nLe joueur à été dans les clubs suivants :");
                            foreach (Team team in playerList[i].TeamList)
                            {
                                Console.WriteLine($"- {team.TeamName}.");
                            }
                        }
                    }
                }
                Program.PressAnyKeyToContinue();
            }
        }

        public int GetPlayerIndex(Player player, List<Player> playerList)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i] == player )
                {
                    return i;
                }
            }
            return -1;
        }

        public Player FindPlayerInList(List<Player> playerList)
        {
            string lastname = Program.AskingPlayerName();
            int shirtnumbers = Program.AskingShirtNumber();
            lastname = lastname.ToLower();
            foreach (Player player in playerList)
            {
                if (lastname == player.Lastname.ToLower() && shirtnumbers == player.ShirtNumber)
                {
                    return player;
                }
            }
            return null;
        }

        public void ChangePlayerInsideTeam(Player playerIn)
        {
            if (playerIn.Substitute && PlayerList.Count < 11) 
            {
                SubsitutePlayers.RemoveAt(GetPlayerIndex(playerIn,SubsitutePlayers));
                PlayerList.Add(playerIn);
                playerIn.Substitute = false;
                Console.Clear();
                Console.WriteLine($"{playerIn.Lastname} {playerIn.Firstname} a été transféré avec succès des remplacants vers les titulaires !");
            } else if (!playerIn.Substitute)
            {
                PlayerList.RemoveAt(GetPlayerIndex(playerIn,PlayerList));
                SubsitutePlayers.Add(playerIn);
                playerIn.Substitute= true;
                Console.Clear();
                Console.WriteLine($"{playerIn.Lastname} {playerIn.Firstname} a été transféré avec succès des titulaires vers les remplacants !");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Transfert impossible ! Veuillez vérifier que votre équipe titulaire n'est pas au complet.");
            }
            Program.PressAnyKeyToContinue();
        }
    }
}
