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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            Manager.e.settingWinner += reOpenView;
        }

        private void matchScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            ScheduleView sV = new ScheduleView();
            sV.Show(); 
        }
        public void reOpenView(object sender, EventArgs e)
        {
            ScheduleView sV = new ScheduleView();
            sV.Show();
        }

        private void scoreBoardBtn_Click(object sender, RoutedEventArgs e)
        {
            ScoreBoard sC = new ScoreBoard();
            sC.Show();
        }
    }
}
