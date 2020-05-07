using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proje
{

    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            Arrays();

        }
        int winningracer;// keep who win and use it for bet system
        Racer[] Racers;//keep racer
        Gamblers[] gamblers;// keep gamblers
        Random randomize = new Random();
        int notchangeuser1 = 0;//it provide you to not change your racer after you bet anotherone for user1
        int notchangeuser2 = 0;//user2
        int notchangeuser3 = 0;//user3



        public void Arrays() // create gamblers && racer and other needs
        {
            gamblers = new Gamblers[3]
            {
                new Gamblers()
                {
                 name = "Onur",
                 balance = 1000,
                 bet = new Bets(),
                },
                new Gamblers()
                {
                    name ="Ali",
                    balance = 1000,
                    bet = new Bets(),
                },
                new Gamblers()

                {
                     name ="Mustafa",
                    balance = 1000,
                    bet = new Bets(),
                },



            };
            Racers = new Racer[3]
            {
                new Racer()
                {
                  racearea = Area.Width-78,
                  racerpic = racer1,
                  rndm =randomize,
                  firstposition = 12,
                },
                new Racer()
                {
                  racearea = Area.Width-78,
                  racerpic = racer2,
                  rndm =randomize,
                  firstposition = 12,
                },
                new Racer()
                {
                 racearea = Area.Width-78,
                  racerpic = racer3,
                  rndm =randomize,
                  firstposition = 12,
                },


            };
            for (int i = 0; i < gamblers.Length; i++)
            {
                gamblers[i].bet.gambler = gamblers[i];
                gamblers[i].bet.keeptotalbet = yourbet;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Area_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            racerbutton.Enabled = false;
            betbutton.Enabled = false;
            reset.Enabled = true;
            Start.Enabled = false;

            
            bool winner = true; // it provide to stop running when all the racers finish the race  
            while (winner)
            {
                raceinfo1.Visible = true;
                raceinfo2.Visible = true;

                bool a = Racers[0].Run();
                bool b = Racers[1].Run();
                bool c = Racers[2].Run();
                if (Racers[0].where() > Racers[1].where() && Racers[0].where() > Racers[2].where())
                {
                    raceinfo1.Text = $"Whiteman ahead of Red and Yellow Men ";

                    if (Racers[0].where() - Racers[1].where() < 3 && Racers[0].where() - Racers[1].where() > 0)
                    {
                        raceinfo2.Text = $"The gap between White and Red closing ";
                    }
                    if (Racers[0].where() - Racers[2].where() < 3 && Racers[0].where() - Racers[2].where() > 0)
                    {
                        raceinfo2.Text = $"The gap between White and Yellow closing ";
                    }
                    else
                    {
                        raceinfo2.Text = " ";
                    }
                }
                if (Racers[1].where() > Racers[0].where() && Racers[1].where() > Racers[2].where())
                {
                    raceinfo1.Text = $"RedMan ahead of White and Yellow men ";

                    if (Racers[1].where() - Racers[0].where() < 3 && Racers[1].where() - Racers[0].where() > 0)
                    {
                        raceinfo2.Text = $"The gap between Red and White men closing ";
                    }
                    if (Racers[1].where() - Racers[2].where() < 3 && Racers[1].where() - Racers[2].where() > 0)
                    {
                        raceinfo2.Text = $"The gap between Red and Yellow men closing ";
                    }
                    else
                    {
                        raceinfo2.Text = " ";
                    }
                }
                if (Racers[2].where() > Racers[1].where() && Racers[2].where() > Racers[0].where())
                {
                    raceinfo1.Text = $"Yellowman ahead of White and Red men ";

                    if (Racers[2].where() - Racers[0].where() < 3 && Racers[2].where() - Racers[0].where() > 0)
                    {
                        raceinfo2.Text = $"The gap between Yellow and white closing ";
                    }
                    if (Racers[2].where() - Racers[1].where() < 3 && Racers[2].where() - Racers[1].where() > 0)
                    {
                        raceinfo2.Text = $"The gap between Yellow and Red men closing ";
                    }
                    else
                    {
                        raceinfo2.Text = " ";
                    }
                }






                if ((a && b && c))
                {
                    winner = false;

                }
                // it provide more slow running
                raceinfo1.Refresh();
                label6.Refresh();
                raceinfo2.Refresh();
                racer1.Refresh();
                racer2.Refresh();
                racer3.Refresh();



            }
            if (Racers[0].whowin < Racers[1].whowin && Racers[0].whowin < Racers[2].whowin)//decide who win 
            {
                winnor.Visible = true;
                firswin.Visible = true;
                raceinfo2.Visible = false;
                raceinfo1.Visible = false;
                winningracer = 1;
            }
            else if (Racers[1].whowin < Racers[0].whowin && Racers[1].whowin < Racers[2].whowin)
            {
                winnor.Visible = true;
                redwin.Visible = true;
                raceinfo2.Visible = false;
                raceinfo1.Visible = false;
                winningracer = 2;

            }
            else if (Racers[2].whowin < Racers[1].whowin && Racers[2].whowin < Racers[0].whowin)
            {
                winnor.Visible = true;
                yellowwin.Visible = true;
                raceinfo2.Visible = false;
                raceinfo1.Visible = false;
                winningracer = 3;

            }
            else if (Racers[0].whowin == Racers[1].whowin || Racers[0].whowin == Racers[2].whowin || Racers[1].whowin == Racers[2].whowin)// tie situation
            {
                MessageBox.Show("The results are in... and we have a tie.Your bets was returned ");
                winningracer = 4;
            }

            for (int i = 0; i < gamblers.Length; i++)
            {
                gamblers[i].bet.YouWin(winningracer);

            }
            
        }

        private void reset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gamblers.Length; i++)
            {
                gamblers[i].bet.amount = 0;
            }
            notchangeuser1 = 0;
            notchangeuser2 = 0;
            notchangeuser3 = 0;
            gambler1.Checked = false;
            gambler2.Checked = false;
            gambler3.Checked = false;
            winnor.Visible = false;
            reset.Enabled = false;
            Start.Enabled = true;
            redwin.Visible = false;
            yellowwin.Visible = false;
            firswin.Visible = false;
            for (int i = 0; i < Racers.Length; i++) // to reset place of racer
            {
                Racers[i].StartAgain();

            }

        }

        private void dog1_Click(object sender, EventArgs e)
        {

        }

        private void bettor1_CheckedChanged(object sender, EventArgs e)
        {
            gamblers[0].bet.Yourbet();
            if (notchangeuser1 == 1)
            {
                updownracer.Value = gamblers[0].bet.racernum;
                updownracer.Enabled = false; // you can't change your racer
            }
            else
            {
                updownracer.Enabled = true;
            }


            betbutton.Enabled = false;
            racerbutton.Enabled = true;
            checknameinfo.Visible = true;
            checkcashinfo.Visible = true;
            totalearninfo.Visible = true;
            checknameinfo.Text = gamblers[0].name;
            checkcashinfo.Text = Convert.ToString(gamblers[0].balance);
            if (gamblers[0].bet.totalwin < 0)
            {
                total.Text = "Total losses are:";
            }
            else if (gamblers[0].bet.totalwin >= 0)
            {
                total.Text = "Total earning is :";
            }
            totalearninfo.Text = Convert.ToString(gamblers[0].bet.totalwin);       
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void bettor2_CheckedChanged(object sender, EventArgs e)
        {
            gamblers[1].bet.Yourbet();
            if (notchangeuser2 == 1)
            {
                updownracer.Value = gamblers[1].bet.racernum;
                updownracer.Enabled = false;// you can't change your racer
            }
            else
            {
                updownracer.Enabled = true;
            }

            betbutton.Enabled = false;
            racerbutton.Enabled = true;
            checknameinfo.Visible = true;
            checkcashinfo.Visible = true;
            totalearninfo.Visible = true;
            checknameinfo.Text = gamblers[1].name;
            checkcashinfo.Text = Convert.ToString(gamblers[1].balance);
            if (gamblers[1].bet.totalwin < 0)
            {
                total.Text = "Total losses are:";
            }
            else if (gamblers[1].bet.totalwin >= 0)
            {
                total.Text = "Total earning is :";
            }
            totalearninfo.Text = Convert.ToString(gamblers[1].bet.totalwin);
        }

        private void bettor3_CheckedChanged(object sender, EventArgs e)
        {
            gamblers[2].bet.Yourbet();
            if (notchangeuser3 == 1)
            {
                updownracer.Value = gamblers[2].bet.racernum;
                updownracer.Enabled = false;// you can't change your racer

            }
            else
            {
                updownracer.Enabled = true;
            }
 
            betbutton.Enabled = false;
            racerbutton.Enabled = true;
            checknameinfo.Visible = true;
            checkcashinfo.Visible = true;
            totalearninfo.Visible = true;
            checknameinfo.Text = gamblers[2].name;
            checkcashinfo.Text = Convert.ToString(gamblers[2].balance);
            if (gamblers[2].bet.totalwin < 0)
            {
                total.Text = "Total losses are:";
            }
            else if (gamblers[2].bet.totalwin >= 0)
            {
                total.Text = "Total earning is :";
            }
            totalearninfo.Text = Convert.ToString(gamblers[2].bet.totalwin);
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void racerbutton_Click(object sender, EventArgs e)
        {
           
            

            betbutton.Enabled = true;
            if (gambler1.Checked)
            {
                notchangeuser1 = 1;
                gamblers[0].bet.racernum = Convert.ToInt32(updownracer.Value);
            }
            else if (gambler2.Checked)
            {
                notchangeuser2 = 1;
                gamblers[1].bet.racernum = Convert.ToInt32(updownracer.Value);
            }
            else if (gambler3.Checked)
            {
                notchangeuser3 = 1;
                gamblers[2].bet.racernum = Convert.ToInt32(updownracer.Value);
            }

        }

        private void betbutton_Click(object sender, EventArgs e)
        {
            updownracer.Enabled = false;
            racerbutton.Enabled = false;
            int updownbetkeeper = Convert.ToInt32(updownbet.Value);
            if (updownbetkeeper>=0)
            {
                if (gambler1.Checked)
            {
                    
                    if (gamblers[0].balance >=gamblers[0].bet.amount+ updownbet.Value)
                {
                    gamblers[0].bet.amount += Convert.ToInt32(updownbet.Value);
                        gamblers[0].bet.Yourbet();
                    }
                else
                {
                    MessageBox.Show("You don't have enough to match the bet.");
                }

            }
                if (gambler2.Checked)
                {
                    
                    if (gamblers[1].balance >= gamblers[1].bet.amount + updownbet.Value)
                    {
                        gamblers[1].bet.amount += Convert.ToInt32(updownbet.Value);
                        gamblers[1].bet.Yourbet();
                    }
                    else
                    {
                        MessageBox.Show("You don't have enough to match the bet.");
                    }
                }
                if (gambler3.Checked)
                {
                    
                    if (gamblers[2].balance >= gamblers[2].bet.amount + updownbet.Value)
                    {
                        gamblers[2].bet.amount += Convert.ToInt32(updownbet.Value);
                        gamblers[2].bet.Yourbet();
                    }
                    else
                    {
                        MessageBox.Show("You don't have enough to match the bet.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid response. Please enter an integer between 0 and 1000");
            }  
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void checkcash_Click(object sender, EventArgs e)
        {

        }
    }
}



