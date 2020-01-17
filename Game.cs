using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Game
    {
        private Player player;
        private Map map;
        string input;

        bool gameover = false;
        public Game()
        {
            System.Console.Write("Skriv in hjältens namn: ");
            string name = Console.ReadLine();
            player = new Player(new Position(99, 0), name, 1);
            map = new Map(new char[100, 100], player);
        }

        private void RoomScene()
        {
            Room room = map.GetPlayersRoom();
            if (room.HaveEnemies())
            {
                Console.WriteLine("Antal fiender: {0}", room.GetEnemies().Length);
                Console.WriteLine();
                Console.WriteLine("{0}: {1} liv", player.Name, player.Health);
                System.Console.WriteLine("Slåss eller fly?");
                string action = Console.ReadLine();
                action = action.ToLower();
                action = action.Trim();
                switch (action)
                {
                    case "slåss":
                        while (true)
                        {
                            System.Console.WriteLine("Skriv 'attack' för att attackera");
                            string inp = Console.ReadLine();
                            bool fightover = false;
                            if (inp == "attack" && room.HaveEnemies())
                            {
                                Random rand = new Random();
                                if (rand.Next(5) == 0)
                                {
                                    player.Health -= 10;
                                    if(player.Health <= 0)
                                    {
                                        gameover = true; 
                                        break; 
                                    }
                                }
                                room.PlayerAttack();
                                System.Console.WriteLine("En fiende dog");
                                if (!room.HaveEnemies())
                                {
                                    fightover = true;
                                }
                                if (rand.Next(1) == 0)
                                {
                                    if (player.Health < 100)
                                    {
                                        player.Health += 10;
                                        Console.WriteLine("Du fick 10 extra liv");
                                    }
                                }
                            }
                            else if (inp != "attack")
                            {
                                Console.WriteLine("Skriv 'attack' för att attackera");
                            }
                            if(gameover)
                            {
                                break; 
                            }
                            if (fightover)
                            {
                                Console.WriteLine("Alla fiender dog...");
                                Console.ReadKey();
                                break;
                            }
                        }
                        break;
                    case "fly":
                        if (player.position.X + 1 <= map.Right())
                        {
                            player.position.X = room.position.X + 1;
                            player.position.Y = room.position.Y + 1;
                        }
                        else if (player.position.X - 1 >= map.Left())
                        {
                            player.position.X = room.position.X - 1;
                            player.position.Y = room.position.Y - 1;
                        }
                        else if (player.position.Y - 1 >= map.Top())
                        {
                            player.position.X = room.position.X - 1;
                            player.position.Y = room.position.Y - 1;
                        }
                        else
                        {
                            player.position.X = room.position.X - 1;
                            player.position.Y = room.position.Y - 1;
                        }
                        break;
                }
            }
        }

        public void Run()
        {
            while (true)
            {
                if (player.position.X == map.Right() && player.position.Y == map.Top() 
                    && player.Keys.Count == 10)
                {
                    System.Console.WriteLine("Du vann!");
                    Console.ReadKey();
                    break;
                }
                else if (gameover)
                {
                    System.Console.WriteLine("Du förlorade!");
                    Console.ReadKey();
                    break;
                }
                map.Draw();
                Console.WriteLine();

                if (map.PlayerInRoom())
                {
                    RoomScene();
                }
                else if (map.PlayerOnKey() != null)
                {
                    if (!player.Keys.Contains(map.PlayerOnKey()))
                    {
                        player.AddKey(map.PlayerOnKey());
                    }
                }
                else
                {
                        input = Console.ReadLine();

                        switch (input)
                        {
                        case "goup":
                            if (player.position.Y - player.Speed >= map.Top())
                                player.MoveUp();
                            break;
                        case "w":
                            if (player.position.Y - player.Speed >= map.Top())
                                player.MoveUp();
                            break;
                        case "godown":
                            if (player.position.Y + player.Speed <= map.Bottom())
                                player.MoveDown();
                            break;
                        case "s":
                            if (player.position.Y + player.Speed <= map.Bottom())
                                player.MoveDown();
                            break;
                        case "goleft":
                            if (player.position.X - player.Speed >= map.Left())
                                player.MoveLeft();
                            break;
                        case "a":
                            if (player.position.X - player.Speed >= map.Left())
                                player.MoveLeft();
                            break;
                        case "goright":
                            if (player.position.Y + player.Speed <= map.Right())
                                player.MoveRight();
                            break;
                        case "d":
                            if (player.position.Y + player.Speed <= map.Right())
                                player.MoveRight();
                            break;
                    }
                }
            }
        }
    }
}
