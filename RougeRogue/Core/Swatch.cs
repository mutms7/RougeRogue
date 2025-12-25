using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeRogue.Core
{
    internal class Swatch
    {
        // Primary colors - Pure Reds
        public static RLColor PrimaryLightest = new RLColor(255, 230, 230);      // FFE6E6 - Very light red/pink
        public static RLColor PrimaryLighter = new RLColor(255, 150, 150);       // FF9696 - Light red
        public static RLColor Primary = new RLColor(220, 50, 50);                // DC3232 - Pure red
        public static RLColor PrimaryDarker = new RLColor(150, 30, 30);          // 961E1E - Dark red
        public static RLColor PrimaryDarkest = new RLColor(80, 10, 10);          // 500A0A - Very dark red

        // Secondary color #1 - Oranges
        public static RLColor SecondaryLightest = new RLColor(255, 235, 215);    // FFEBD7 - Very light orange
        public static RLColor SecondaryLighter = new RLColor(255, 180, 120);     // FFB478 - Light orange
        public static RLColor Secondary = new RLColor(255, 140, 50);             // FF8C32 - Orange
        public static RLColor SecondaryDarker = new RLColor(180, 80, 30);        // B4501E - Dark orange
        public static RLColor SecondaryDarkest = new RLColor(110, 50, 20);       // 6E3214 - Very dark orange

        // Secondary color #2 - Yellows/Golds
        public static RLColor AlternateLightest = new RLColor(255, 250, 220);    // FFFADC - Very light yellow
        public static RLColor AlternateLighter = new RLColor(255, 220, 120);     // FFDC78 - Light yellow
        public static RLColor Alternate = new RLColor(240, 180, 60);             // F0B43C - Gold
        public static RLColor AlternateDarker = new RLColor(180, 130, 40);       // B48228 - Dark gold
        public static RLColor AlternateDarkest = new RLColor(110, 80, 30);       // 6E501E - Very dark gold

        // Complement colors - Blues/Cyans (for enemies or special elements)
        public static RLColor ComplimentLightest = new RLColor(200, 230, 255);   // C8E6FF - Very light blue
        public static RLColor ComplimentLighter = new RLColor(100, 180, 220);    // 64B4DC - Light blue
        public static RLColor Compliment = new RLColor(50, 120, 180);            // 3278B4 - Blue
        public static RLColor ComplimentDarker = new RLColor(30, 70, 110);       // 1E466E - Dark blue
        public static RLColor ComplimentDarkest = new RLColor(10, 30, 60);       // 0A1E3C - Very dark blue

        // Object colors - Adjusted to warm red/orange tones
        public static RLColor DbDark = new RLColor(40, 10, 10);                  // 280A0A - Very dark red-black
        public static RLColor DbOldBlood = new RLColor(120, 30, 30);             // 781E1E - Old blood red
        public static RLColor DbDeepWater = new RLColor(80, 40, 50);             // 502832 - Deep red-purple
        public static RLColor DbOldStone = new RLColor(90, 70, 60);              // 5A463C - Reddish brown stone
        public static RLColor DbWood = new RLColor(150, 70, 40);                 // 964628 - Warm wood
        public static RLColor DbVegetation = new RLColor(120, 80, 40);           // 785028 - Autumn vegetation
        public static RLColor DbBlood = new RLColor(220, 60, 60);                // DC3C3C - Fresh blood
        public static RLColor DbStone = new RLColor(130, 100, 80);               // 826450 - Warm stone
        public static RLColor DbWater = new RLColor(180, 100, 100);              // B46464 - Red-tinted water
        public static RLColor DbBrightWood = new RLColor(220, 120, 60);          // DC783C - Bright orange wood
        public static RLColor DbMetal = new RLColor(160, 120, 110);              // A0786E - Copper/bronze metal
        public static RLColor DbGrass = new RLColor(180, 120, 60);               // B4783C - Dry grass
        public static RLColor DbSkin = new RLColor(240, 180, 150);               // F0B496 - Warm skin
        public static RLColor DbSky = new RLColor(255, 180, 140);                // FFB48C - Sunset sky
        public static RLColor DbSun = new RLColor(255, 200, 100);                // FFC864 - Warm sun
        public static RLColor DbLight = new RLColor(255, 240, 220);              // FFF0DC - Warm light
    }
}
