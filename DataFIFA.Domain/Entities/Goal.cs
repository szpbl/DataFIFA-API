using DataFIFA.Domain.Entities.Enums;

namespace DataFIFA.Domain.Entities
{
    public class Goal
    {
        public Guid Id { get; private set; }
        public Guid PlayerScoredId { get; private set; }
        public Competition Competition { get; private set; }

        public Goal(Guid playerId, Competition competition)
        {
            Id = Guid.NewGuid();
            PlayerScoredId = playerId;
            Competition = competition;
        }
    }
}