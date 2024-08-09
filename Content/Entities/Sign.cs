using Core;

namespace Content.Entities;

class Sign : Entity
{
	public string Text;

	public Sign(string text, int x, int y)
	{
		Text = text;
		position = new Position(x, y);
		dimension = new Dimension(16, 16);
	}
}