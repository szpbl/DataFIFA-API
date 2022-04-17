using DataFIFA.Domain.Entities.Enums;

namespace DataFIFA.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Goal> Goals { get; private set; }
        public List<Assist> Assists { get; private set; }
        public int Played { get; private set; }
        public int Won { get; private set; }
        public int Drawn { get; private set; }
        public int Lost { get; private set; }
        public int CleanSheet { get; private set; }
        public int Age { get; private set; }
        public int Overall { get; private set; }
        public Position Position { get; private set; }

        public Player(string name, int age, int overall, Position position)
        {
            Id = Guid.NewGuid();
            Name = name;
            Goals = new List<Goal>();
            Assists = new List<Assist>();
            Age = age;
            Overall = overall;
            Position = position;
        }

        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        public void AddAssist(Assist assist)
        {
            Assists.Add(assist);
        }
    }
}