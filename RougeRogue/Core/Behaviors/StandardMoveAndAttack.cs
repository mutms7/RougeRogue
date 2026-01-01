using RogueSharp;
using RougeRogue.Interfaces;
using RougeRogue.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RougeRogue.Core.Behaviors
{
    public class StandardMoveAndAttack: IBehavior
    {
        public bool Act(Monster monster, CommandSystem commandSystem)
        {
            DungeonMap dungeonMap = Game.DungeonMap;
            Player player = Game.Player;
            FieldOfView monsterFov = new FieldOfView(dungeonMap);

            // if monster has not been alerted, computer fieldofview
            // use monster's awareness for distance
            // if player in monster's fov then alert it
            // add a message to messagelog saying alerted
            if (!monster.TurnsAlerted.HasValue)
            {
                monsterFov.ComputeFov(monster.X, monster.Y, monster.Awareness, true);
                if (monsterFov.IsInFov(player.X, player.Y))
                {
                    Game.MessageLog.Add($"{monster.Name} has noticed {player.Name}");
                    monster.TurnsAlerted = 1;
                }
            }

            if (monster.TurnsAlerted.HasValue)
            {
                // before finding path, monster and player cells should be walkable
                dungeonMap.SetIsWalkable(monster.X, monster.Y, true);
                dungeonMap.SetIsWalkable(player.X, player.Y, true);

                PathFinder pathFinder = new PathFinder(dungeonMap);
                RogueSharp.Path path = null;

                try
                {
                    path = pathFinder.ShortestPath(
                        dungeonMap.GetCell(monster.X, monster.Y),
                        dungeonMap.GetCell(player.X, player.Y));

                }
                catch (PathNotFoundException)
                {
                    // monster can see but cannot find path
                    Game.MessageLog.Add($"{monster.Name} waits");
                }

                dungeonMap.SetIsWalkable(monster.X, monster.Y, false);
                dungeonMap.SetIsWalkable(player.X, player.Y, false);

                if (path != null)
                {
                    try
                    {
                        commandSystem.MoveMonster(monster, path.Steps.First());
                    }
                    catch (NoMoreStepsException)
                    {
                        Game.MessageLog.Add($"{monster.Name} growls in frustration");
                    }
                }
            }

            monster.TurnsAlerted++;

            // lose alerted status after 10 turns out of fov
            if (monster.TurnsAlerted > 10)
            {
                monster.TurnsAlerted = null;
            }
            return true;

        }
    }
}
