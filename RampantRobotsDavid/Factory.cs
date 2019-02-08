using System;
using System.Collections.Generic;

namespace RampantRobotsDavid
{
    public class Factory
    {
        public int fwidth;
        public int fheight;
        public int fturns;
        public bool frobotsMove;
        int turnCounter;
        public List<Robot> allRobots = new List<Robot>();
        public Mechanic Mech = new Mechanic();

        public Factory(int width,int height, int nrRobots, int turns, bool robotsMove)
        {
            // Benoem alle parameters van het spel
            fwidth = width+1;
            fheight = height;
            fturns = turns;
            frobotsMove = robotsMove;

            // Genereer een lijst met robots
            for (int i = 0; i < nrRobots; i++)
            {
                allRobots.Add(new Robot(fwidth,fheight));
            }

            // Verplaats robot's die op elkaar staan en teken het speelveld vervolgens
            int matchingRobots = 0;
            for (int i = 0; i < allRobots.Count; i++)
            {
                matchingRobots = 0;
                for (int j = 0; j < allRobots.Count; j++)
                {
                    if (allRobots[i].location.Item1 == allRobots[j].location.Item1 & allRobots[i].location.Item2 == allRobots[j].location.Item2)
                    {
                        matchingRobots = matchingRobots + 1;

                        if (matchingRobots > 1 || (allRobots[i].location.Item1 == Mech.location.Item1 && allRobots[i].location.Item2 == Mech.location.Item2))
                        {
                            allRobots[i].walk(fwidth, fheight);
                            matchingRobots = 0;
                            i = 0;
                            j = 0;
                        }
                    }
                }
            }

            draw(allRobots, Mech);
        }

        public void draw(List<Robot> allRobots, Mechanic Mech)
        {
            Console.Clear();
            // maak een matrix aan met punten
            string[,] board = new string[fheight, fwidth];
            for (int i = 0; i < fheight; i++)
            {
                for (int j = 0; j < fwidth; j++)
                {
                    board[i, j] = ".";
                }
                board[i, fwidth - 1] = Environment.NewLine;
            }

            // vervang de punten door robots
            foreach (Robot robot in allRobots)
            {
                board[robot.location.Item1, robot.location.Item2] = "r";
            }

            // vervang een punt door een mechanic
            board[Mech.location.Item1, Mech.location.Item2] = "m";

            // teken vervolgens het bord
            for (int i = 0; i < fheight; i++)
            {
                for (int j = 0; j < fwidth; j++)
                {
                    Console.Write(board[i, j]);
                }
            }
            // vraag de speler om input als het spel nog bezig is
            if (allRobots.Count > 0)
            {
                Console.Write("\nWhat moves should the mechanic make? (use wasd keys)\n");
                Console.Write(string.Format("\nYou have {0} turns left\n", fturns - turnCounter));
            }

        }

        public void Run()
        {
            turnCounter = 0;
            while (allRobots.Count > 0 && turnCounter < fturns)
            {
                Mech.walk(fwidth,fheight);

                // Stop het spel als de beurten om zijn
                turnCounter = turnCounter + 1;

                // als de speler het wil, laat dan alle robots lopen en verplaats ze als ze op elkaar eindigen
                if (frobotsMove == true)
                {

                    foreach (Robot robot in allRobots)
                    {
                        robot.walk(fwidth, fheight);
                    }

                    int matchingRobots = 0;
                    for (int i = 0; i < allRobots.Count; i++)
                    {
                        matchingRobots = 0;
                        for (int j = 0; j < allRobots.Count; j++)
                        {
                            if (allRobots[i].location.Item1 == allRobots[j].location.Item1 & allRobots[i].location.Item2 == allRobots[j].location.Item2)
                            {
                                matchingRobots = matchingRobots + 1;

                                if (matchingRobots > 1)
                                {
                                    allRobots[i].walk(fwidth, fheight);
                                    matchingRobots = 0;
                                    i = 0;
                                    j = 0;
                                    Console.WriteLine("Error: Robot's are on top of eachother");
                                }
                            }
                        }
                    }
                }

                // Als de locaties van een robot en de mechanic gelijk zijn, verwijder dan de robot uit het spel
                int n = 0;
                while (n < allRobots.Count)
                {
                    if(allRobots[n].location.Item1 == Mech.location.Item1 & allRobots[n].location.Item2 == Mech.location.Item2)
                    {
                        allRobots.Remove(allRobots[n]);
                        n = n - 1;
                    }
                    n = n + 1;
                }
                draw(allRobots, Mech);

            }

            // Meld de speler of zij gewonnen of verloren heeft
            if (allRobots.Count == 0)
            {
                Console.Write("Well done! You oiled all the robots!");
                Console.Read();
            }
            else
            {
                Console.Write("You ran out of oil before oiling all the robots, how sad");
                Console.Read();
            }
        }
    }
}