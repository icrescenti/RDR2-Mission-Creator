using RDR2;
using RDR2.Math;
using RDR2_Mission_Creator.objects;
using System;
using System.IO;
using System.Xml.Serialization;

namespace RDR2_Mission_Creator
{
    class Execution
    {
        public static void loadLevel(string name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Level));
            Level lvl;

            using (Stream reader = new FileStream(Environment.CurrentDirectory + "/scripts/levels/" + name + ".xml", FileMode.Open))
            {
                lvl = (Level)serializer.Deserialize(reader);
                reader.Close();
            }

            foreach (entity e in lvl.entities)
            {
                foreach (instance ins in e.instances)
                {
                    Vector3 pos = new Vector3(ins.x, ins.y, ins.z);
                    Ped ped = PedsFunctions.createped(e.model_name, pos, e.type, e.name, e.isInmortal, e.accuracy, ins.heading, e.health, e.maxHealth, e.task, e.weapons, e.outfit);
                }
            }
        }
    }
}
