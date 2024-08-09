namespace Core;

class World
{
	private List<Entity> space;

	public World()
	{
		space = new List<Entity>();
	}

	public void Add(Entity entity)
	{
		space.Add(entity);
	}

	public void Destroy(Entity entity)
	{
		space.Remove(entity);
	}

	public void Clear()
	{
		space = [];
	}

	public void CheckCollisionFor(Entity entity1)
	{
		foreach (Entity entity2 in space)
		{
			if (entity1 == entity2)
			{
				continue;
			}

			var overlaps = entity1.Overlaps(entity2);
			var hasOverlap = entity1.collisions.Contains(entity2);

			if (overlaps && !hasOverlap)
			{
				entity1.collisions.Add(entity2);
				entity1.OnOverlap(entity2);
			}
			else if (!overlaps && hasOverlap)
			{
				entity1.collisions.Remove(entity2);
			}
		}
	}

	public void DrawEntities()
	{
		foreach (var entity in space)
		{
			entity.Draw();
		}
	}
}