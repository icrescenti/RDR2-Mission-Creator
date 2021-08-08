using RDR2;
using System;
using RDR2_Mission_Creator;

namespace MySampleMod
{
    class Main : Script
    {
        public Main()
        {
            Tick += OnTick;
            Interval = 1;
        }

        private void OnTick(object sender, EventArgs e)
        {
            //EXAMPLE IN PSEUDOCODE

            /*
             
            if (game is loaded)
                LevelManager.Load("red_dead_redemption");
            
            if (level has ended)
                LevelManager.Load("finale1");

            etc...

             */
        }

    }
}
