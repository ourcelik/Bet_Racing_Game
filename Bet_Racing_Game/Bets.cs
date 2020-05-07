using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    class Bets
    {
        int TotalWin=0;
                public int totalwin
        {
            get { return TotalWin; }
            set { TotalWin = value; }
        }
        int Amount; // how much money gamblers deposit

        public int amount
        {
            get {return Amount; }
            set { Amount = value; }
        }
        Label KeepTotalBet;
        public Label keeptotalbet
        {
            get { return KeepTotalBet; }
            set { KeepTotalBet = value; }
        }
        int RacerNum;
        public int racernum // keeps track of which competitor the gambler has chosen
        {
            get { return RacerNum; }
            set { RacerNum = value; }
        }
        Gamblers Gambler; // it can connect with gamblers 
        public Gamblers gambler
        {
            get { return Gambler; }
            set { Gambler = value; }       
        }
        public void YouWin(int winningracer) // if racernum is the same as winningracer amount adds your acount balance
        {
            if(RacerNum == winningracer )
            {
                if(Amount>=0 && winningracer<=3 &&winningracer >0)
                Gambler.balance += Amount;
                TotalWin += Amount;

            }
            else if (winningracer==4) // the is an tie situation
            {

            }
            else // you lost
            {
                TotalWin -= Amount;
                Gambler.balance -= Amount;
            }
        }
        public void Yourbet()
        {
            keeptotalbet.Text = gambler.bet.amount.ToString();
        }




    }
}
