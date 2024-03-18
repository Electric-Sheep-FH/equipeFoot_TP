using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace equipeFoot_TP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            League frenchLeague = new League("Ligue 1", new List<Team>(), new List<Player>());

            Team asnl = new Team("ASNL", "Français", new List<Player>(), new List<Player>(), new List<Player>());
            Team fcMetz = new Team("FC Metz", "Français", new List<Player>(), new List<Player>(), new List<Player>());
            Team psg = new Team("Paris SG", "Français", new List<Player>(), new List<Player>(), new List<Player>());


            Fault redCard = new Fault("Carton rouge");
            Fault yellowCard = new Fault("Carton jaune");

            Player sourzac = new Player("Sourzac", "Martin", 16, Role.Gardien, asnl, false, false);
            Player tayot = new Player("Tayot", "Gwilhem", 3, Role.Défenseur, asnl, false, false);
            Player mendy = new Player("Mendy", "Prince", 15, Role.Défenseur, asnl, false, false);
            Player carlier = new Player("Carlier", "Maxence", 17, Role.Défenseur, asnl, false, false);
            Player pellegrini = new Player("Pellegrini", "Lucas", 21, Role.Défenseur, asnl, false, false);
            Player diaby = new Player("Diaby", "Alassane", 4, Role.Milieu, asnl, false, false);
            Player nonnenmacher = new Player("Nonnenmacher", "Maxime", 5, Role.Milieu, asnl, false, false);
            Player bouriaud = new Player("Bouriaud", "Teddy", 6, Role.Milieu, asnl, false, false);
            Player gomel = new Player("Gomel", "Benjamin", 7, Role.Milieu, asnl, false, false);
            Player bouabdeli = new Player("Bouabdeli", "Walid", 8, Role.Attaquant, asnl, false, false);
            Player toure = new Player("Toure", "Cheikh", 9, Role.Attaquant, asnl, false, false);

            Player delos = new Player("Delos", "Shaquil", 22, Role.Défenseur, asnl, true, false);
            Player camara = new Player("Camara", "Mamadou", 11, Role.Milieu, asnl, true, false);
            Player nangis = new Player("Nangis", "Lenny", 10, Role.Attaquant, asnl, true, false);



            Player dietsch = new Player("Dietsch", "Guillaume", 1, Role.Gardien, fcMetz, false, false);
            Player udol = new Player("Udol", "Mathieu", 3, Role.Défenseur, fcMetz, false, false);
            Player colin = new Player("Colin", "Maxime", 2, Role.Défenseur, fcMetz, false, false);
            Player cande = new Player("Cande", "Fali", 5, Role.Défenseur, fcMetz, false, false);
            Player traore = new Player("Traore", "Ismaël", 8, Role.Défenseur, fcMetz, false, false);
            Player ndoram = new Player("N'Doram", "Kévin", 6, Role.Milieu, fcMetz, false, false);
            Player diallo = new Player("Diallo", "Papa Amadou", 7, Role.Milieu, fcMetz, false, false);
            Player tchimbembe = new Player("Tchimbembe", "Warren", 12, Role.Milieu, fcMetz, false, false);
            Player sabaly = new Player("Sabaly", "Cheikh Tidiane", 14, Role.Milieu, fcMetz, false, false);
            Player mikautadze = new Player("Mikautadze", "Georges", 10, Role.Attaquant, fcMetz, false, false);
            Player lamkel = new Player("Lamkel Ze", "Didier", 11, Role.Attaquant, fcMetz, false, false);

            Player lo = new Player("Lô", "Aboubacar", 15, Role.Défenseur, fcMetz, true, false);
            Player atta = new Player("Atta", "Arthur", 25, Role.Milieu, fcMetz, true, false);
            Player tetteh = new Player("Tetteh", "Benjamin", 17, Role.Attaquant, fcMetz, true, false);

            Console.WriteLine($"Bonjour, avec quelle équipe souhaite tu intéragir aujourd'hui ?\n\n1 - {asnl.TeamName}\n2 - {fcMetz.TeamName}\n");
            Console.Write("Votre choix : ");
            string teamChoiceScreen = Console.ReadLine();

            int chooseTeam = 0;
            Team choosenTeam = null;
            bool continueWithTeam = true;

            while (continueWithTeam)
            {
                switch (teamChoiceScreen)
                {
                    case "1":
                        chooseTeam = HomeTeamChoice(asnl);
                        choosenTeam = asnl;
                        break;
                    case "2":
                        chooseTeam = HomeTeamChoice(fcMetz);
                        choosenTeam = fcMetz;
                        break;
                }
                switch (chooseTeam)
                {
                    case 1:
                        Console.Clear();
                        choosenTeam.DisplayTeamPlayers(choosenTeam.PlayerList);
                        choosenTeam.DisplayIndividualsStats(choosenTeam.PlayerList);
                        break;
                    case 2:
                        Console.Clear();
                        choosenTeam.DisplayTeamPlayers(choosenTeam.SubsitutePlayers);
                        choosenTeam.DisplayIndividualsStats(choosenTeam.SubsitutePlayers);
                        break;
                    case 3:
                        Console.Clear();
                        choosenTeam.DisplayTeamPlayers(choosenTeam.ExcludePlayer);
                        choosenTeam.DisplayIndividualsStats(choosenTeam.ExcludePlayer);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("De quelle équipe fait partie le joueur ?\n1 - Titulaire\n2 - Remplacant\n\n");
                        Console.Write("Choix : ");
                        string replacementChoice = Console.ReadLine();
                        switch (replacementChoice)
                        {
                            case "1":
                                choosenTeam.DisplayTeamPlayers(choosenTeam.PlayerList);
                                Player mainPlayer = choosenTeam.FindPlayerInList(choosenTeam.PlayerList);
                                choosenTeam.ChangePlayerInsideTeam(mainPlayer);
                                break;
                            case "2":
                                choosenTeam.DisplayTeamPlayers(choosenTeam.SubsitutePlayers);
                                Player substitutePlayer = choosenTeam.FindPlayerInList(choosenTeam.SubsitutePlayers);
                                choosenTeam.ChangePlayerInsideTeam(substitutePlayer);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Voulez vous vendre un joueur ou acheter ?\n\n1 - Vendre\n2 - Acheter\n");
                        Console.Write("Votre choix : ");
                        string buyOrSell = Console.ReadLine();
                        Console.Clear() ;
                        switch(buyOrSell)
                        {
                            case "1":
                                break;
                            case "2":
                                frenchLeague.DisplayLeagueTeam(choosenTeam);
                                Console.Write("\nVeuillez choisir le club où vous souhaitez acheter le joueur : ");
                                string chooseTransfertFrom = Console.ReadLine();
                                Team teamToBuyFrom = frenchLeague.ChooseTeamInLeague(chooseTransfertFrom);
                                Console.Clear();
                                Console.WriteLine("Souhaitez-vous voir l'équipe titulaire ou remplacante :\n1 - Titulaires\n2 - Remplacants");
                                string choosePermaOrSubstitute = Console.ReadLine();
                                switch(choosePermaOrSubstitute)
                                {
                                    case "1":
                                        teamToBuyFrom.DisplayTeamPlayers(teamToBuyFrom.PlayerList);
                                        Player toBuy = teamToBuyFrom.FindPlayerInList(teamToBuyFrom.PlayerList);
                                        toBuy.TransferPlayer(choosenTeam, teamToBuyFrom);
                                        break;
                                    case "2":
                                        teamToBuyFrom.DisplayTeamPlayers(teamToBuyFrom.SubsitutePlayers);
                                        Player toBuySubstitute = teamToBuyFrom.FindPlayerInList(teamToBuyFrom.SubsitutePlayers);
                                        toBuySubstitute.TransferPlayer(choosenTeam, teamToBuyFrom);
                                        break;
                                }
                                break;
                            default: 
                                break;
                        }
                        break;
                }
            }

        }
        public static int HomeTeamChoice(Team team)
        {
            Console.Clear();
            Console.WriteLine($"Bienvenue dans ton club {team.TeamName}, entraineur ! Que souhaitez vous faire avec l'équipe ?");
            Console.WriteLine($"\n1 - Afficher les membres de l'équipe titulaire.\n2 - Afficher les remplacants.\n3 - Afficher les blessés/joueurs exclus.\n4 - Changer la composition des équipes internes.\n5 - Transferer un joueur\n\nQuelle est votre choix : ");
            string choice = Console.ReadLine();
            return int.Parse(choice);
        }
        public static bool ReturnTeamHome()
        {
            Console.WriteLine("Pour revenir à l'accueil du club, entre la touche \"h\" : ");
            string choice = Console.ReadLine();
            if (choice == "h")
            {
                return true;
            }
            return false;
        }
        public static string AskingPlayerName()
        {
            Console.WriteLine("Quelle est le nom du joueur à transferer : ");
            string playerName = Console.ReadLine();
            return playerName;
        }
        public static int AskingShirtNumber()
        {
            Console.WriteLine("Veuillez préciser son numéro de maillot : ");
            string shirtNumber = Console.ReadLine();
            return int.Parse(shirtNumber);
        }
        public static void PressAnyKeyToContinue() 
        {
            Console.WriteLine("\nAppuyez sur n'importe quelle touche pour continuer...");
            string key = Console.ReadLine();
        }
    }
}
