using MarsRoverApp;
using MarsRoverApp.Entities;
using MarsRoverApp.Interfaces;
using Xunit;

namespace MarsRoverAppTest
{
    public class MarsRoverTest
    {
        [Fact]
        public void DeployRoversTest()
        {
            ILandingSurface landingSurface = new Plateau("5 5");
            RoverSquad roverSquad = new RoverSquad(landingSurface);

            roverSquad.DeployNewRover("1 2 N", "LMLMLMLMM");
            roverSquad.DeployNewRover("3 3 E", "MMRMMRMRRM");

            int noRovers = 2;
            int roverOneIdx = 0;
            int roverTwoIdx = 1;

            Assert.True(roverSquad.Count == noRovers);

            IRover roverOne = roverSquad[roverOneIdx];
            IRover roverTwo = roverSquad[roverTwoIdx];

            Assert.NotNull(roverOne);
            Assert.NotNull(roverTwo);
        }

        [Fact]
        public void DeployRoversAndTestCoordinates()
        {
            ILandingSurface landingSurface = new Plateau("5 5");
            RoverSquad roverSquad = new RoverSquad(landingSurface);

            roverSquad.DeployNewRover("1 2 N", "LMLMLMLMM");
            roverSquad.DeployNewRover("3 3 E", "MMRMMRMRRM");

            int roverOneIdx = 0;
            int roverTwoIdx = 1;

            IRover roverOne = roverSquad[roverOneIdx];
            IRover roverTwo = roverSquad[roverTwoIdx];

            Assert.True(roverOne.XCoordinate == 1, "RoverOne: X != 1");
            Assert.True(roverOne.YCoordinate == 3, "RoverOne: Y != 3");
            Assert.True(roverOne.DirectionFacing == "N", "RoverOne: Direction != North");

            Assert.True(roverTwo.XCoordinate == 5, "RoverTwo: X != 5");
            Assert.True(roverTwo.YCoordinate == 1, "RoverTwo: Y != 1");
            Assert.True(roverTwo.DirectionFacing == "E", "RoverTwo: Direction != East");
        }

    }
}
