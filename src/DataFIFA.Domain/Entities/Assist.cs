using DataFIFA.Domain.Entities.Enums;

namespace DataFIFA.Domain.Entities
{
    public class Assist
    {
        public Guid Id { get; private set; }
        public Guid PlayerId { get; private set; }
        public Competition Competition { get; private set; }

        public Assist(Guid playerId, Competition competition)
        {
            Id = Guid.NewGuid();
            PlayerId = playerId;
            Competition = competition;
        }
    }
}