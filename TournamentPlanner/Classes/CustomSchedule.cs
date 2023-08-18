using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    public class CustomSchedule
    {
        public string groupNum { get; set; }
        public int roundNum { get; set; }
        public string teamA { get; set; }
        public string teamB { get; set; }
        public string winnerTeam { get; set; }

        public CustomSchedule(string group,int num, string teamA, string teamB, string winner)
        {
            this.groupNum = group;
            this.roundNum = num;
            this.teamA = teamA;
            this.teamB = teamB;
            this.winnerTeam = winner;
           // this.winnerTeam = winnerTeam;
        }
    }
}
