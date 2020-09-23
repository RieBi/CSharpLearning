using System;
using System.Collections.Generic;
using System.Text;

namespace WalkerGame_1
{
    public class Monster : Entity
    {

        public Monster(int maxHealth, int damage, string name, Tile tile)
        {
            Health = maxHealth;
            MaxHealth = maxHealth;
            Damage = damage;
            Name = name;

            Type = "Enemy";
            CurrentTile = tile;
        }

        public override void Die()
        {
            CurrentTile.RemoveEntity(this);
        }

    }
}
