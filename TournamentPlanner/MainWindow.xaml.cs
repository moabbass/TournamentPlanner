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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TournamentPlanner.Classes;

namespace TournamentPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Events ev = new Events();
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            Manager.e.listChanged +=listChanged;

            List<string> types = new List<string>();
            types.Add("Round Robin");
            types.Add("knock Out");

            matchType.ItemsSource = types;            
            //listbox.ItemsSource = Manager.teamNames;
            //matchType.Items.Add("Round Robin");
        }

        public void listChanged(object sender, EventArgs e)
        {            
            listbox.Items.Clear();
            foreach (Team t in Manager.teams)
            {
                listbox.Items.Add(t.teamName);                
            }
        }

        private async void addTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTeamView win = new AddTeamView(); 
            win.Show();
           // System.Threading.Thread.Sleep();            

        }

        private void Button_Click(object sender, RoutedEventArgs e) //create tourney button
        {
            string tournName = TournamentName.Text;
            int numbOfTeams = Int32.Parse(numberOfTeams.Text);
            int numbOfPitches = Int32.Parse(numberOfPitches.Text);
            string matchTypes = (this.matchType.SelectedItem.ToString());
            Tournament tourney = new Tournament(tournName, matchTypes, numbOfTeams, numbOfPitches);
            Manager.createAtourney(tourney);

            this.createTourneyBtn.IsEnabled = false;
            this.addTeamBtn.IsEnabled = true;
            this.removeTeamBtn.IsEnabled = true;
            //listbox.ItemsSource = Manager.teams;
            Console.WriteLine("tournament created");
            

        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.tourney.type == "Round Robin")
            {
                //Manager.roundRobin();
                Manager.settingSchedule();
                foreach (Round r in Manager.rounds)
                {
                    Console.WriteLine(r.roundNumber);
                    foreach (Match m in r.matches)
                    {
                        Console.WriteLine(m.ID, m.teamA,m.teamB);
                    }                    
                }
            }
            else
            {

            }
            
            MainMenu mU= new MainMenu();
            mU.Show();
        }
    }
}
