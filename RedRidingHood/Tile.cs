using System;
using System.Collections.Generic;

namespace RedRidingHood
{
    internal class Tile
    {
        private int xCoordinate;
        private int yCoordinate;
        static public List<Tile> tilesList = new List<Tile>();

        public Tile(int xCoordinate, int yCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            tilesList.Add(this);
        }

        public int XCoordinate
        {
            get => xCoordinate;
            set
            {
                if (value > GameBoard.gameBoard)
                {
                    throw new Exception("Coordinate must be in range of the GameBoard.");
                }
                xCoordinate = value;
            }
        }

        public int YCoordinate
        {
            get => yCoordinate;
            set
            {
                if (value > GameBoard.gameBoard)
                {
                    throw new Exception("Coordinate must be in range of the GameBoard.");
                }
                yCoordinate = value;
            }
        }

        /// <summary>
        /// Asks question and returns Number of presents to substract according to answer (0 or 1).
        /// </summary>
        public virtual int Action()
        {
            return -2;
        }

        public override string ToString()
        {
            return "#";
        }
    }
}