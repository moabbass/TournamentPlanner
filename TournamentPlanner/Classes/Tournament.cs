using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    public class Tournament
    {
        public string name { get; set; }
        public string type { get; set; }
        public int numberOfTeams { get; set; }
        public int numberOfPitches { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Tournament(string name, string type, int numOfTeams, int numberOfPitches)
        {
            this.name = name;
            this.type = type;
            this.numberOfTeams = numOfTeams;
            this.numberOfPitches = numberOfPitches;
            //this.startDate = startDate;  
            //this.endDate = endDate;
        }
    }
}
