using System;

namespace RedRidingHood
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int GameBoardSize = GameBoard.gameBoard;
            bool gameEnded = false;
            Player player = new Player();
            Random rnd = new Random();

            //generate tiles
            new Home();
            //-1 so it includes zeroth element
            GrandmasHome grandmasHome = new GrandmasHome(GameBoardSize - 1, GameBoardSize - 1);
            new ViewPoint(rnd.Next(0, GameBoardSize), rnd.Next(0, GameBoardSize));
            new Teleport(rnd.Next(0, GameBoardSize), rnd.Next(0, GameBoardSize));
            new Field(rnd.Next(0, GameBoardSize), rnd.Next(0, GameBoardSize));

            for (int i = 0; i < GameBoardSize * GameBoardSize / 2; i++)
            {
                //max value is exclusive so its okay here
                new Obstacle(rnd.Next(0, GameBoardSize), rnd.Next(0, GameBoardSize));
            }
            //generate tile for every possible location, which makes duplicates in the list if there is already home, obstacle etc.
            //currently does not matter because we always get the first element
            //TODO delete duplicates
            for (int i = 0; i < GameBoardSize; i++)
            {
                for (int j = 0; j < GameBoardSize; j++)
                {
                    new Tile(i, j);
                }
            }

            //game loop
            while (!gameEnded)
            {
                //prints the gameboard
                Console.Write(GameBoard.toString() + "\n");

                //find the first tile corresponding with player position
                for (int i = 0; i < Tile.tilesList.Count; i++)
                {
                    if (Tile.tilesList[i].XCoordinate == player.XCoordinate && Tile.tilesList[i].YCoordinate == player.YCoordinate)
                    {
                        //starts the action of the tile
                        int actionReturned = Tile.tilesList[i].Action();
                        //exit if VIEWPOINT, HOME or GRANDMA
                        if (actionReturned == -1)
                        {
                            break;
                        }
                        //exit if question and subtract 0 or 1 from presents according to users answer
                        if (actionReturned == 0 || actionReturned == 1)
                        {
                            player.presents -= actionReturned;
                            break;
                        }
                        //TODO breaks everything
                        //exit if TELEPORT and teleports player obviously
                        /*if (actionReturned == -2)
                        {
                            player.XCoordinate = rnd.Next(0, GameBoardSize);
                            player.YCoordinate = rnd.Next(0, GameBoardSize);
                            break;
                        }*/
                        //exit if FIELD, also restores presents
                        if (actionReturned == -3)
                        {
                            player.presents = 2;
                            break;
                        }
                        //continue if tile empty, because there may be tile with same coordinates which is not empty
                    }
                }
                Console.WriteLine();
                //end game if 0 present
                if (player.presents == 0)
                {
                    gameEnded = true;
                    Console.WriteLine("GameOver!");
                    Console.ReadKey();
                    break;
                }
                if (grandmasHome.XCoordinate == player.XCoordinate && grandmasHome.YCoordinate == player.YCoordinate)
                {
                    gameEnded = true;
                    Console.WriteLine("YOU WON!");
                    Console.ReadKey();
                    break;
                }

                //player moves
                char keyPressed = 'N';
                bool oneChar = false;
                while (!oneChar)
                {
                    Console.WriteLine("Direction which you want to go: (W/A/S/D)");
                    string key = Console.ReadLine().ToLower();
                    //check correct input
                    if (key == "w" || key == "a" || key == "s" || key == "d")
                    {
                        //check not moving out of game board
                        if (key == "w" && player.YCoordinate != 0 || key == "a" && player.XCoordinate != 0 ||
                            key == "s" && player.YCoordinate != GameBoardSize - 1 || key == "d" && player.XCoordinate != GameBoardSize - 1)
                        {
                            keyPressed = Convert.ToChar(key);
                            oneChar = true;
                        }
                    }
                }

                //the actual moving
                switch (keyPressed)
                {
                    case 'w':
                        player.YCoordinate -= 1;
                        break;

                    case 'a':
                        player.XCoordinate -= 1;
                        break;

                    case 's':
                        player.YCoordinate += 1;
                        break;

                    case 'd':
                        player.XCoordinate += 1;
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}