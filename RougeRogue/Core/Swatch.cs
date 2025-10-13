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
        // http://paletton.com/#uid=73d0u0k5qgb2NnT41jT74c8bJ8X
        // Primary colors
        public static RLColor PrimaryLightest = new RLColor(255, 255, 255);      // FFFFFF
        public static RLColor PrimaryLighter = new RLColor(254, 149, 148);       // FE958A
        public static RLColor Primary = new RLColor(207, 114, 109);              // Interpolated
        public static RLColor PrimaryDarker = new RLColor(129, 79, 71);          // 816D68
        public static RLColor PrimaryDarkest = new RLColor(201, 31, 12);         // C91A08

        // Secondary color #1
        public static RLColor SecondaryLightest = new RLColor(152, 163, 148);    // 98A394
        public static RLColor SecondaryLighter = new RLColor(123, 135, 118);     // 7B8776
        public static RLColor Secondary = new RLColor(107, 119, 103);            // Interpolated
        public static RLColor SecondaryDarker = new RLColor(97, 110, 91);        // 616E5B
        public static RLColor SecondaryDarkest = new RLColor(69, 83, 64);        // 455340

        // Secondary color #2
        public static RLColor AlternateLightest = new RLColor(180, 164, 167);    // B4A4A7
        public static RLColor AlternateLighter = new RLColor(150, 131, 134);     // 968386
        public static RLColor Alternate = new RLColor(122, 104, 104);            // 7A6868
        public static RLColor AlternateDarker = new RLColor(91, 91, 74);         // 5B4F4A
        public static RLColor AlternateDarkest = new RLColor(91, 91, 74);        // 5B474A

        // Complement colors
        public static RLColor ComplimentLightest = new RLColor(64, 192, 93);     // 40C05D
        public static RLColor ComplimentLighter = new RLColor(13, 175, 49);      // 0DAF31
        public static RLColor Compliment = new RLColor(76, 122, 69);            // Interpolated
        public static RLColor ComplimentDarker = new RLColor(81, 97, 69);        // 516145
        public static RLColor ComplimentDarkest = new RLColor(8, 96, 30);        // 08601E

        // http://pixeljoint.com/forum/forum_posts.asp?TID=12795

        public static RLColor DbDark = new RLColor(20, 12, 28);
        public static RLColor DbOldBlood = new RLColor(68, 36, 52);
        public static RLColor DbDeepWater = new RLColor(48, 52, 109);
        public static RLColor DbOldStone = new RLColor(78, 74, 78);
        public static RLColor DbWood = new RLColor(133, 76, 48);
        public static RLColor DbVegetation = new RLColor(52, 101, 36);
        public static RLColor DbBlood = new RLColor(208, 70, 72);
        public static RLColor DbStone = new RLColor(117, 113, 97);
        public static RLColor DbWater = new RLColor(89, 125, 206);
        public static RLColor DbBrightWood = new RLColor(210, 125, 44);
        public static RLColor DbMetal = new RLColor(133, 149, 161);
        public static RLColor DbGrass = new RLColor(109, 170, 44);
        public static RLColor DbSkin = new RLColor(210, 170, 153);
        public static RLColor DbSky = new RLColor(109, 194, 202);
        public static RLColor DbSun = new RLColor(218, 212, 94);
        public static RLColor DbLight = new RLColor(222, 238, 214);
    }
}
