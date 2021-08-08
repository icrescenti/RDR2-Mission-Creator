using RDR2;
using RDR2.Math;
using RDR2.Native;

namespace RDR2_Mission_Creator
{
    public class PedsFunctions : Script
    {
        #region clear all peds

        public static void clearpeds()
        {
            foreach (Ped p in RDR2.World.GetAllPeds())
            {
                if (!p.IsPlayer)
                    p.Delete();
            }
            foreach (Vehicle v in RDR2.World.GetAllVehicles())
            {
                v.Delete();
            }
        }

        public static void clearpeds(Ped[] peds)
        {
            foreach (Ped p in peds)
            {
                if (!p.IsPlayer)
                    p.Delete();
            }
        }

        #endregion

        #region ped creation and attributes

        #region create

        public static Ped createped(
            string modelName = "player_zero",
            Vector3 pos = default,
            string type = "enemy",
            string name = "Stranger",
            bool isInmortal = false,
            int accuracy = 50,
            int heading = 0,
            int maxHealth = 100,
            int health = 100,
            string task = "defend",
            objects.weapon[] weapons = null,
            int outfit = 0
        )
        {
            Model m = new Model(modelName);
            Ped dynPed = RDR2.World.CreatePed(m, pos, heading, false, false);
            dynPed.SetPedPromptName(name);
            dynPed.IsInvincible = isInmortal;
            dynPed.Accuracy = accuracy;
            dynPed.MaxHealth = maxHealth;
            dynPed.Health = health;
            dynPed.Outfit = outfit;

            if (weapons != null)
                foreach (objects.weapon wp in weapons)
                {
                    dynPed.Weapons.Give(wp.weapon_hash, wp.ammo, wp.equip, wp.isAmmoLoaded);
                    dynPed.Weapons.Give(wp.weapon_hash, wp.ammo, wp.equip, wp.isAmmoLoaded);
                }

            if (type == "enemy")
                enemyPed(dynPed, name, task);
            else if (type == "companion")
                companionPed(dynPed, name, task);

            return dynPed;
        }

        #endregion

        #region enemy

        public static void enemyPed(Ped ped, string name, string task)
        {
            //Function.Call(Hash.SET_PED_AS_GROUP_LEADER, ped, Function.Call<int>(Hash.GET_PED_GROUP_INDEX, ped), true);

            Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, ped, 0, 0);
            Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, ped, true, true);
            Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, ped, 1269650476);

            ped.AddBlip(BlipType.BLIP_STYLE_ENEMY);
            ped.CurrentBlip.Label = name;

            assignTask(ped, task);
        }

        #endregion

        #region companion

        public static void companionPed(Ped ped, string name, string task)
        {
            Function.Call(Hash.SET_PED_AS_GROUP_LEADER, Game.Player.Character, Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character.Handle), true);

            //Function.Call(Hash.TASK_PERSISTENT_CHARACTER, ped);
            Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, ped, 0xA448EF1C);
            Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, ped, Function.Call<int>(Hash.GET_PED_GROUP_INDEX, Game.Player.Character.Handle));

            ped.AddBlip(BlipType.CompanionGray);
            ped.CurrentBlip.Label = name;

            assignTask(ped, task);
        }

        #endregion

        #region task

        private static void assignTask(Ped ped, string task)
        {
            Function.Call(Hash.SET_PED_SEEING_RANGE, ped, 9000.0f);
            Function.Call(Hash.SET_PED_SEEING_RANGE, ped, 9000.0f);
            Function.Call(Hash.SET_PED_VISUAL_FIELD_PERIPHERAL_RANGE, ped, 9000.0f);
            Function.Call(Hash.SET_PED_VISUAL_FIELD_PERIPHERAL_RANGE, ped, 9000.0f);

            if (task == "sniper_cover")
            {
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, ped, 0);
            }
            else if (task == "defend")
            {
                //(Crash)Function.Call(Hash.SET_PED_COMBAT_RANGE, ped, 9000.0f);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, ped, 1);
                Function.Call(Hash.SET_PED_COMBAT_ATTRIBUTES, ped, 71, true);
            }
        }

        #endregion

        #region components

        public static void addComponent(Ped ped, uint componentHash, bool multiplayer = false)
        {
            Function.Call(Hash._SET_PED_COMPONENT_ENABLED, ped, componentHash, true, multiplayer, false);
            Function.Call(Hash._0x66B957AAC2EAAEAB, ped, componentHash, 0, true, multiplayer, false);
        }

        #endregion

        #endregion

        public static void disableAmbientPeds()
        {
            //TO-DO
            Logic.stopScript(new string[]{
                "talltrees_population",
                "scarlettmeadows_population",
                "roanokeridge_population",
                "riobravo_population",
                "hennigansstead_population",
                "heartland_population",
                "guama_population",
                "grizzlieswest_population",
                "grizzlieseast_population",
                "grizzlies_population",
                "greatplains_population",
                "gaptoothridge_population",
                "cumberlandforest_population",
                "chollasprings_population",
                "bluegillmarsh_population",
                "bigvalley_population",
                "bayounwa_population"
            });
            RDR2.UI.Screen.ShowSubtitle("no npc");

            Function.Call(Hash.SET_CREATE_RANDOM_COPS, false);

            foreach (Ped p in RDR2.World.GetAllPeds())
            {
                if (!p.IsPlayer)
                {
                    Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, p, true, true);
                    Function.Call(Hash.DELETE_PED, p);
                }
            }
        }
    }
}
