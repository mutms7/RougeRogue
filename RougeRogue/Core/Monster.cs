using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeRogue.Core
{
    public class Monster : Actor
    {
        

        public void DrawStats(RLConsole statConsole, int position)
        {
            // Y = 13, then multiply position by 2 to leave a space
            int yPosition = 13 + (2 * position);

            // print symbol of monster
            statConsole.Print(1, yPosition, Symbol.ToString(), Color);

            // find width by dividing current health by max health
            int width = Convert.ToInt32((double)Health / (double)(MaxHealth) * 16.0);
            int remainingWidth = 16 - width;

            // set background colors of health bar
            statConsole.SetBackColor(3, yPosition, width, 1, Swatch.ComplimentLighter);
            statConsole.SetBackColor(3 + width, yPosition, remainingWidth, 1, Swatch.ComplimentDarkest);


            //Print monsters name over top
            statConsole.Print(3, yPosition, $": {Name}", Swatch.DbLight);
        }
    }
}
