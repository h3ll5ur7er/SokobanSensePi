using System;
using Sense.Led;

namespace SokobanSensePi
{
    public static class LevelTileExtensions
    {
        public static LevelTile ParseLevelTile(this char tile)
        {
            switch(tile)
            {
                case LevelConstants.SPACE:        return LevelTile.Space;
                case LevelConstants.WALL:         return LevelTile.Wall;
                case LevelConstants.GOAL:         return LevelTile.Goal;
                case LevelConstants.PLAYER:       return LevelTile.Player;
                case LevelConstants.BOX:          return LevelTile.Box;
                case LevelConstants.PLAYER_ON_GOAL: return LevelTile.PlayerOnGoal;
                case LevelConstants.BOX_ON_GOAL:    return LevelTile.BoxOnGoal;
                default:                     return LevelTile.Invalid;
            }
        }
        public static char Render(this LevelTile tile)
        {
            switch(tile)
            {
                case LevelTile.Space:        return LevelConstants.SPACE;
                case LevelTile.Wall:         return LevelConstants.WALL;
                case LevelTile.Goal:         return LevelConstants.GOAL;
                case LevelTile.Player:       return LevelConstants.PLAYER;
                case LevelTile.Box:          return LevelConstants.BOX;
                case LevelTile.PlayerOnGoal: return LevelConstants.PLAYER_ON_GOAL;
                case LevelTile.BoxOnGoal:    return LevelConstants.BOX_ON_GOAL;
                default:                     return '?';
            }
        }
        public static Color GetColor(this LevelTile tile)
        {
            switch(tile)
            {
                case LevelTile.Space:        return new Color(0x00, 0x00, 0x00);
                case LevelTile.Wall:         return new Color(0xff, 0xff, 0xff);
                case LevelTile.Goal:         return new Color(0xff, 0x00, 0x00);
                case LevelTile.Player:       return new Color(0x00, 0x00, 0xff);
                case LevelTile.Box:          return new Color(0x00, 0xff, 0x00);
                case LevelTile.PlayerOnGoal: return new Color(0xff, 0xff, 0x00);
                case LevelTile.BoxOnGoal:    return new Color(0x00, 0xff, 0xff);
                default:                     return new Color(0xff, 0x00, 0xff);
            }
        }
        public static LevelTile Toggle(this LevelTile state, LevelTile tile, bool? on=null)
        {
            if (state == LevelTile.Wall) throw new InvalidOperationException("can not toggle wall");
            LevelTile turnOn() {
                return state | tile;
            }
            LevelTile turnOff() {
                return state & ~tile;
            }
         
            if (on.HasValue)
                if (on.Value) return turnOn();
                else return turnOff();
            else
                if(state.HasFlag(tile)) return turnOff();
                else return turnOn();
        }
    }
}