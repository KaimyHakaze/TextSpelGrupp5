using System;
using System.Text;
using System.Collections.Generic; 

namespace Projekt
{
    public struct Position
    {
        public int X;
        public int Y;

        public Position(int y, int x)
        {
            this.Y = y;
            this.X = x;
        }
    }

    class Player
    {
        public Position position;
        public char Character = char.Parse("*");
        public string Name;
        public int Speed;
        public int Health = 100; 

        public List<Key> Keys = new List<Key>(); 

        public Player(Position position, string name, int speed)
        {
            this.position = position;
            Name = name;
            Speed = speed;
        }

        public void AddKey(Key key)
        {
            Keys.Add(key);
        }

        public void Move(int y, int x)
        {
            this.position = new Position(y, x);
        }

        public void MoveUp()
        {
            this.position = new Position(this.position.Y - Speed, this.position.X); 
        }

        public void MoveDown()
        {
            this.position = new Position(this.position.Y + Speed, this.position.X);
        }

        public void MoveLeft()
        {
            this.position = new Position(this.position.Y, this.position.X - Speed);
        }

        public void MoveRight()
        {
            this.position = new Position(this.position.Y, this.position.X + Speed);
        }
    }
}
