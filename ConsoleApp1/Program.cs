using ConsoleApp1.src;
using Raylib_cs;
namespace HelloWorld
{
    static class Program
    {

        public static int WIDTH = 800;
        public static int HEIGHT = 480;

        public static void Main()
        {
            Raylib.InitWindow(WIDTH, HEIGHT, "Hello World");
            Texture2D tex = Raylib.LoadTexture("D:\\Other Projects\\RayLib\\Example Project\\ExampleProject\\RayLib-GridSystem\\ConsoleApp1\\res\\sprites\\Revolver cocked New.png");
            Raylib.SetTargetFPS(60);
            var gridSystem = new GridSystem(2,2);

            //gridSystem.AddLabel("My name is kiaro capo", 40, Color.BLACK);
            gridSystem.AddTexture2D(tex, Color.WHITE);
            gridSystem.AddLabel("Karandeep", 30, Color.BLACK);
            gridSystem.AddLabel("Singh", 30, Color.BLACK);
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                gridSystem.Draw();
                //Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);
                //Raylib.DrawText($"FPS: {Raylib.GetFPS()}", 122, 48, 20, Color.BLACK);
                //Raylib.DrawTexture(tex, 0, 0, Color.WHITE);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}