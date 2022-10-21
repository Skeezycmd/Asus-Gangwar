using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gangwar.Models.FreeForAll
{
    public class SpawnObject
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }

        public SpawnObject(int id, Position position, Rotation rotation)
        {
            Id = id;
            Position = position;
            Rotation = rotation;
        }
    }
}
