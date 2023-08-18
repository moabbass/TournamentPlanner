using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    public class Leaderboard
    {
        public List<Team> teams { get; set; }

        public Leaderboard(List<Team> teams)
        {
            this.teams = teams;
        }

    }
}
