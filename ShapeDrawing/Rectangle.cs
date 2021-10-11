using System.Drawing;

class Rectangle : Shape
{

    private int x;
	private int y;
	private int width;
	private int height;

    public Rectangle(int x, int y, int width, int height)
    {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
    }
    
	public override void Draw(IOutputable Canvas)
    {
		Point[] points = new Point[] { new Point(x, y), new Point(x + width, y), new Point(x + width, y + height), new Point(x, y + height)};
		Canvas.StartShape("1", "black");
		Canvas.DrawPolygon(points);
    }
}

