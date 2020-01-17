using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Enemy
    {
        public bool isAlive = true; 

        public void GetHit()
        {
            isAlive = false; 
        }
    }
}