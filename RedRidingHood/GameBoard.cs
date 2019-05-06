namespace RedRidingHood
{
    internal static class GameBoard
    {
        //TODO let user change this value
        /// <summary>
        /// size of gameboard, always a square
        /// </summary>
        public static int gameBoard = 6;

        public static string toString()
        {
            string toPrint = "";
            //the row
            for (int i = 0; i < gameBoard; i++)
            {
                //the column
                for (int j = 0; j < gameBoard; j++)
                {
                    //all tiles in list, uses the first possible one then ends
                    for (int k = 0; k < Tile.tilesList.Count; k++)
                    {
                        if (i == Tile.tilesList[k].YCoordinate && j == Tile.tilesList[k].XCoordinate)
                        {
                            toPrint += Tile.tilesList[k].ToString() + "\t";
                            break;
                        }
                    }
                }
                toPrint += "\n";
            }

            return toPrint;
        }
    }
}