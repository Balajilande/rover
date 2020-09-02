using MarsRoverApp.Interfaces;
using System;

namespace MarsRoverApp.Entities
{
    public class Plateau : ILandingSurface
    {
        public Plateau(int xMaxCoordinate, int yMaxCoordinate)
        {
            this.Width = xMaxCoordinate;
            this.Height = yMaxCoordinate;
        }

        public Plateau(string plateauCoordinates)
        {
            if (string.IsNullOrEmpty(plateauCoordinates))
                throw new ArgumentException();

            this.SplitMessageCoordinates(plateauCoordinates);
        }

        public  int Width { get; private set; }
        public  int Height { get; private set; }

        private static readonly char MessageSeperator = ' ';

        private void SplitMessageCoordinates(string plateauCoordinates)
        {
            string[] coordinateMessage = plateauCoordinates.Split(Plateau.MessageSeperator);

            int noOfMsgValues = 2;
            int xCoordinateIdx = 0;
            int yCoordinateIdx = 1;

            if (coordinateMessage.Length != noOfMsgValues)
                throw new ArgumentOutOfRangeException();

            this.Width = Convert.ToInt32(coordinateMessage[xCoordinateIdx]);
            this.Height = Convert.ToInt32(coordinateMessage[yCoordinateIdx]);
        }
    }
}
