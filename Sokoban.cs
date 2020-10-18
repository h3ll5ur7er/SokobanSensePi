using System;
using System.Drawing;

namespace SokobanSensePi
{
    public class Sokoban
    {
        public Level Level { get; set; }
        public ILevelRenderer Renderer { get; }
        public Point PlayerPosition { get; }

        public Sokoban(Level level, ILevelRenderer renderer)
        {
            Level = level;
            Renderer = renderer;
            renderer.Initialize();
        }
        public void Step()
        {
            Renderer.Render(Level);
            var direction = Renderer.Input();
            Level.TryMoveTo(direction);
            //TODO:Check game state
        }
    }
}