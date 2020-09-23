using System;
using System.Text;

namespace WalkerGame_1
{
    public class Program
    {
        public static Random rnd = new Random();
        public static StringBuilder NewInfo = new StringBuilder();
        public static Character Player = new Character(10, 1);
        
        private static int AmountOfTiles;
        public static Tile[] Tiles;


        static void Main(string[] args)
        {

            Start();

            while (true)
            {
                LogInfo();
                Control();
                UpdateTurn();


            }





            Console.ReadLine();
        }

        static void CreateTiles(int amount)
        {
            Tiles = new Tile[amount];

            for (int i = 0; i < amount; i++)
            {
                Tiles[i] = new Tile();
                Tiles[i].ID = i;
            }
        }

        static void Start()
        {
            PrepareSettings();

            int tileId = rnd.Next(Tiles.Length);
            Player.CurrentTile = Tiles[tileId];
            Player.CurrentTile.AddEntity(Player);
            
        }

        static void UpdateTurn()
        {
            for (int i = 0; i < Tiles.Length; i++)
            {
                int num = rnd.Next(11);
                if (num == 1 && !Tiles[i].HasEntity)
                {
                    Tiles[i].AddEntity(new Monster(5, 1, "Rat", Tiles[i]));
                }
            }
            Player.UpdateSight();
        }

        public static void LogDebug(string text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;

        }
        static void LogInfo()
        {
            Console.WriteLine("----------");

            ConsoleColor OldCOlor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(NewInfo);
            Console.ForegroundColor = OldCOlor;
            NewInfo.Clear();
            Console.WriteLine($"You are on the {Player.CurrentTile.ID + 1} tile.");
            for (int i = 0; i < Player.TilesInSight.Count; i++)
            {
                if (Player.TilesInSight[i].HasEnemy)
                {
                    OldCOlor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;


                    Console.WriteLine($"There is a monster on a {Player.TilesInSight[i].ID + 1} tile!");

                    Console.ForegroundColor = OldCOlor;
                }
            }
        }

        static void Control()
        {
            Console.Write("What would you like to do?\n1. Stay on the tile\n2. Go to the previous tile\n3. Go to the next tile");
            if (Player.CurrentTile.HasEnemy) Console.Write("\n4. Attack an enemy");
            Console.WriteLine();
            ConsoleKeyInfo Choose = Console.ReadKey(true);

            if (Choose.Key == ConsoleKey.D1) return;
            else if (Choose.Key == ConsoleKey.D2)
            {
                Player.Move(1);
            }
            else if (Choose.Key == ConsoleKey.D3)
            {
                Player.Move(2);
            }
            else if (Choose.Key == ConsoleKey.D4 && Player.CurrentTile.HasEnemy)
            {
                Entity enemy;
                foreach (Entity i in Player.CurrentTile.Creatures)
                {
                    if (i.Type == "Enemy")
                    {
                        enemy = i;
                        Player.Attack(enemy);

                        NewInfo.Append($"You attacked a {enemy.Name} for {Player.Damage} damage and it has {enemy.Health} hp\n");
                        if (enemy.Health == 0) NewInfo.Append($"You have killed a {enemy.Name}!\n");

                        break;
                    }
                }
            }

        }

        static void PrepareSettings()
        {
            Console.SetBufferSize(1000, 1000);
            Console.SetWindowSize(150, 50);
            Console.Title = "Some game";

            Console.WriteLine("What's your name?");
            Player.Name = Console.ReadLine();
            Console.WriteLine("How many tiles do you want to see in the game?");
            CreateTiles(Int32.Parse(Console.ReadLine()));


        }
    }
}
