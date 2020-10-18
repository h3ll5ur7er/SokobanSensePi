using System;

namespace SokobanSensePi
{
    public class LevelParser
    {
          const string TEST_LEVEL1 = @"14 7 Test
       ####   
########  ##  
#          ###
# @$$ ##   ..#
# $$   ##  ..#
#         ####
###########   
";

          const string TEST_LEVEL0 = @"6 7 Test
######
##.. #
###  #
# $  #
# $ ##
#@  ##
######
";

        public static Level Parse(string level=TEST_LEVEL0)
        {
                var lines = level.Split('\n');
                var parts = lines[0].Split(' ');
                var width = int.Parse(parts[0]);
                var height = int.Parse(parts[1]);
                var lvl = new Level(width, height, parts[2]);
                
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        lvl[x,y] = lines[y+1][x].ParseLevelTile();
                    }
                }
                lvl.FindPlayer();
                return lvl;
        }
    }
}