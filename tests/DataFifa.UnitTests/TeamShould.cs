using DataFIFA.Domain.Entities;
using DataFIFA.Domain.Entities.Enums;
using FluentAssertions;
using Xunit;

namespace DataFifa.UnitTests
{
    public class TeamShould
    {
        [Fact]
        public void AddNewPlayer()
        {
            var team = new Team("Chelsea");
            var player = new Player("Jorginho", 29, 85, Position.MC);

            team.AddPlayer(player);

            Assert.Contains(player, team.Players);
        }

        [Fact]
        public void ComputeMatch()
        {
            var homeTeam = new Team("Chelsea");
            var awayTeam = new Team("Manchester");
            var match = new Match(homeTeam, awayTeam, "3-0", Competition.PremierLeague);

            match.PlayMatch();
            homeTeam.AddMatch(match);

            homeTeam.Won.Should().Be(1);
            homeTeam.GoalsFor.Should().Be(3);
            homeTeam.GoalsAgainst.Should().Be(0);
            homeTeam.GoalDiffrence.Should().Be(3);
            homeTeam.CleanSheets.Should().Be(1);
        }
    }
}
