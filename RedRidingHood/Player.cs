namespace RedRidingHood
{
    internal class Player : Tile
    {
        public int presents;

        public Player(int xCoordinate = 0, int yCoordinate = 0, int presents = 2)
            : base(xCoordinate, yCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.presents = presents;
        }

        public override string ToString()
        {
            return "PLAYER";
        }
    }
}