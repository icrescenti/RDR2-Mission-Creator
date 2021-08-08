namespace RDR2_Mission_Creator.objects
{
    public class instance
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public int heading { get; set; }

        public instance()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.heading = 0;
        }
    }
}
