using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    public class Match
    {
        public string ID { get; set; }
        public Team teamA { get; set; }
        public Team teamB { get; set; }
        public DateTime scheduledDate {get; set; }        
        public Team winner { get; set; }

        public Match(string id, Team tA, Team tB)
        {
            this.ID = id;
            this.teamA = tA;
            this.teamB = tB;
            this.winner = null;
           // this.scheduledDate = scheduledDate;
            
        }
    }
}
