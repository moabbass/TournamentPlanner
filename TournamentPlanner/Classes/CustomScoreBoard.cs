using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    public class CustomScoreBoard
    {
        public int rank { get; set; }
        public string teamName { get; set; }
        public int matchesWon { get; set; }
        public int matchesLost { get; set; }
        public int matchesPlayed { get; set; }
        public int winrate { get; set; }

        public CustomScoreBoard( string teamName, int matchesWon, int matchesLost, int matchesPLayed)
        {            
            this.teamName = teamName;
            this.matchesWon = matchesWon;
            this.matchesLost = matchesLost;
            this.matchesPlayed = matchesPLayed;
            this.rank = 0;
            this.winrate = 0;
        }


    }
}
