using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakaIki
{
    public class Robot
    {
        private readonly int MaxX;     
        private readonly int MaxY;
        private readonly int FullRoundLength; 

        private int currentLocation = 0;
        private int currentX = 0;
        private int currentY = 0;

        private enum Direction
        {
            East = 0,
            North = 1,
            West = 2,
            South = 3,
        }

        private Direction direction = Direction.East;

        public Robot(int width, int height)
        {
            MaxX = width < 2 ? 1 : ( width - 1 ) ;
            MaxY = height > 100 ? 99 : (height - 1);
            FullRoundLength = (MaxX + MaxY) * 2;
        }

        public void Step(int num)
        {
            if (num == 0) return;
            if (num > 1000) num = 1000;

            currentLocation += num;
            currentLocation %= FullRoundLength;

            currentX = -1;
        }

        public int[] GetPos()
        {
            CalculatePositionAndDirection();
            return new[] { currentX, currentY };
        }

        public string GetDir()
        {
            CalculatePositionAndDirection();
            return direction.ToString();
        }

        private void CalculatePositionAndDirection()
        {
            if (currentX != -1) return;

            if (currentLocation == 0)
            {
                direction = Direction.South;
                currentX = currentY = 0;
            }
            else if (currentLocation <= MaxX)
            {
                direction = Direction.East;
                currentX = currentLocation;
                currentY = 0;
            }
            else if (currentLocation <= MaxX + MaxY)
            {
                direction = Direction.North;
                currentX = MaxX;
                currentY = currentLocation - MaxX;
            }
            else if (currentLocation <= MaxX + MaxY + MaxX)
            {
                direction = Direction.West;
                currentX = MaxX - (currentLocation - MaxX - MaxY);
                currentY = MaxY;
            }
            else
            {
                direction = Direction.South;
                currentX = 0;
                currentY = MaxY - (currentLocation - MaxX - MaxY - MaxX);
            }
        }
    }
}
