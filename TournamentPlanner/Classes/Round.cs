using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    public class Round
    {

        public string groupNumber { get; set; }
        public int roundNumber { get; set; }
        public List<Match> matches { get; set; }


        public Round(string groupNumber,int roundNum,List<Match> ms)
        {
            this.roundNumber = roundNum;
            this.groupNumber = groupNumber;
            this.matches = ms;
        }
    }
}
