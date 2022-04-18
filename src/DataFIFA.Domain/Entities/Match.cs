using DataFIFA.Domain.Entities.Enums;

namespace DataFIFA.Domain.Entities
{
    public class Match
    {
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public string Score { get; private set; }
        public Competition Competition { get; private set; }

        public Match(Team homeTeam, Team awayTeam, string score, Competition competition)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Score = score;
            Competition = competition;
        }

        public void AddGoal(Player player)
        {
            var goal = new Goal(player.Id, Competition);
            player.AddGoal(goal);
        }

        public void AddGoal(Player playerScored, Player playerAssisted)
        {
            var goal = new Goal(playerScored.Id, Competition);
            playerScored.AddGoal(goal);
            var assist = new Assist(playerAssisted.Id, Competition);
            playerAssisted.AddAssist(assist);
        }
        public void PlayMatch()
        {
            var goals = Score.Split("-");
            var homeGoals = int.Parse(goals[0]);
            var awayGoals = int.Parse(goals[1]);

            if (homeGoals > awayGoals)
            {
                HomeTeam.Win();
                AwayTeam.Lose();
            }
            else if (awayGoals > homeGoals)
            {
                AwayTeam.Lose();
                HomeTeam.Win();
            }
            else
            {
                HomeTeam.Draw();
                AwayTeam.Draw();
            }

            if (awayGoals == 0)
            {
                HomeTeam.CleanSheet();
            }
            
            if (homeGoals == 0)
            {
                AwayTeam.CleanSheet();
            }
            
            HomeTeam.ComputeGoals(homeGoals, awayGoals);
            AwayTeam.ComputeGoals(awayGoals, homeGoals);
        }
    }
}
