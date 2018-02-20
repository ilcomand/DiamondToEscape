namespace CatchTheGold.Core
{
    public class GameLogic
    {
        static public int ExitX { get; private set; }
        static public int ExitY { get; private set; }

        public GameLogic()
        {
            ExitX = 5;
            ExitY = -1;
        }

        public bool CheckPower(FieldElement[,] field, int x, int y, int power)
        {
            if (field[x, y] == FieldElement.Diamond)
            {
                field[x, y] = FieldElement.Empty;
                Eroe.ModPower();
                return true;
            }

            else return false;
        }

        public static bool HasPowerToWin(int power)
        {
            if (power == 50) return true;
            else return false;
        }

        public static bool IsWinPosition(int EroeX, int EroeY)
        {
            if ((EroeX == ExitX) && (EroeY == ExitY + 1)) return true;
            else return false;
        }

        public bool YouWin(int EroeX, int EroeY)
        {
            if (EroeX == ExitX && EroeY == ExitY) return true;
            else return false;
        }

        public bool YouLose(int NemicoX, int NemicoY, int EroeX, int EroeY)
        {
            if ((NemicoX == EroeX) && (NemicoY == EroeY)) return true;
            else return false;
        }
    }
}
