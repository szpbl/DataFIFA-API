namespace DataFIFA.Domain.Entities
{
    public class Team
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Player> Players { get; private set; }
        public List<Match> Matches { get; private set; }
        public int Played => Won + Lost + Drawn;
        public int Won { get; private set; }
        public int Drawn { get; private set; }
        public int Lost { get; private set; }
        public int GoalsFor { get; private set; }
        public int GoalsAgainst { get; private set; }
        public int GoalDiffrence => GoalsFor - GoalsAgainst;
        public int Assists { get; private set; }
        public int CleanSheets { get; private set; }

        public Team(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Players = new List<Player>();
            Matches = new List<Match>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }

        public void ComputeGoals(int goalsFor, int goalsAgainst)
        {
            GoalsFor += goalsFor;
            GoalsAgainst += goalsAgainst;
        }

        public void Win()
        {
            Won++;
        }

        public void Lose()
        {
            Lost++;
        }

        public void Draw()
        {
            Drawn++;
        }

        public void CleanSheet()
        {
            CleanSheets++;
        }
    }
}