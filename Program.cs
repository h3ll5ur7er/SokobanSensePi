

namespace SokobanSensePi
{
    class Program
    {
        static void Main(string[] args)
        {
            var level = LevelParser.Parse();
            var renderer = LevelRenderer.ConsoleRenderer;
            // var renderer = LevelRenderer.LEDMatrixRenderer;
            var game = new Sokoban(level, renderer);
            while (true) // TODO: While game is not finished
            {
                game.Step();
            }
        }
    }
}
