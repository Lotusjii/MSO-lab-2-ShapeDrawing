using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeDrawing
{
    abstract class Converter
    {
        public abstract string Convert(List<Shape> shapes);
    }
}
