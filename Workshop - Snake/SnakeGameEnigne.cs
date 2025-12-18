using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop___Snake.Contracts;

namespace Workshop___Snake
{
    public class SnakeGameEnigne
    {
        private const int InitialGameSpeed = 120;

        private const int PlayAreaWidth = 51;
        private const int PlayAreaHeigth = 50;

        private const int SnakeStarHeadLeft = 7;
        private const int SnakeStarHeadTop = 1;
        private const int SnakeStartLenght = 6;

        private ISnakeRenderer renderer;
        private IRandomGenerator randomGenerator;
        private ISnakeGameInput input;

        private Snake snake;
        private Point avaiableFood;

        private int gameSpeed;

        public SnakeGameEnigne(ISnakeRenderer renderer, ISnakeGameInput input, IRandomGenerator randomGenerator)
        {
            this.renderer = renderer;
            this.input = input;
            this.randomGenerator = randomGenerator;

        }

        public void Run()
        {
            this.IntialnizeGame();
            this.gameSpeed = InitialGameSpeed;

            while (true)
            {
                Thread.Sleep(this.gameSpeed);

                var inputDirection = this.input.CheckForInput();
                if (inputDirection != null)
                {
                    this.snake.ChangeDireciton(inputDirection.Value);
                }

                var removedPoint = this.snake.Move();

                if (IsSnakeDead())
                {
                    this.renderer.RenderGameOver();

                    if (this.input.WaitForRestart())
                    {
                        this.Run();
                    }

                    return;
                }
                this.CheckForFood();
                this.renderer.RenderSnake(this.snake, removedPoint);
            }
        }


        public void IntialnizeGame()
        {
            this.snake = new Snake(SnakeStarHeadLeft, SnakeStarHeadTop, SnakeStartLenght);
            this.renderer.Intialieze(PlayAreaWidth, PlayAreaHeigth);
            this.renderer.RenderWall(PlayAreaWidth, PlayAreaHeigth);

            this.renderer.RenderSnake(this.snake);
            this.GenerateNewFood();

            this.renderer.RenderFood(this.avaiableFood);
        }

        private void GenerateNewFood()
        {
            while (true)
            {

                bool isValidFood = true;

                var foodLeft = this.randomGenerator.NextNumber(1, PlayAreaWidth - 1);
                var foodTop = this.randomGenerator.NextNumber(1, PlayAreaHeigth - 1);

                if (foodLeft % 2 == 0)
                {
                    foodLeft++;
                }

                foreach (var point in this.snake.Body)
                {
                    if (point.Left == foodLeft && point.Top == foodTop)
                    {
                        isValidFood = false;
                        break;
                    }
                }

                if (isValidFood)
                {
                    this.avaiableFood = new Point(foodLeft, foodTop);
                    break;
                }
            }
        }

        private bool IsSnakeDead()
        {
            var head = this.snake.Head;

            if (head.Left <= 0 || head.Left >= PlayAreaWidth - 1 ||
                head.Top <= 0 || head.Top >= PlayAreaHeigth - 1)
            {
                return true;
            }

            foreach (var part in this.snake.Body)
            {
                if (part != head &&
                    part.Left == head.Left &&
                    part.Top == head.Top)
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckForFood()
        {
            var head = this.snake.Head;

            if (this.avaiableFood.Left == head.Left && this.avaiableFood.Top == head.Top)
            {
                this.snake.IncreaseLength();
                this.gameSpeed -= 5;

                this.GenerateNewFood();
                this.renderer.RenderFood(this.avaiableFood);
            }
        }


    }
}
