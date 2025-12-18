using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop___Snake.Contracts
{
    public interface ISnakeRenderer
    {
        void Intialieze(int maxWidth, int maxHeigth);

        void RenderWall(int maxWidth, int maxHeigth);

        void RenderSnake(Snake snake, Point toRemove = null);

        void RenderFood(Point food);

        void RenderGameOver();
    }
}
