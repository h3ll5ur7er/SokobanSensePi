using System;

namespace SokobanSensePi
{
    [Flags]
    public enum LevelTile
    {
        Space = 0, //Black #000000
        Wall = 1, //White #ffffff
        Player = 2,//Red #ff0000
        Box = 4, //Blue #0000ff
        Goal = 8,//Green #00ff00
        PlayerOnGoal = Player | Goal, // Yellow #ffff00
        BoxOnGoal = Box | Goal,//Cyan #00ffff
        Invalid = 16 //Magenta #ff00ff
    }


}