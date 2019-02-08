using System;
using System.Collections.Generic;

namespace RampantRobotsDavid
{
    class Program
    {
        static void Main(string[] args)
        {   // geef de input als: Factory(width, height, robots, turns, robotsMove)
            // Zorg dat het aantal robots niet meer is dan de oppervlakte van het speelveld min 1
            Factory factory = new Factory(8, 8, 8, 30, true);
            factory.Run();
        }
    }
}