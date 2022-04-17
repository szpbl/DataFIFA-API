using DataFIFA.Domain.Entities;
using DataFIFA.Domain.Entities.Enums;
using FluentAssertions;
using Xunit;

namespace DataFIFA.UnitTests
{
    public class MatchSould
    {
        [Fact]
        public void AddGoalsAndAssists()
        {
            var homeTeam = new Team("Chelsea");
            var awayTeam = new Team("Manchester");

            var player = new Player("Jorginho", 29, 85, Position.MC);
            var player2 = new Player("Loftus-Cheek", 25, 76, Position.MC);

            var match = new Match(homeTeam, awayTeam, "3-1", Competition.PremierLeague);

            match.AddGoal(player);
            match.AddGoal(player, player2);
            match.AddGoal(player, player2);

            player.Goals.Should().HaveCount(3);
            player2.Assists.Should().HaveCount(2);
        }
    }
}
