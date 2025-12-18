using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop___Snake
{
    public class Snake
    {
        public Snake(int startLeft, int startTop, int length)
        {
            if (startLeft - length < 1)
            {
                throw new InvalidOperationException("Snake initial position is outside the play area.");
            }

            this.Body = new Queue<Point>();
            this.Direction = Direction.Right;

            for (int i = startLeft - length + 1; i < startLeft; i++)
            {
                this.Body.Enqueue(new Point(i, startTop));
            }

            this.Head = new Point(startLeft, startTop);
            this.Body.Enqueue(this.Head);
        }



        public Point Head { get; private set; }
        public Queue<Point> Body { get; private set; }
        public Direction Direction { get; private set; }

        public Point Move()
        {
            var removedBodyPart = this.Body.Dequeue();

            this.SetNewHead();

            this.Body.Enqueue(this.Head);


            return removedBodyPart;
        }

        public void ChangeDireciton(Direction direction)
        {
            if (this.Direction == Direction.Left && direction == Direction.Right)
            {
                return;
            }

            if (this.Direction == Direction.Right && direction == Direction.Left)
            {
                return;
            }

            if (this.Direction == Direction.Top && direction == Direction.Bottom)
            {
                return;
            }

            if (this.Direction == Direction.Bottom && direction == Direction.Top)
            {
                return;
            }

            this.Direction = direction;
        }

        private Point GetDirectionPoint()
        {
            if (this.Direction == Direction.Right)
            {
                return new Point(2, 0);
            }
            else if (this.Direction == Direction.Left)
            {
                return new Point(-2, 0);
            }
            else if (this.Direction == Direction.Top)
            {
                return new Point(0, -1);
            }
            else if (this.Direction == Direction.Bottom)
            {
                return new Point(0, 1);
            }

            throw new InvalidOperationException($"Invalid direction {this.Direction}");
        }

        private void SetNewHead()
        {
            var directionPoint = this.GetDirectionPoint();
            var newHeadLeft = this.Head.Left + directionPoint.Left;
            var newHeadTop = this.Head.Top + directionPoint.Top;
            this.Head = new Point(newHeadLeft, newHeadTop);
        }

        public void IncreaseLength()
        {
            this.SetNewHead();

            this.Body.Enqueue(this.Head);
        }
    }
}
