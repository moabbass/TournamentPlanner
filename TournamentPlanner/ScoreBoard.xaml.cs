using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TournamentPlanner.Classes;

namespace TournamentPlanner
{
    /// <summary>
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    public partial class ScoreBoard : Window
    {
        public List<CustomScoreBoard> scores;
        public ScoreBoard()
        {
            InitializeComponent();
            scores = new List<CustomScoreBoard>();
            gettingScores();

            Manager.setWinrate();
            if (Manager.BestTeams().Count>1)
            {
                TieBreakerBtn.Visibility = Visibility.Visible;
            }

            setWinRate();
            setRanks();

            //scores = scores.OrderBy(o => o.Winrate).ToList();
            scoreBoardList.ItemsSource = scores;

        }



        public void gettingScores()
        {
            foreach (Team t in Manager.teams)
            {
                if (t.teamName != "Nullable")
                {
                    CustomScoreBoard csb = new CustomScoreBoard(t.teamName, t.matchesWon, t.matchesLost, t.matchesPlayed);
                    scores.Add(csb);
                }
                
            }
        }


        public void setWinRate()
        {

            foreach (CustomScoreBoard csb in scores)
            {
                csb.winrate = csb.matchesWon- csb.matchesLost;
            }

        }

        public void setRanks()
        {
            for(int i=0; i < scores.Count; i++)
            {
                scores[i].rank = i+1;
            }
        }

        private void TieBreakerBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Team> teamsTied = Manager.BestTeams();
            if (teamsTied.Count==2)
            {
                List<Match> match = new List<Match>();

                match.Add(new Match((Manager.matches.Count + 1).ToString(), teamsTied[0], teamsTied[1]));

                Round eliminationRound = new Round("Elimination round",Manager.rounds.Count+1,match);

                Manager.rounds.Add(eliminationRound);
            }
           
        }
    }
    
}
