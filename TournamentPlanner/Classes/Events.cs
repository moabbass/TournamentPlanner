using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPlanner.Classes
{
    public  class Events
    {
        // Event handler set up
        public event EventHandler listChanged;
        public event EventHandler settingWinner;

        public virtual void OnlistChanged(EventArgs e)
        {

            EventHandler handler = listChanged;
            handler?.Invoke(this, e);

        }
        public virtual void onSettingWinner(EventArgs e)
        {
            EventHandler handler = settingWinner;
            handler?.Invoke(this, e);
        }

        public delegate void ListDidChange(object sender, EventArgs e);
        public delegate void winnerSet(object sender, EventArgs e);
    }
}
