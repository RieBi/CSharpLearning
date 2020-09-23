using System;
using System.Collections.Generic;
using System.Text;

namespace WalkerGame_1
{
    public class Character : Entity
    {
        public int Sight = 2;
        public List<Tile> TilesInSight = new List<Tile>();

        public Character(int maxHealth, int damage)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
            Damage = damage;


            Type = "Character";
        }

        public void Move(byte direction) // 1 is backward, 2 is forward
        {
            if (direction == 1 && this.CurrentTile.ID != 0) // backward
            {
                CurrentTile.RemoveEntity(this);
                this.CurrentTile =  Program.Tiles[this.CurrentTile.ID - 1];
                CurrentTile.AddEntity(this);
            }
            else if (direction == 2 && this.CurrentTile.ID < Program.Tiles.Length - 1) // forward
            {
                this.CurrentTile.RemoveEntity(this);
                this.CurrentTile = Program.Tiles[this.CurrentTile.ID + 1];
                this.CurrentTile.AddEntity(this);
            }
        }

        public void UpdateSight()
        {
            TilesInSight.Clear();

            int minTile = CurrentTile.ID >= Sight ? CurrentTile.ID - Sight : 0;
            int maxTile = Program.Tiles.Length - CurrentTile.ID >= Sight ? CurrentTile.ID + Sight : Program.Tiles.Length;

            for (int i = minTile; i <= maxTile; i++)
            {
                try { TilesInSight.Add(Program.Tiles[i]); }
                catch { }
            }
        }
    }
}
