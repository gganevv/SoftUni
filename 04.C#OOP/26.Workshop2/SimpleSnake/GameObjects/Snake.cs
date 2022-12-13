using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private Queue<Point> snakeElements;
        private List<Food> food;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;

        public Snake(Wall wall)
        {
            snakeElements = new Queue<Point>();
            food = new List<Food>(3);
            this.wall = wall;
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            food[0] = new FoodHash(wall);
            food[1] = new FoodDollar(wall);
            food[2] = new FoodAsterisk(wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();
            
            GetNextPoint(direction, currentSnakeHead);
            
            bool isPointOfSnake = snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
            
            if (isPointOfSnake)
            {
                return false;
            }
            
            Point snakeNewHead = new Point(nextLeftX, nextTopY);
            
            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            return true;
        }
    }
}