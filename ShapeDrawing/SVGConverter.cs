using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;



public class SVGConverter : ShapeConverter, IOutputable
{
    public SVGConverter()
    {
        shapeStrings.Add("<?xml version=\"1.0\" standalone=\"no\"?><!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\"><svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");
    }

    public override void StartShape(string brush, string fill) 
    {
        base.StartShape(brush, fill);
    }
    public override void DrawPolygon(Point[] points) 
    {
        string str = "<polygon points=\" ";
        for (int i = 0; i < points.Length; i++)
        {
            string point = string.Concat(points[i].X.ToString(), "," ,points[i].Y.ToString());
            if (i < points.Length - 1)
                point = string.Concat(point, " ");
            str = string.Concat(str, point);
        }
        str = string.Concat(str, "\" style = \"fill:none;stroke:black;stroke-width:1\" /> ");
        shapeStrings.Add(str);
    }
    public override void DrawEllipse(int cx, int cy, int r1, int r2) 
    {
        string s = "<ellipse cx=\" {0} \" cy=\" {1} \" rx=\" {2} \" ry=\" {3} \" stroke-width=\"1\" fill=\"none\" stroke = \"black\" /> ";
        shapeStrings.Add(string.Format(s, cx + r1 / 2, cy + r2 / 2, r1 / 2, r2 / 2));
    }

    public override void EndFile()
    {
        shapeStrings.Add("</svg>");
    }
}

