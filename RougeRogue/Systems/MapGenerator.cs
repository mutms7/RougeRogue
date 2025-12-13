using RogueSharp;
using RougeRogue.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeRogue.Systems
{
    public class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _maxRooms;
        private readonly int _roomMaxSize;
        private readonly int _roomMinSize;

        private readonly DungeonMap _map;

        // Constructing a new MapGenerator requires the dimensions of the maps it will create
        // as well as the sizes and maximum number of rooms
        public MapGenerator(int width, int height,
        int maxRooms, int roomMaxSize, int roomMinSize)
        {
            _width = width;
            _height = height;
            _maxRooms = maxRooms;
            _roomMaxSize = roomMaxSize;
            _roomMinSize = roomMinSize;
            _map = new DungeonMap();
        }


        // Generate a new map that is a simple open floor with walls around the outside
        public DungeonMap CreateMap()
        {
            // all cell properties are false
            _map.Initialize(_width, _height);

            // try to place as many rooms as maxrooms
            for (int r = 0; r < _maxRooms; r++)
            {
                //size and pos of room randomly
                int roomWidth = Game.Random.Next(_roomMinSize, _roomMaxSize);
                int roomHeight = Game.Random.Next(_roomMinSize, _roomMaxSize);
                int roomXPosition = Game.Random.Next(0, _width - roomWidth - 1);
                int roomYPosition = Game.Random.Next(0, _height - roomHeight - 1);

            }
        }
    }
}
