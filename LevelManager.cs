using RDR2;
using RDR2.Math;
using System;
using System.IO;

namespace RDR2_Mission_Creator
{
    public class LevelManager
    {
        static StreamReader sr = null;
        static Blip point;
        static Vector3 destination = default;
        static bool canContinue = true;

        public static void Load(string name)
        {
            if (sr == null)
                sr = new StreamReader(Environment.CurrentDirectory + "/scripts/missions/" + name + ".tkr");

            if (Game.Player.Character.Position.DistanceTo(destination) <= 0.5f && point.Exists())
            {
                point.Delete();
                canContinue = true;
            }

            if (canContinue)
                executeNextCommand();
        }

        public static void executeNextCommand()
        {
            if (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                string[] frags = line.Replace(" ", String.Empty).Split(',');

                if (frags[0] == "clear_peds")
                {
                    PedsFunctions.clearpeds();
                }
                else if (frags[0] == "destination_point")
                {
                    destination = new Vector3(
                        float.Parse(frags[2].Replace(".", ",")),
                        float.Parse(frags[3].Replace(".", ",")),
                        float.Parse(frags[4].Replace(".", ","))
                    );
                    point = MapFunctions.CreateBlip(destination, BlipType.BLIP_STYLE_TEMPORARY_HORSE, uint.Parse(frags[1]), frags[5], float.Parse(frags[6]), bool.Parse(frags[7]));
                    canContinue = false;
                }
                else if (frags[0] == "load_level")
                {
                    Execution.loadLevel(frags[1]);
                }
                else if (frags[0] == "show_subtitle")
                {
                    RDR2.UI.Screen.ShowSubtitle(frags[1].Replace("_", " "));
                }
                else if (frags[0] == "wait_everyone_dead")
                {

                }
            }
            else
            {
                sr.Close();
                canContinue = false;
            }
        }
    }
}