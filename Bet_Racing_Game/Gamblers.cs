using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    class Gamblers
    {
        string Name;// name of gambler
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        int Balance; // balance of gambler
        public int balance
        {
            get { return Balance; }
            set { Balance = value; }
        }
        private Bets Bet; // it can connect with an bet object
        public Bets bet
        {
            get { return Bet; }
            set { Bet = value; }
        } 
       
        
    }
}
