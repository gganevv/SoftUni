using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';
        private Queue<Point> snakeElements;
        private Food[] food;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            food = new Food[3];
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateSnake();
        }
        private int RandomFoodNumber => new Random().Next(0, food.Length);

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

            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (food[foodIndex].IsFoodpoint(snakeNewHead))
            {
                Eat(direction, currentSnakeHead);
            }

            foodIndex = RandomFoodNumber;
            food[foodIndex].SetRandomPosition(snakeElements);

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = food[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }
        }
    }
}