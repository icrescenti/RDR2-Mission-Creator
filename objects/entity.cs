namespace RDR2_Mission_Creator.objects
{
    public class entity
    {
        public string model_name { get; set; }
        public instance[] instances { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public bool isInmortal { get; set; }
        public int accuracy { get; set; }
        public int health { get; set; }
        public int maxHealth { get; set; }
        public string task { get; set; }
        public weapon[] weapons { get; set; }
        public int outfit { get; set; }

        public entity()
        {
            this.model_name = "player_zero";
            this.instances = new instance[1];
            this.type = "enemy";
            this.name = "Stranger";
            this.isInmortal = false;
            this.accuracy = 50;
            this.health = 100;
            this.maxHealth = 100;
            this.task = "defend";
            this.outfit = 0;
        }
    }
}
