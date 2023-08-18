using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    public class Team
    {       
        public string teamName { get; set; }
        public int seed { get; set; }
        public int gamesPerDay { get; set; }

        public int LeaderBoardRank { get; set; }
        public int matchesWon { get; set; }
        public int matchesLost { get; set; }
        public int matchesPlayed { get; set; }
        public int winrate { get; set; }


        public Team(string teamName, int seed)
        {
            this.teamName = teamName;
            this.seed = seed;
            //gamesPerDay = this.gamesPerDay;
            this.LeaderBoardRank = 0;
            this.matchesWon = 0;
            this.matchesLost = 0;
            this.matchesPlayed = 0;
            this.winrate = 0;
        }


        
    }
}
