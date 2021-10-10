using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;



public class TikZConverter : ShapeConverter, IOutputable
{
    public TikZConverter()
    {

    }
    public override void StartShape(string brush, string fill)
    {
        base.StartShape(brush, fill);
    }
    public override void DrawPolygon(Point[] points) { }
    public override void DrawEllipse(int cx, int cy, int r1, int r2) { }
    public override void EndFile()
    {
        base.EndFile();
    }
}

