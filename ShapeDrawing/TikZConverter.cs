using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

public class TikZConverter : ShapeConverter, IOutputable
{
    public TikZConverter()
    {
        shapeStrings.Add("\\documentclass{article}\n\\usepackage[utf8]{inputenc}\n\\usepackage{tikz}\n\\begin{document}\n\\begin{tikzpicture}\n");
    }
    public override void StartShape(string brush, string fill)
    {
        base.StartShape(brush, fill);
    }
    public override void DrawPolygon(Point[] points)
    {
        string str = "\\draw ";
        for (int i = 0; i < points.Length; i++)
        {
            float px = points[i].X;
            float py = points[i].Y;
            string point = string.Concat("(", Periodinator(px / 20), ",", Periodinator(-py / 20), ")", " -- ");
            str = string.Concat(str, point);
        }
        str = string.Concat(str, "cycle;");
        shapeStrings.Add(str);
    }
    public override void DrawEllipse(int cx, int cy, int r1, int r2)
    {
        float cxx = cx;
        float cyy = cy;
        float r11 = r1;
        float r22 = r2;
        string st = "\\draw ({0},{1}) ellipse ({2}cm and {3}cm);";
        shapeStrings.Add(string.Format(st, Periodinator((cxx + r11 / 2) / 20), Periodinator(-(cyy + r22 / 2) / 20), Periodinator(r11 / 40), Periodinator(r22 / 40)));
    }

    public override void EndFile()
    {
        shapeStrings.Add("\\end{tikzpicture}\n\\end{document}");
    }


    private string Periodinator(float x)
    {
        return x.ToString().Replace(',','.');
    }
}

