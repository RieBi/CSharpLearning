using System;
using System.Collections.Generic;
using System.Text;

namespace WalkerGame_1
{
    public class Tile
    {
        public int ID { get; set; }
        public bool HasEntity { get; set; } = false;
        private int Entities { get; set; } = 0;
        public bool HasEnemy { get; set; } = false;
        private int Enemies { get; set; } = 0;
        public bool HasPlayer { get; set; } = false;


        public List<Entity> Creatures = new List<Entity>();

        public Tile()
        {

        }

        public void AddEntity(Entity entity)
        {
            Creatures.Add(entity);
            Entities++;
            HasEntity = true;
            switch (entity.Type)
            {
                case "Enemy":
                    HasEnemy = true;
                    Enemies++;
                    return;
                case "Player":
                    HasPlayer = true;
                    return;
            }
        }

        public void RemoveEntity(Entity entity)
        {
            if (!Creatures.Contains(entity)) { throw new Exception("Entity hasn't been found"); }

            Creatures.Remove(entity);
            switch (entity.Type)
            {
                case "Enemy":
                    if (Enemies == 1)
                    {
                        HasEnemy = false;
                    }
                    Enemies--;
                    break;
                case "Player":
                    HasPlayer = false;
                    break;
            }

            if (Entities == 1)
            {
                HasEntity = false;
            }
            Entities--;

        }
    }
}
