using System;
namespace RampantRobotsDavid
{
    public class Mechanic : Walker
    {
        public (int, int) location;

        // De mechanic begint links bovenin het speelveld
        public Mechanic()
        {
            location = (0, 0);
        }

        // Deze functie zet de input van de speler om in de nieuwe locatie van de mechanic
        public void walk(int width, int height)
        {
            string move = Console.ReadLine();

            foreach (char c in move)
            {
                if (Equals(c, 'w'))
                {
                    if (this.location.Item1 != 0)
                    {
                        this.location.Item1 = (this.location.Item1 - 1);
                    }

                }
                if (Equals(c, 's'))
                {
                    if (this.location.Item1 != height - 1)
                    {
                        this.location.Item1 = (this.location.Item1 + 1);
                    }
                }
                if (Equals(c, 'a'))
                {
                    if (this.location.Item2 != 0)
                    {
                        this.location.Item2 = (this.location.Item2 - 1);
                    }
                }
                if (Equals(c, 'd'))
                {
                    if (this.location.Item2 != width - 2)
                    {
                        this.location.Item2 = (this.location.Item2 + 1);
                    }
                }
            }


        }
    }
}
