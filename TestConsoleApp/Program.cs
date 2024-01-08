using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
   

    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
    }

    public interface ITeam
    {
        void Add(Player player);
        void Remove(int playerId);
        Player GetPlayerById(int playerId);
        Player GetPlayerByName(string playerName);
        List<Player> GetAllPlayers();
    }

    public class OneDayTeam : ITeam
    {
        public static List<Player> oneDayTeam = new List<Player>();

        public OneDayTeam()
        {
            oneDayTeam.Capacity = 11;
        }

        public void Add(Player player)
        {
            if (oneDayTeam.Count < oneDayTeam.Capacity)
            {
                oneDayTeam.Add(player);
            }
            else
            {
                Console.WriteLine("Cannot add more than 11 players to the team.");
            }
        }

        public void Remove(int playerId)
        {
            var player = oneDayTeam.FirstOrDefault(p => p.PlayerId == playerId);
            if (player != null)
            {
                oneDayTeam.Remove(player);
            }
        }

        public Player GetPlayerById(int playerId)
        {
            return oneDayTeam.FirstOrDefault(p => p.PlayerId == playerId);
        }

        public Player GetPlayerByName(string playerName)
        {
            return oneDayTeam.FirstOrDefault(p => p.PlayerName == playerName);
        }

        public List<Player> GetAllPlayers()
        {
            return oneDayTeam;
        }

    }

    class Program
    {
        public static void Crud()
        {
            OneDayTeam team = new OneDayTeam();
            Console.WriteLine("Enter 1:To Add Player \n2:To Remove Player by Id \n3.Get Player By Id \n4.Get Player by Name \n5.Get All Players:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Player Id, Name, and Age:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    string name = Console.ReadLine();
                    int age = Convert.ToInt32(Console.ReadLine());
                    team.Add(new Player { PlayerId = id, PlayerName = name, PlayerAge = age });
                    Console.WriteLine("Player added Succesfully with PlayerId : {0}", id);
                    break;
                case 2:
                    Console.WriteLine("Enter Player Id to remove:");
                    id = Convert.ToInt32(Console.ReadLine());
                    team.Remove(id);
                    Console.WriteLine("Player Removed Succesfully with PlayerId : {0}", id);
                    break;
                case 3:
                    Console.WriteLine("Enter Player Id:");
                    id = Convert.ToInt32(Console.ReadLine());
                    var player = team.GetPlayerById(id);
                    if (player != null)
                    {
                        Console.WriteLine($"Player Id: {player.PlayerId}, Name: {player.PlayerName}, Age: {player.PlayerAge}");
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Player Id");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter Player Name:");
                    name = Console.ReadLine();
                    player = team.GetPlayerByName(name);
                    if (player != null)
                    {
                        Console.WriteLine($"Player Id: {player.PlayerId}, Name: {player.PlayerName}, Age: {player.PlayerAge}");
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Player Name");
                    }
                    break;
                case 5:
                    var players = team.GetAllPlayers();
                    foreach (var p in players)
                    {
                        Console.WriteLine($"Player Id: {p.PlayerId}, Name: {p.PlayerName}, Age: {p.PlayerAge}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        static void Main(string[] args)
        {
         
            bool t = false;
            do 
            {
                if (t) { Console.WriteLine("Do you want to Continue (yes/no)"); 
                string ch=Console.ReadLine();
                    switch (ch)
                    {
                        case "yes":
                            {
                                Crud();
                                break;
                            }
                        case "no":
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Choose Correct Option");
                                break;
                            }
                    }
                }
                else
                {
                    Crud();
                    t = true;
                }
            }
            while (t==true);
        }
    }

}
