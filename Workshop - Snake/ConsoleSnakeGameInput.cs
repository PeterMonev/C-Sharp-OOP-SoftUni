using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop___Snake.Contracts;

namespace Workshop___Snake
{
    public class ConsoleSnakeGameInput : ISnakeGameInput
    {
        public Direction? CheckForInput()
        {
            if (!Console.KeyAvailable)
            {
                return null;
            }

            var kefInfo = Console.ReadKey();

            if (kefInfo.Key == ConsoleKey.LeftArrow)
            {
                return Direction.Left;
            }
            else if (kefInfo.Key == ConsoleKey.RightArrow)
            {
                return Direction.Right;
            }
            else if (kefInfo.Key == ConsoleKey.UpArrow)
            {
                return Direction.Top;
            }
            else if (kefInfo.Key == ConsoleKey.DownArrow)
            {
                return Direction.Bottom;
            }

            return null;
        }

        public bool WaitForRestart()
        {
            while (true)
            {
                var key = Console.ReadKey();
                if(key.Key == ConsoleKey.Enter)
                {
                    return true;
                }
            }
        }
    }
}
