using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakaIki
{
    public class Robot
    {
        private readonly int maxX;     
        private readonly int maxY;
        private readonly int fullRoundLength; 

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
            maxX = width < 2 ? 1 : ( width - 1 ) ;
            maxY = height > 100 ? 99 : (height - 1);
            fullRoundLength = (maxX + maxY) * 2;
        }

        public void Step(int num)
        {
            if (num == 0) return;
            if (num > 1000) num = 1000;

            currentLocation += num;
            currentLocation %= fullRoundLength;

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
            else if (currentLocation <= maxX)
            {
                direction = Direction.East;
                currentX = currentLocation;
                currentY = 0;
            }
            else if (currentLocation <= maxX + maxY)
            {
                direction = Direction.North;
                currentX = maxX;
                currentY = currentLocation - maxX;
            }
            else if (currentLocation <= maxX + maxY + maxX)
            {
                direction = Direction.West;
                currentX = maxX - (currentLocation - maxX - maxY);
                currentY = maxY;
            }
            else
            {
                direction = Direction.South;
                currentX = 0;
                currentY = maxY - (currentLocation - maxX - maxY - maxX);
            }
        }
    }
}
