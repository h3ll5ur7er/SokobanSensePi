using System;
using System.Drawing;

namespace SokobanSensePi
{
    public class Level
    {
        private LevelTile[,] tiles;
        public int Width { get; }
        public int Height { get; }
        public string Name { get; }
        public Point PlayerPosition { get; private set; }
        public LevelTile this[int x, int y] { get => tiles[x,y]; set => tiles[x,y] = value; }
        public LevelTile this[Point p] { get => tiles[p.X,p.Y]; set => tiles[p.X,p.Y] = value; }
        public Level(int width, int height, string name)
        {
            Width = width;
            Height = height;
            Name = name;

            tiles = new LevelTile[Width, Height];
        }

        public void FindPlayer()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (this[x,y].HasFlag(LevelTile.Player))
                    {
                        PlayerPosition = new Point(x,y);
                    }
                }
            }
        }

        public void TryMoveTo(Direction direction)
        {
            if (CanMoveTo(direction))
            {
                MoveTo(direction);
            }
        }

        private void MoveTo(Direction direction)
        {
            var nextToPlayer       = PlayerPosition.Move(direction);
            var whereItGoes        = nextToPlayer.Move(direction);
            var whereThatGoes      = whereItGoes.Move(direction);

            if (this[nextToPlayer].HasFlag(LevelTile.Box))
            {
                this[whereItGoes] = this[whereItGoes].Toggle(LevelTile.Box, true);
                this[nextToPlayer] = this[nextToPlayer].Toggle(LevelTile.Box, false);

            }
            this[nextToPlayer] = this[nextToPlayer].Toggle(LevelTile.Player, true);
            this[PlayerPosition] = this[PlayerPosition].Toggle(LevelTile.Player, false);
            PlayerPosition = nextToPlayer;
        }

        private bool CanMoveTo(Direction direction)
        {
            if (direction == Direction.None) return false;
            var nextToPlayer       = PlayerPosition.Move(direction);
            var whereItGoes        = nextToPlayer.Move(direction);
            var whereThatGoes      = whereItGoes.Move(direction);

            var pos       = PlayerPosition.Move(direction);
            var next      = pos.Move(direction);
            var afterNext = next.Move(direction);
            
            if (this[nextToPlayer].HasFlag(LevelTile.Wall)) return false;
            
            if (this[nextToPlayer].HasFlag(LevelTile.Box))
            {
                if (this[whereItGoes].HasFlag(LevelTile.Wall) || this[whereItGoes].HasFlag(LevelTile.Box))
                    return false;
            }
            return true;
        }
    }

}