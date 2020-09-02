using MarsRoverApp.Entities;
using MarsRoverApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverApp
{
    public class RoverSquad : List<IRover>
    {
        public RoverSquad(ILandingSurface landingSurface) 
        {
            this.LandingSurface = landingSurface;
        }

        public ILandingSurface LandingSurface { get; private set; }

        public void DeployNewRover(string roverPosition, string roverCommands)
        {
            this.Add(new Rover(this, this.LandingSurface, roverPosition, roverCommands));
        }
    }
}
