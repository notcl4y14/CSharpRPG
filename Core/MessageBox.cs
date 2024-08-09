using Raylib_cs;

namespace Core;

class MessageBox
{
	public static string Text = "";
	public static string Name = "";
	public static bool visible = false;

	public static Color BackgroundColor = new Color(0, 50, 100, 255);
	public static Color TextColor = new Color(255, 255, 255, 255);

	public static int FontSize = 16;

	public static void Show()
	{
		visible = true;
	}

	public static void Close()
	{
		visible = false;
	}

	public static void Draw()
	{
		if (!visible)
		{
			return;
		}
		
		int screenWidth = Raylib.GetRenderWidth();
		int screenHeight = Raylib.GetRenderHeight();

		int interval = 10;
		int height = screenHeight / 4;

		int x = interval;
		int y = screenHeight - interval - height;
		int width = screenWidth - interval * 2;

		Raylib.DrawRectangle(x, y, width, height, BackgroundColor);
		Raylib.DrawText(Text, interval * 2, screenHeight - height, FontSize, TextColor);
	}
}