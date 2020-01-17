using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Key
    {
        public Position position; 
        public char Character = char.Parse("?");
        
        public Key(Position position)
        {
            this.position = position; 
        }
    }
}
