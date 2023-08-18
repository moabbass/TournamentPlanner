using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    class Manager
    {
        public static Tournament tourney { get; set; }
        public static List<Team> teams { get; set; }
        //public static List<string> teamNames { get; set; }
        public static ObservableCollection<string> teamNames { get; set; }

        public static List<Round> rounds { get; set; }
        public static List<Match> matches { get; set; } 
        public static Leaderboard leaderboard { get; set; }        

        public static DateTime lastSetMatchDate { get; set; }
        public static Events e = new Events();

        public static void createAtourney(Tournament tourn)
        {
            tourney = tourn;
            teams = new List<Team>();
            rounds = new List<Round>();
            teamNames = new ObservableCollection<string>();
            matches = new List<Match>();
            leaderboard = new Leaderboard(teams);
            lastSetMatchDate = DateTime.MinValue;
        }

        public static void addTeam(Team t)
        {

            teams.Add(t);
            teamNames.Add(t.teamName);
            
            e.OnlistChanged(null);

            foreach (string teamn in teamNames)
            {
                Console.WriteLine(teamn);
                
            } 
        }

        public static void teamAdded(object sender, EventArgs e)
        {
            Console.WriteLine("EVENT WORKS");

        }

        public static void createMatch(Match m)
        {
            //matches.Add(m);
        }
       

        public static void settingSchedule()
        {
            if (tourney != null)
            {
                if (tourney.numberOfTeams != 0)
                {
                    if(teams.Count <= 6)
                    {
                        roundRobin("A",teams);
                    }
                    else
                    {
                        int teamsCount = teams.Count;                        
                        List<Team> theTeamsList = teams.OrderBy(o => o.seed).ToList();
                        List<Team> teamsListA = new List<Team>();
                        List<Team> teamsListB = new List<Team>();

                        for (int i = 0; i < teamsCount; i++)
                        {
                            if(i % 2 == 0)
                            {
                                teamsListA.Add(theTeamsList[i]);
                            }
                            else
                            {
                                teamsListB.Add(theTeamsList[i]);
                            }
                        }

                        roundRobin("A", teamsListA);

                        roundRobin("B", teamsListB);

                    }
                }
            }
        }

        public static void setMatchWinner(string GroupNum,int roundNum,string teamA, string teamB, string winnerTeam)
        {           
            foreach (Round r in rounds)
            {
                if (r.groupNumber == GroupNum && r.roundNumber == roundNum)
                {
                    foreach (Match m in r.matches)
                    {
                        if (m.teamA.teamName == teamA && m.teamB.teamName == teamB )
                        {
                            if (m.teamA.teamName== winnerTeam)
                            {
                                m.winner = m.teamA;
                                addAWin(m.teamA);
                                addALoss(m.teamB);
                            }
                            if (m.teamB.teamName == winnerTeam)
                            {
                                m.winner = m.teamB;
                                addAWin(m.teamB);
                                addALoss(m.teamA);
                            }
                        }
                    }
                }
            }
        }

        public static void addAWin(Team winner)
        {
            foreach (Team t in teams)
            {
                if (t == winner)
                {
                    t.matchesPlayed++;
                    t.matchesWon++;
                }
            }
        }

        public static void addALoss(Team loser)
        {
            foreach (Team t in teams)
            {
                if (t == loser)
                {
                    t.matchesPlayed++;
                    t.matchesLost++;
                }
            }
        }

        public static void roundRobin(string groupNumb, List<Team> teamsList)
        {
            List<Team> teamOrder = teamsList;
            int lastindex = teamOrder.Count - 1;
            
            //if (tourney.numberOfTeams % 2 == 0) // even
            if (teamsList.Count % 2 == 0) // even
            {
                int matchesPerRound = teamsList.Count / 2;

                for (int o = 1; o < teamsList.Count; o++)
                {
                    List<Match> ms = new List<Match>();

                    for (int i = 0; i < matchesPerRound; i++)
                    {
                        Match m = new Match(matches.Count + 1.ToString(), teamOrder[i], teamOrder[lastindex - i]);
                        ms.Add(m);
                        matches.Add(m);
                    }

                    Round r = new Round(groupNumb, o, ms);
                    rounds.Add(r);

                    teamOrder = nextRound(teamOrder);
                }
            }
            else // odd
            {
                teamsList.Add(new Team("Nullable", 0));
                lastindex = teamOrder.Count - 1;
                int matchesPerRound = teamOrder.Count / 2;

                for (int o = 1; o < teamOrder.Count; o++)
                {
                    List<Match> ms = new List<Match>();

                    for (int i = 0; i < matchesPerRound; i++)
                    {
                        if (teamOrder[i].teamName.Equals("Nullable") || teamOrder[lastindex - i].teamName.Equals("Nullable"))
                        {
                            continue;
                        }
                        else
                        {
                            Match m = new Match(matches.Count + 1.ToString(), teamOrder[i], teamOrder[lastindex - i]);
                            ms.Add(m);
                            matches.Add(m);
                        }

                    }

                    Round r = new Round(groupNumb, o, ms);
                    rounds.Add(r);

                    teamOrder = nextRound(teamOrder);
                }
            }
        
        }

        public static List<Team> nextRound(List<Team> teamOrder)
        {
            List<Team> newRound = new List<Team>();

            newRound = new List<Team>();

            int teamsCount = teamOrder.Count;

            for (int i = 0; i < teamsCount; i++)
            {
                newRound.Add(null);
            }
            

          //newRound[0] = teamOrder[0];
          //newRound[1] = teamOrder[teamsCount - 1];

            for (int i =0; i < teamsCount; i++)
            {
                if (i == 0)
                {
                    newRound[i] = teamOrder[i];
                }               

                if(i == 1)
                {
                    newRound[i] = teamOrder[teamsCount - i];
                }
                
                if( i > 1)
                {                    
                    newRound[i] = teamOrder[i-1];
                }
            }
            return newRound;

        }

        public static void setWinrate()
        {
            if(teams.Count!=0)
            {
                foreach (Team t in teams)
                {
                    t.winrate = t.matchesWon - t.matchesLost;
                }
            }
        }

        public static void setwinnner() 
        {
            if (teams.Count<7)
            {
                foreach (Team t in teams)
                {
                    
                }
            }
        }



        public static List<Team> BestTeams()  // teams with highest winrate 
        {
            int highestWinrate = 0;
            List<Team> tieTeams = new List<Team>();


            if (teams.Count < 7)
            {
                foreach (Team t in teams)
                {
                    if (t.winrate> highestWinrate)
                    {
                        highestWinrate = t.winrate;
                    }
                }                

                foreach (Team t in teams)
                {
                    if (t.winrate == highestWinrate)
                    {
                        tieTeams.Add(t);
                    }
                }
            }

            return tieTeams;

        }

        public static bool matchAlreadyMade(Team t)
        {
            foreach (Match m in matches)
            {
                if (m.teamA==t || m.teamB == t)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
