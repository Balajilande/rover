using MarsRoverApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverApp.Entities
{
    public class Rover : IRover
    {
        public Rover(List<IRover> squad, ILandingSurface landingSurface, string roverPosition, string roverCommands)
        {
            this.Squad = squad;

            this.TranslateRoverPosition(roverPosition);

            if (!RoverIsWithinLandingCoordinates(landingSurface))
                return;

            this.TranslateRoverCommands(roverCommands);
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string DirectionFacing { get; set; }
        public List<IRover> Squad { get; set; }

        private static readonly char MessageSeperator = ' ';

        private void TranslateRoverPosition(string roverPosition)
        {
            string[] roverPositionMsgSplit = roverPosition.Split(Rover.MessageSeperator);

            int xCoordinateIdx = 0;
            int yCoordinateIdx = 1;
            int facingDirectionIdx = 2;

            this.XCoordinate = Convert.ToInt32(roverPositionMsgSplit[xCoordinateIdx]);
            this.YCoordinate = Convert.ToInt32(roverPositionMsgSplit[yCoordinateIdx]);
            this.DirectionFacing = roverPositionMsgSplit[facingDirectionIdx];
        }

       private void TranslateRoverCommands(string roverCommands)
        {
            char[] commands = roverCommands.ToCharArray();

            foreach (char command in commands)
            {
                switch(command.ToString())
                {
                    case RoverCommands.MoveForward:
                        this.MoveRoverForward();
                        break;

                    default:
                        this.RotateRover(command.ToString());
                        break;
                }
            }
        }

        private bool RoverIsWithinLandingCoordinates(ILandingSurface landingSurface)
        {
            return (this.XCoordinate >= 0) && (this.XCoordinate < landingSurface.Width) &&
                (this.YCoordinate >= 0) && (this.YCoordinate < landingSurface.Height);
        }

        public void MoveRoverForward()
        {
            switch (this.DirectionFacing)
            {
                case Direction.North:
                    this.YCoordinate += 1;
                    break;

                case Direction.East:
                    this.XCoordinate += 1;
                    break;

                case Direction.South:
                    this.YCoordinate -= 1;
                    break;

                case Direction.West:
                    this.XCoordinate -= 1;
                    break;
            }
        }

        public void RotateRover(string directionCommand)
        {
            switch (directionCommand.ToUpper())
            {
                case RoverCommands.RotateLeft:
                    this.TurnRoverLeft();
                    break;

                case RoverCommands.RotateRight:
                    this.TurnRoverRight();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

       

        private void TurnRoverLeft()
        {
            switch (this.DirectionFacing)
            {
                case Direction.North:
                    this.DirectionFacing = Direction.West;
                    break;

                case Direction.West:
                    this.DirectionFacing = Direction.South;
                    break;

                case Direction.South:
                    this.DirectionFacing = Direction.East;
                    break;

                case Direction.East:
                    this.DirectionFacing = Direction.North;
                    break;
            }
        }

        private void TurnRoverRight()
        {
            switch (this.DirectionFacing)
            {
                case Direction.North:
                    this.DirectionFacing = Direction.East;
                    break;

                case Direction.East:
                    this.DirectionFacing = Direction.South;
                    break;

                case Direction.South:
                    this.DirectionFacing = Direction.West;
                    break;

                case Direction.West:
                    this.DirectionFacing = Direction.North;
                    break;
            }
        }
    }
}
