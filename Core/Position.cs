using System.Numerics;

namespace Core;

class Position
{
	public int x;
	public int y;

	public Position(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public Vector2 ToVector()
	{
		return new Vector2(x, y);
	}
}

class Dimension
{
	public int width;
	public int height;

	public Dimension(int width, int height)
	{
		this.width = width;
		this.height = height;
	}
}