using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


public interface IOutputable
{
    void StartShape(string brush, string fill);
    void DrawPolygon(Point[] points);
    void DrawEllipse(int cx, int cy, int r1, int r2);
    void EndFile();
}

