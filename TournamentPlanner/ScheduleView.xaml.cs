using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Match = TournamentPlanner.Classes.Match;

namespace TournamentPlanner
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : Window
    {
        public List<CustomSchedule> matches;

       // ObservableCollection<CustomSchedule> matchesCollection;

        public ScheduleView()
        {

            InitializeComponent();

            //this.DataContext = this;

            matches = new List<CustomSchedule>();
            this.DataContext = this;
            Manager.e.settingWinner += redoSchedule;
            //matchesCollection = new ObservableCollection<CustomSchedule>();

            scheduleTableList.ItemsSource = matches;

            setSchedule();

            
            // this.DataContext = matches;

            
            

            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(scheduleTableList.ItemsSource);

            //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
        }


        public void setSchedule()
        {
            matches.Clear();
            //scheduleTableList.Items.Clear();
            foreach (Round r in Manager.rounds)
            {
                foreach (Match m in r.matches)
                {
                    string winnerTeamName;
                    if (m.winner== null)
                    {
                        winnerTeamName = "";
                    }
                    else
                    {
                        winnerTeamName = m.winner.teamName;
                    }
                    CustomSchedule cS = new CustomSchedule(r.groupNumber,r.roundNumber, m.teamA.teamName, m.teamB.teamName, winnerTeamName);
                    matches.Add(cS);
                    Console.WriteLine(cS.roundNum.ToString()," ",cS.teamA, " ", cS.teamB);
                   //matchesCollection.Add(cS);
                }                
            }            
           // string test = "meh";
            //scheduleTableList.ItemsSource = matches;

        }

        public void redoSchedule(object sender, EventArgs e)
        {
            setSchedule();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (scheduleTableList.SelectedItem!= null)
            {
                CustomSchedule cs = (CustomSchedule)scheduleTableList.SelectedItem;
                if (cs.winnerTeam == "")
                {

                    SettingWinner sW = new SettingWinner(cs.groupNum, cs.roundNum, cs.teamA, cs.teamB);

                    sW.ShowDialog();

                }
                else
                {
                    MessageBox.Show("There is a winner already set for this match");
                }
                
                //setSchedule();
            }
        }
    }
}
