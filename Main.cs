using RDR2;
using System;

namespace RDR2_Mission_Creator
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
            //EXAMPLE
            //LevelManager.Load("red_dead_redemption");
        }

    }
}
