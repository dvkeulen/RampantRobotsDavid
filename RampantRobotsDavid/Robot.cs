using System;
namespace RampantRobotsDavid
{
    public class Robot : Walker
    {
        Random rnd = new Random();
        public (int, int) location;

        // Deze functie geeft een robot een willekeurige locatie op het bord
        public Robot(int width, int height)
        {
            location = (rnd.Next(0, height), rnd.Next(0, width-1));
        }

        // Deze functie verplaatst de robot een willekeurig aantal stappen (tussen 1 en 3) in een willekeurige richting
        // Voor de robots gedraagt het veld zich als een torus.
        public void walk(int width, int height)
        {
            int a = rnd.Next(0, 2);
            this.location.Item1 = (this.location.Item1 + a * rnd.Next(1, 3)) % height;
            this.location.Item2 = (this.location.Item2 + (1-a) * rnd.Next(1, 3)) % (width-1);
        }

    }

}
