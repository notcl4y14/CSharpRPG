using Core;

namespace Content.Entities;

class Player : Entity
{
	public Player(int x, int y)
	{
		position = new Position(x, y);
		dimension = new Dimension(16, 16);
	}

    public override void OnOverlap(Entity other)
    {
        if (other is Sign)
		{
			var sign = (Sign)other;
			// MessageBox.Text = "\"A sign\"";
			MessageBox.Text = sign.Text;
			MessageBox.Show();
		}
    }
}