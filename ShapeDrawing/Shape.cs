using System.Drawing;

public abstract class Shape
{

	public Shape()
	{
	}

    public abstract void Draw(IOutputable Canvas);
	
}