using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Proje
{
    class Racer
    {
        int WhoWin=0;// we can decide with this who first ended the race
        public int whowin
        { get { return WhoWin; } }
        int RaceArea;// it provide to place racearea proportions to racer class
        public int racearea//capsulation of racearea
        {
            get { return RaceArea; }
            set { RaceArea = value; }
        }
        int FirstPosition;// to reset of the racer place
        public int firstposition //capsulation of firstposition
        {
            get { return FirstPosition; }
            set { FirstPosition = value; }
        }
        PictureBox Racerpic; // to associate it with racer picture in main class
        public PictureBox racerpic
        {
         get {return this.Racerpic; }
         set { Racerpic = value; }
        }
        Random Rndm; //to associate it with random in main class
        public Random rndm
        {
            get { return Rndm; }
            set { Rndm = value; }
        }
        public bool Run() // to start competition
        {
            
            int keeprandom = rndm.Next(3,8);
            Point x = Racerpic.Location; // location of x,y plane
            
           
            if (x.X > racearea) //stop or continue
            {
                return true;// if all racers are true, race is done.
            } 
            else
            {
                WhoWin++;
                x.X += keeprandom;
                Racerpic.Location = x;
                return false;
            }

        }
        public int where()
        {
            Point x = Racerpic.Location;
            return x.X;
        }
        public void StartAgain() // to reset competition
        {
            
            Point x = Racerpic.Location;
            x.X = firstposition;
            Racerpic.Location = x ;
            WhoWin = 0;

        }
    }
}
