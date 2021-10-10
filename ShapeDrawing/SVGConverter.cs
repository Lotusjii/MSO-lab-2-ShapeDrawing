using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeDrawing
{
    class SVGConverter : Converter
    {
        public override string Convert(List<Shape> shapes)
        {
            foreach (Shape shape in shapes)
            {
                switch (shape)
                {
                    case Circle:
                        
                        break;
                    case Rectangle:
                        break;
                    case Star:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
