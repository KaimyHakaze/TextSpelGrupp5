using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Map
    {
        private char[,] map;
        private char groundCharacter = char.Parse("-");
        private Player player;
        private Room[] rooms;

        private Key[] keys;

        public Map(char[,] size, Player player)
        {
            map = size;
            this.player = player;
            CreateMap();
        }

        public void Draw()
        {
            string toDraw = string.Empty;
            map[player.position.Y, player.position.X] = player.Character;
            foreach (var key in keys)
            {
                if (player.Keys.Contains(key))
                {
                    map[key.position.X, key.position.Y] = groundCharacter;
                }
            }
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if ((map[y, x] == player.Character && (y != player.position.Y || x != player.position.X)))
                    {
                        map[y, x] = groundCharacter;
                    }
                    if (player.position.Y <= Bottom() / 2 && y <= Bottom() / 2)
                    {
                        if (x == 0)
                        {
                            toDraw += "\n";
                            toDraw += (map[y, x]).ToString();
                        }
                        else
                        {
                            toDraw += (map[y, x]).ToString();
                        }
                    }
                    else if (player.position.Y > Bottom() / 2 && y > Bottom() / 2)
                    {
                        if (x == 0)
                        {
                            toDraw += "\n";
                            toDraw += (map[y, x]).ToString();
                        }
                        else
                        {
                            toDraw += (map[y, x]).ToString();
                        }
                    }
                }
            }
            Console.Clear();
            Console.WriteLine(toDraw);
        }

        public void CreateMap()
        {
            GenerateRooms();
            GenerateKeys();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = groundCharacter;
                }
            }
            if (rooms.Length > 0)
            {
                foreach (var room in rooms)
                {
                    map[room.position.Y, room.position.X] = room.Character;
                }
            }
            if (keys.Length > 0)
            {
                foreach (var key in keys)
                {
                    map[key.position.X, key.position.Y] = key.Character;
                }
            }
        }

        private void GenerateRooms()
        {
            rooms = new Room[10];

            for (int i = 0; i < rooms.Length; i++)
            {
                Random rand = new Random();
                int x = rand.Next(Right());
                int y = rand.Next(Bottom() - 1);
                rooms[i] = new Room(new Position(x, y));
            }
        }

        private void GenerateKeys()
        {
            keys = new Key[10];

            for (int i = 0; i < keys.Length; i++)
            {
                Random rand = new Random();
                int x = rand.Next(Right());
                int y = rand.Next(Bottom() - 1);
                keys[i] = new Key(new Position(x, y));
            }
        }

        public Key PlayerOnKey()
        {
            foreach (var key in keys)
            {
                if (key.position.Y == player.position.Y && key.position.X == player.position.X)
                {
                    return key;
                }
            }
            return null;
        }

        public bool PlayerInRoom()
        {
            foreach (var room in rooms)
            {
                if (room.position.Y == player.position.Y && room.position.X == player.position.X && room.HaveEnemies())
                {
                    return true;
                }
            }
            return false;
        }

        public Room GetPlayersRoom()
        {
            if (PlayerInRoom())
            {
                foreach (var room in rooms)
                {
                    if (room.position.Y == player.position.Y && room.position.X == player.position.X)
                    {
                        return room;
                    }
                }
            }
            return null;
        }

        public int Top()
        {
            return 0;
        }
        public int Bottom()
        {
            return map.GetLength(0);
        }
        public int Left()
        {
            return 0;
        }
        public int Right()
        {
            return map.GetLength(1);
        }
    }
}
