using RogueSharp.DiceNotation;
using RougeRogue.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeRogue.Systems
{
    public class CommandSystem
    {
        
        // Return value is true if the player was able to move
        // false when the player couldn't move, such as trying to move into a wall
        public bool MovePlayer(Direction direction)
        {
            int x = Game.Player.X;
            int y = Game.Player.Y;

            switch (direction)
            {
                case Direction.Up:
                    {
                        y = Game.Player.Y - 1;
                        break;
                    }
                case Direction.Down:
                    {
                        y = Game.Player.Y + 1;
                        break;
                    }
                case Direction.Left:
                    {
                        x = Game.Player.X - 1;
                        break;
                    }
                case Direction.Right:
                    {
                        x = Game.Player.X + 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            if (Game.DungeonMap.SetActorPosition(Game.Player, x, y))
            {
                return true;
            }

            Monster monster = Game.DungeonMap.GetMonsterAt(x, y);

            if (monster != null)
            {
                Attack(Game.Player, monster);
                return true;
            }
            

            return false;
        }

        public void Attack(Actor attacker, Actor defender)
        {
            StringBuilder attackMessage = new StringBuilder();
            StringBuilder defenseMessage = new StringBuilder();

            int hits = ResolveAttack(attacker, defender, attackMessage);
            int blocks = ResolveDefense(defender, hits, attackMessage, defenseMessage);

            Game.MessageLog.Add(attackMessage.ToString());
            if (!string.IsNullOrWhiteSpace(defenseMessage.ToString()))
            {
                Game.MessageLog.Add(defenseMessage.ToString());
            }

            int damage = hits - blocks;
            ResolveDamage(defender, damage);
        }

        private static int ResolveAttack(Actor attacker, Actor defender, StringBuilder attackMessage)
        {
            int hits = 0;

            attackMessage.AppendFormat("{0} attacks {1} and rolls: ", attacker.Name, defender.Name);

            // roll 100-sided die equal to attack value
            DiceExpression attackDice = new DiceExpression().Dice(attacker.Attack, 100);
            DiceResult attackResult = attackDice.Roll();

            // look at face value of each die
            foreach (TermResult termResult in attackResult.Results)
            {
                attackMessage.Append(termResult.Value + ", ");
                // compare value to 100 minus attack chance and add a hit if greater
                if (termResult.Value >= 100 - attacker.AttackChance)
                {
                    hits++;
                }
            }

            return hits;
        }

        private static int ResolveDefense(Actor defender, int hits, StringBuilder attackMessage, StringBuilder defenseMessage)
        {
            int blocks = 0;

            if (hits > 0)
            {
                attackMessage.AppendFormat("landing {0} hits.", hits);
                defenseMessage.AppendFormat("  {0} defends and rolls: ", defender.Name);


                DiceExpression defenseDice = new DiceExpression().Dice(defender.Defense, 100);
                DiceResult defenseResult = defenseDice.Roll();

                foreach (TermResult termResult in defenseResult.Results)
                {
                    defenseMessage.Append(termResult.Value + ", ");
                    if (termResult.Value >= 100 - defender.DefenseChance)
                    {
                        blocks++;
                    }

                }
                defenseMessage.AppendFormat("blocking {0} times.", blocks);
            } else
            {
                attackMessage.AppendFormat("missing all attacks.");
            }

            return blocks;
            
        }

        // apply any damage
        private static void ResolveDamage(Actor defender, int damage)
        {
            if (damage > 0)
            {
                defender.Health = defender.Health - damage;

                Game.MessageLog.Add($"  {defender.Name} took {damage} damage");

                if (defender.Health <= 0)
                {
                    ResolveDeath(defender);
                }
            } else
            {
                Game.MessageLog.Add($"  {defender.Name} took no damage");
            }
        }

        // remove defender and add messages
        private static void ResolveDeath(Actor dead)
        {
            if (dead is Player)
            {
                Game.MessageLog.Add($"  {dead.Name} was slain, game over!");
            }
            else if (dead is Monster)
            {
                Game.MessageLog.Add($"  {dead.Name} was slain and dropped {dead.Gold} GP");
                Game.DungeonMap.RemoveMonster((Monster)dead);
            }
        }


    }
}
