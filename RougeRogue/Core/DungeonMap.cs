using RLNET;
using RogueSharp;
using RougeRogue.Core;
namespace  RougeRogue.Core
{
    // Our custom DungeonMap class extends the base RogueSharp Map class
    public class DungeonMap : Map
    {
        public List<Rectangle> Rooms;
        private readonly List<Monster> _monsters;

        public DungeonMap()
        {
            // Initialize the list of rooms when we create a new DungeonMap
            Rooms = new List<Rectangle>();
            _monsters = new List<Monster>();
        }
        // This method will be called any time we move the player to update field-of-view
        public void UpdatePlayerFieldOfView()
        {
            Player player = Game.Player;
            // Compute the field-of-view based on the player's location and awareness
            ComputeFov(player.X, player.Y, player.Awareness, true);
            // Mark all cells in field-of-view as having been explored
            foreach (Cell cell in GetAllCells())
            {
                if (IsInFov(cell.X, cell.Y))
                {
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }
        // The Draw method will be called each time the map is updated
        // It will render all of the symbols/colors for each cell to the map sub console
        public void Draw(RLConsole mapConsole, RLConsole statConsole)
        {

            foreach (Cell cell in GetAllCells())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }


            int i = 0;
            foreach (Monster monster in _monsters)
            {
                monster.Draw(mapConsole, this);
                // When the monster is in the field-of-view also draw their stats
                if (IsInFov(monster.X, monster.Y))
                {
                    // Pass in the index to DrawStats and increment it afterwards
                    monster.DrawStats(statConsole, i);
                    i++;
                }
            }
        }
        private void SetConsoleSymbolForCell(RLConsole console, Cell cell)
        {
            // When we haven't explored a cell yet, we don't want to draw anything
            if (!cell.IsExplored)
            {
                return;
            }
            // When a cell is currently in the field-of-view it should be drawn with ligher colors
            if (IsInFov(cell.X, cell.Y))
            {
                // Choose the symbol to draw based on if the cell is walkable or not
                // '.' for floor and '#' for walls
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.FloorFov, Colors.FloorBackgroundFov, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.WallFov, Colors.WallBackgroundFov, '#');
                }
            }
            // When a cell is outside of the field of view draw it with darker colors
            else
            {
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
                }
            }
        }

        // true when actor can be placed, false otherwise
        public bool SetActorPosition(Actor actor, int x, int y)
        {
            // allow actor placement if cell is walkable
            if (GetCell(x, y).IsWalkable)
            {
                // previous cell is walkable
                SetIsWalkable(actor.X, actor.Y, true);
                // update the actor's position
                actor.X = x;
                actor.Y = y;
                // the new cell the actor is on is now not walkable
                SetIsWalkable(actor.X, actor.Y, false);
                // don't forget to update the field of view if we repositioned
                if (actor is Player)
                {
                    UpdatePlayerFieldOfView();
                }
                return true;
            }
            return false;
        }


        // helper method for setting IsWalkable on a Cell
        public void SetIsWalkable(int x, int y, bool IsWalkable)
        {
            Cell cell = GetCell(x, y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, IsWalkable, cell.IsExplored);
        }

        // called by MapGenerator after map is generated to add player to map
        public void AddPlayer(Player player)
        {
            Game.Player = player;
            SetIsWalkable(player.X, player.Y, false);
            UpdatePlayerFieldOfView();
        }


        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
            // cell not walkable
            SetIsWalkable(monster.X, monster.Y, false);
        }


        public Point GetRandomWalkableLocationInRoom(Rectangle room)
        {
            if (DoesRoomHaveWalkableSpace(room))
            {
                for (int i = 0; i < 100; i++)
                {
                    int x = Game.Random.Next(1, room.Width - 2) + room.X;
                    int y = Game.Random.Next(1, room.Height - 2) + room.Y;
                    if (IsWalkable(x, y))
                    {
                        return new Point(x, y);
                    }
                }

            }
            return null;
        }

        public bool DoesRoomHaveWalkableSpace(Rectangle room)
        {
            for (int i = 1; i < room.Width - 2; i++)
            {
                for (int j = 1; j < room.Height - 2; j++)
                {
                    if (IsWalkable(room.X + i, room.Y + j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        

        public void RemoveMonster(Monster monster)
        {
            _monsters.Remove(monster);
            // make cell walkable
            SetIsWalkable(monster.X, monster.Y, true);
        }

        public Monster GetMonsterAt(int x, int y)
        {
            return _monsters.FirstOrDefault(m => m.X == x && m.Y == y);
        }
    }

}