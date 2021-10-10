using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


class Drawdapter : IOutputable
{
    Graphics graphics;
    Pen pen;

    public Drawdapter (Graphics graph)
    {
        graphics = graph;
    }
    public void DrawEllipse(int cx, int cy, int r1, int r2)
    {
        graphics.DrawEllipse(pen, cx, cy, r1, r2);
    }

    public void DrawPolygon(Point[] points)
    {
        graphics.DrawPolygon(pen, points);
    }


    public void StartShape(string brush, string fill)
    {
        pen = new Pen(Color.FromName(fill), float.Parse(brush));
    }

    public void EndFile()
    {

    }
}

