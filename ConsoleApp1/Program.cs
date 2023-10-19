using GridSystem.src;
using GridSystem.src.GUI;
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
            Texture2D tex = GUI_Texture2D.OpenTexture("Revolver cocked New.png");
            Raylib.SetTargetFPS(60);
            var grid = new Grid(2,2, GridRenderType.Compact);


            grid.AddTexture2D(tex, Color.WHITE);
            grid.AddLabel("Test ", 30, Color.RED);
            grid.AddLabel("Test Text 2", 30, Color.BLACK);
            grid.AddLabel("Test Text 2", 30, Color.BLACK);
            grid.AddLabel("Test Text 2", 30, Color.BLACK);
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                grid.Draw();
                //Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);
                //Raylib.DrawText($"FPS: {Raylib.GetFPS()}", 122, 48, 20, Color.BLACK);
                //Raylib.DrawTexture(tex, 0, 0, Color.WHITE);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}