using DataFIFA.Domain.Entities;
using DataFIFA.Domain.Entities.Enums;
using FluentAssertions;
using Xunit;

namespace DataFIFA.UnitTests
{
    public class PlayerShould
    {
        [Fact]
        public void ComputePlayerGoals()
        {
            var player = new Player("Jorginho", 29, 85, Position.MC);
            var goal = new Goal(player.Id, Competition.PremierLeague);

            player.AddGoal(goal);

            Assert.Contains(goal, player.Goals);
        }

        [Fact]
        public void FilterGoalsByCompetition()
        {
            var player = new Player("Jorginho", 29, 85, Position.MC);
            var goal = new Goal(player.Id, Competition.PremierLeague);
            var goal2 = new Goal(player.Id, Competition.PremierLeague);
            var goal3 = new Goal(player.Id, Competition.Friendly);

            player.AddGoal(goal);
            player.AddGoal(goal2);
            player.AddGoal(goal3);

            player.Goals.Should().HaveCount(3);
            Assert.Equal(2, player.Goals.FindAll(x => x.Competition == Competition.PremierLeague).Count);
        }

        [Fact]
        public void FilterAssistslByCompetition()
        {
            var player = new Player("Jorginho", 29, 85, Position.MC);

            var assist = new Assist(player.Id, Competition.PremierLeague);
            var assist2 = new Assist(player.Id, Competition.PremierLeague);
            var assist3 = new Assist(player.Id, Competition.Friendly);

            player.AddAssist(assist);
            player.AddAssist(assist2);
            player.AddAssist(assist3);

            player.Assists.Should().HaveCount(3);
            Assert.Equal(2, player.Assists.FindAll(x => x.Competition == Competition.PremierLeague).Count);
        }
    }
}
