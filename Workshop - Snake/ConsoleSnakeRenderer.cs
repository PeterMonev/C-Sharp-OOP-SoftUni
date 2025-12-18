using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop___Snake.Contracts;

namespace Workshop___Snake
{
    using System;
    public class ConsoleSnakeRenderer : ISnakeRenderer
    {
        private const char SnakeSymbol = '*';
        private const char HorizontalWallSymbol = '-';
        private const char VerticalWallSymbol = '|';
        private const char FoodSymbol = '@';

        private int maxWidth;
        private int maxHeight;
        public void Intialieze(int maxWidth, int maxHeight)
        {
            Console.CursorVisible = false;
            Console.Clear();

            if (Console.WindowWidth > maxWidth || Console.WindowHeight > maxHeight)
            {
                Console.SetWindowSize(
                    Math.Min(Console.WindowWidth, maxWidth),
                    Math.Min(Console.WindowHeight, maxHeight)
                );
            }

            Console.SetBufferSize(maxWidth, maxHeight);

            Console.SetWindowSize(maxWidth, maxHeight);

            Console.CursorVisible = false;

            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
        }

        public void RenderFood(Point food)
        {
            Console.SetCursorPosition(food.Left, food.Top);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(FoodSymbol);
        }

        public void RenderGameOver()
        {
            Console.SetCursorPosition(this.maxWidth / 2 - 5, this.maxHeight / 2 - 2);
            Console.Write("GAME OVER!");
            Console.SetCursorPosition(this.maxWidth / 2 - 13, this.maxHeight / 2 - 3);
            Console.Write("Press 'Enter to restart...");
        }

        public void RenderSnake(Snake snake, Point toRemove = null)
        {
            if (toRemove != null)
            {
                Console.SetCursorPosition(toRemove.Left, toRemove.Top);
                Console.Write(' ');
            }

            foreach (var point in snake.Body)
            {
               
                Console.SetCursorPosition(point.Left, point.Top);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(SnakeSymbol);
            }
        }

        public void RenderWall(int maxWidth, int maxHeigth)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Top Wall
            for (int i = 0; i < maxWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(HorizontalWallSymbol);
            }

            //Bottom Wall
            for (int i = 0; i < maxHeigth - 1; i++)
            {
                Console.SetCursorPosition(i, maxHeigth - 1);
                Console.Write(HorizontalWallSymbol);
            }

            //Left Wall
            for (int i = 0; i < maxHeigth - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(VerticalWallSymbol);
            }

            //Rigth Wall
            for (int i = 0; i < maxHeigth; i++)
            {
                Console.SetCursorPosition(maxWidth - 1, i);
                Console.Write(VerticalWallSymbol);
            }


        }


    }
}
