using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


public class ShapeConverter : IOutputable
{
    public List<String> shapeStrings = new List<String>();
    public ShapeConverter()
    {

    }

    public virtual void StartShape(string brush, string fill) { }
    public virtual void DrawPolygon(Point[] points) { }
    public virtual void DrawEllipse(int cx, int cy, int r1, int r2) { }
    public virtual void EndFile() { }
}

