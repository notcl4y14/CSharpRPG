using Raylib_cs;

namespace Core;

abstract class Entity
{
	public Position position = new Position(0, 0);
	public Dimension dimension = new Dimension(0, 0);

	public List<Entity> collisions = [];

	public void Move(int x, int y)
	{
		position.x += x;
		position.y += y;
	}
	public void MoveTo(int x, int y)
	{
		position.x = x;
		position.y = y;
	}

	public bool Overlaps(Entity other)
	{
		return position.x < other.position.x + other.dimension.width &&
		       other.position.x < position.x + dimension.width &&
			   position.y < other.position.y + other.dimension.height &&
			   other.position.y < position.y + dimension.height;
	}

	public virtual void OnOverlap(Entity other)
	{
		return;
	}

	public virtual void Draw()
	{
		DrawHitbox();
	}

	public void DrawHitbox()
	{
		Raylib.DrawRectangleLines(position.x, position.y, dimension.width, dimension.height, Color.White);
	}
}