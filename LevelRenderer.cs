using System;
using Sense.Led;

namespace SokobanSensePi
{
    public static class LevelRenderer
    {
        public static readonly ILevelRenderer ConsoleRenderer = new ConsoleRenderer();
        public static readonly ILevelRenderer LEDMatrixRenderer = new LEDMatrixRenderer();
    }
    public interface ILevelRenderer
    {
        void Render(Level level);
        Direction Input();
        void Initialize();
        void CleanUp();
    }
    public class ConsoleRenderer : ILevelRenderer
    {
        public void Render(Level level)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            for (int y = 0; y < level.Height; y++)
            {
                var line = "";
                for (int x = 0; x < level.Width; x++)
                {
                    line += level[x,y].Render();
                }
                Console.WriteLine(line);
            }
        }
        public Direction Input()
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:  return Direction.Left;
                case ConsoleKey.UpArrow:    return Direction.Up;
                case ConsoleKey.RightArrow: return Direction.Right;
                case ConsoleKey.DownArrow:  return Direction.Down;
                default:                    return Direction.None;
            }
        }

        public void Initialize()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }

        public void CleanUp()
        {
        }
    }
    public class LEDMatrixRenderer : ILevelRenderer
    {
        private Pixels pixels;
        public void Render(Level level)
        {
            for (int y = 0; y < level.Height; y++)
            {
                for (int x = 0; x < level.Width; x++)
                {
                    pixels = pixels.Set(new CellColor(new Cell(y,x), level[x,y].GetColor()));
                }
                Sense.Led.LedMatrix.SetPixels(pixels);
            }
        }
        public Direction Input()
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:  return Direction.Left;
                case ConsoleKey.UpArrow:    return Direction.Up;
                case ConsoleKey.RightArrow: return Direction.Right;
                case ConsoleKey.DownArrow:  return Direction.Down;
                default:                    return Direction.None;
            }
        }

        public void Initialize()
        {
            pixels = Pixels.Empty;
            Sense.Led.LedMatrix.SetPixels(pixels);
        }

        public void CleanUp()
        {
            pixels = Pixels.Empty;
            Sense.Led.LedMatrix.SetPixels(pixels);
        }
    }
}
