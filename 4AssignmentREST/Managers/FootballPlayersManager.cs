using _4AssignmentREST.Models;

namespace _4AssignmentREST.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;

        public static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer {Id = _nextId++, Name = "Haaland", Age = 22, ShirtNumber = 9},
            new FootballPlayer {Id = _nextId++, Name = "Pele", Age = 81, ShirtNumber = 10},
            new FootballPlayer {Id = _nextId++, Name = "Beckham", Age = 47, ShirtNumber = 7},
            new FootballPlayer {Id = _nextId++, Name = "Neymar", Age = 30, ShirtNumber = 10},
            new FootballPlayer {Id = _nextId++, Name = "Hamsik", Age = 35, ShirtNumber = 17}
        };        

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(Data);            
        }

        public FootballPlayer? GetById(int id)
        {
            return Data.Find(player => player.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newPlayer)
        {
            newPlayer.Id = _nextId++;
            Data.Add(newPlayer);
            return newPlayer;
        }

        public FootballPlayer? Update(int id, FootballPlayer updates)
        {
            FootballPlayer? player = Data.Find(player1 => player1.Id == id);
            if (player == null) return null;
            player.Name = updates.Name;
            player.Age = updates.Age;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }

        public FootballPlayer? Delete(int id)
        {
            FootballPlayer? player = Data.Find(player1 => player1.Id == id);
            if (player == null) return null;
            Data.Remove(player);
            return player;            
        }
    }
}
