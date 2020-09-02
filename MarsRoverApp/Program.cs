using MarsRoverApp.Entities;
using MarsRoverApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ILandingSurface landingSurface = new Plateau("5 5");
            RoverSquad roverSquad = new RoverSquad(landingSurface);

            roverSquad.DeployNewRover("1 2 N", "LMLMLMLMM");
            roverSquad.DeployNewRover("3 3 E", "MMRMMRMRRM");
                      

            foreach(var rover in roverSquad)
            {
                Console.WriteLine("{0} {1} {2}", rover.XCoordinate, rover.YCoordinate, rover.DirectionFacing);
            }
            Console.ReadLine();




        }
    }
}
