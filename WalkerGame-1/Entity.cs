using System;
using System.Collections.Generic;
using System.Text;

namespace WalkerGame_1
{
    public class Entity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public Tile CurrentTile { get; set; }
        public string Type;

        public Entity()
        {

        }

        public void Attack(Entity entity)
        {
            entity.Health -= this.Damage;
            if (entity.Health == 0) entity.Die();
        }

        public virtual void Die() { CurrentTile.RemoveEntity(this); }
    }
}
