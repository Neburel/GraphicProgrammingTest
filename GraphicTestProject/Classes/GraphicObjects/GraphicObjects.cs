using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace GraphicTestProject
{
    public enum Direction
    {
        Left, Right, Up, Up_Right, Up_Left, Down, Down_Right, Down_Left
    }
    abstract public class GraphicObjects
    {
        private static Semaphore semaphore;
        protected int pos_x;
        protected int pos_y;

        protected int height;
        protected int width;

        private int movingSpeed;
        private Direction movingDirection;

        protected GraphicObjects(int x, int y, int width, int height, Direction startmovingDirection)
        {
            //Default Constructor
            pos_x = x;
            pos_y = y;

            this.width = width;
            this.height = height;

            this.movingDirection = startmovingDirection;
            movingSpeed = 10;

            semaphore = new Semaphore(1, 1);
        }
        public Direction MovingDirection
        {
            set
            {
                movingDirection = value;
            }
            get
            {
                return movingDirection;
            }
        }
        public void moveGraphicObject(int screenHeight, int screenWidth)
        {
            semaphore.WaitOne();
            //move on a fixed Speed in a Direction
            move();
            //If The Movmend lets you touch any border then change direction
            borderhit_directionChange(screenHeight, screenWidth);
            semaphore.Release();            
        } 
        public abstract void drawGraphicObject(Graphics g);
        private Direction randomDirection()
        {
            Random rnd1 = new Random();
            int countDirections = Enum.GetNames(typeof(Direction)).Length;
            return (Direction)rnd1.Next(countDirections);
        }
        private Direction newRandomDirection()
        {
            //Wählt eine neue Richtung, Nur die AKtuelle Richtung ist Ausgeschlossen
            Direction newDirection = randomDirection();
            while(newDirection == movingDirection)
            {
                newDirection = randomDirection();
            }
            return newDirection;
        }
        private Direction newRandomDirection(Direction[] forbid)
        {
            Direction newDirection = newRandomDirection();
            for(int i=0; i<forbid.Length; i++)
            {
                if (newDirection == forbid[i])
                {
                    newDirection = newRandomDirection();
                    i = 0;
                }
                
            }
            return newDirection;
        }
        private void move()
        {
            //Move on a Fixed Speed in a Direction
            switch (movingDirection)
            {
                case Direction.Up:
                    pos_y = pos_y - movingSpeed;
                    break;
                case Direction.Down:
                    pos_y = pos_y + movingSpeed;
                    break;
                case Direction.Left:
                    pos_x = pos_x - movingSpeed;
                    break;
                case Direction.Right:
                    pos_x = pos_x + movingSpeed;
                    break;
                case Direction.Down_Right:
                    pos_y = pos_y + movingSpeed;
                    pos_x = pos_x + movingSpeed;
                    break;
                case Direction.Down_Left:
                    pos_y = pos_y + movingSpeed;
                    pos_x = pos_x - movingSpeed;
                    break;
                case Direction.Up_Right:
                    pos_y = pos_y - movingSpeed;
                    pos_x = pos_x + movingSpeed;
                    break;
                case Direction.Up_Left:
                    pos_y = pos_y - movingSpeed;
                    pos_x = pos_x - movingSpeed;
                    break;
            }
        }
        private void borderhit_directionChange(int screenHeight, int screenWidth)
        {
            Boolean topHit = false;
            Boolean botHit = false;
            Boolean rightHit = false;
            Boolean leftHit = false;

            if (pos_y <= 0) topHit = true;
            if (pos_y >= screenHeight - height) botHit = true;
            if (pos_x <= 0) leftHit = true;
            if (pos_x >= screenWidth - width) rightHit = true;

            //Hit Top Border
            if (topHit)
            {
                if (leftHit)
                {
                    movingDirection = newRandomDirection(new Direction[] { Direction.Up, Direction.Up_Right, Direction.Up_Left,  Direction.Left, Direction.Down_Left });
                }
                else if (rightHit)
                {
                    movingDirection = newRandomDirection(new Direction[] { Direction.Up, Direction.Up_Right, Direction.Up_Left, Direction.Right, Direction.Down_Right });
                }
                else
                {
                    movingDirection = newRandomDirection(new Direction[] { Direction.Up, Direction.Up_Right, Direction.Up_Left });
                }
            }
            else if (botHit)
            {
                if (leftHit)
                {
                    movingDirection = newRandomDirection(new Direction[] { Direction.Down, Direction.Down_Right, Direction.Down_Left, Direction.Left, Direction.Up_Left });
                }
                else if (rightHit)
                {
                    movingDirection = newRandomDirection(new Direction[] { Direction.Down, Direction.Down_Right, Direction.Down_Left, Direction.Right, Direction.Up_Right });
                }
                else
                {
                    movingDirection = newRandomDirection(new Direction[] { Direction.Down, Direction.Down_Right, Direction.Down_Left });
                }
            }
            else if (leftHit)
            {
                movingDirection = newRandomDirection(new Direction[] { Direction.Down_Left, Direction.Left, Direction.Up_Left });
            }
            else if (rightHit)
            {
                movingDirection = newRandomDirection(new Direction[] { Direction.Down_Right, Direction.Right, Direction.Up_Right});
            }
        }
       
    }
}
