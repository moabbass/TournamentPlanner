using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentPlanner.Classes;

namespace TournamentPlanner
{
    public partial class SettingWinner : Form
    {
        public string groupNum;
        public int roundNum;        
        public string winnerTeam;
        public string teamA;
        public string teamB;
        public SettingWinner()
        {
            InitializeComponent();

            
        }

        public SettingWinner(string grpNum,int roundNum,string button1, string button2)
        {
            InitializeComponent();
            //lblMessage.Text = message;

            this.groupNum = grpNum;
            this.roundNum = roundNum;

            this.teamA = button1;
            this.teamB = button2;

            this.button1.Text = button1;
            this.button2.Text = button2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.setMatchWinner(groupNum,roundNum,teamA,teamB,button1.Text);
            Manager.e.onSettingWinner(null);
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manager.setMatchWinner(groupNum, roundNum, teamA, teamB, button2.Text);
            Manager.e.onSettingWinner(null);
            this.Close();
        }

        
    }
    
}

