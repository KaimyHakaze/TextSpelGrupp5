using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Room
    {
        public Position position;
        private Enemy[] enemies;
        public char Character = char.Parse("-"); 

        public Room(Position position)
        {
            this.position = position;
            Random rand = new Random();
            int numberofEnemies = rand.Next(1, 4);
            enemies = new Enemy[numberofEnemies];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Enemy(); 
            }
        }


        public void PlayerAttack() 
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if(enemies[i].isAlive)
                {
                    enemies[i].isAlive = false; 
                    break; 
                }
            }
        }

        public Enemy[] GetEnemies()
        {
            return enemies; 
        }

        public bool HaveEnemies()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.isAlive)
                {
                    return true; 
                }
            }
            return false; 
        }
    }
}
