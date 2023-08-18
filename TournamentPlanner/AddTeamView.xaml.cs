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
    /// Interaction logic for AddTeamView.xaml
    /// </summary>
    public partial class AddTeamView : Window
    {      
        public AddTeamView()
        {
            InitializeComponent();
            Events e = new Events();
            //e.listChanged += teamAdded;
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Manager.addTeam(t);
                //teamAdded(this, new EventArgs());

                string tName = teamNameTxt.Text;
                int seed = Int32.Parse(this.teamSeedTxt.Text);
                Team t = new Team(tName, seed);

                Manager.addTeam(t);
                
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void teamAdded(object sender, EventArgs e)
        {
            string tName = teamNameTxt.Text;
            int seed = Int32.Parse(this.teamSeedTxt.Text);
            Team t = new Team(tName, seed);
            
            Manager.addTeam(t);
        }



        }
}
