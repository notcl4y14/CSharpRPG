using System.Numerics;
using Content.Entities;
using Core;
using Raylib_cs;

class Program
{
	static int TileWidth = 16;
	static int TileHeight = 16;
	
	static Player player;
	static Camera2D camera;
	static World world;
	
	public static void Main()
	{
		int screenWidth = TileWidth * 40;
		int screenHeight = TileHeight * 30;

		Raylib.SetTargetFPS(60);

		Raylib.SetWindowState(ConfigFlags.ResizableWindow);
		Raylib.InitWindow(screenWidth, screenHeight, "CSharp RPG Engine");

		MessageBox.Text = "Hello World!";
		MessageBox.Show();

		player = new Player(0, 0);

		camera = new Camera2D();

		camera.Target = player.position.ToVector();
		camera.Offset = new Vector2(screenWidth / 2, screenHeight / 2);
		camera.Rotation = 0;
		camera.Zoom = 1;

		world = new World();
		world.Add(player);

		Sign sign = new Sign("\"A sign\"", 32, 32);
		world.Add(sign);

		while (!Raylib.WindowShouldClose())
		{
			Update();
			Draw();
		}

		Raylib.CloseWindow();
	}

	public static void Update()
	{
		// Update
		var dt = Raylib.GetFrameTime();

		world.CheckCollisionFor(player);

		var dirX = Raylib.IsKeyDown(KeyboardKey.Right) - Raylib.IsKeyDown(KeyboardKey.Left);
		var dirY = Raylib.IsKeyDown(KeyboardKey.Down) - Raylib.IsKeyDown(KeyboardKey.Up);

		if (MessageBox.visible)
		{
			dirX = 0;
			dirY = 0;

			if (Raylib.IsKeyDown(KeyboardKey.Z))
			{
				MessageBox.Close();
			}
		}

		player.Move((int)(dirX * 200 * dt), (int)(dirY * 200 * dt));
	}

	public static void Draw()
	{
		// Draw
		Raylib.BeginDrawing();

		Raylib.ClearBackground(Color.DarkGreen);

		Raylib.BeginMode2D(camera);

		// player.DrawHitbox();
		world.DrawEntities();

		Raylib.EndMode2D();

		// Raylib.DrawRectangle(0, 0, 100, 18, Color.Black);
		// Raylib.DrawFPS(0, 0);

		MessageBox.Draw();

		Raylib.EndDrawing();
	}
}