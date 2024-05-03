using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurGame2k.Blocks
{
    public class TetrisBlock
    {
        public Polygon Polygon { get; private set; }
        public Point Position { get; set; }

        public TetrisBlock(double size, Brush color)
        {
            Polygon = new Polygon();
            Polygon.Points = new PointCollection
            {
                new Point(0, 0),
                new Point(size, 0),
                new Point(size, size),
                new Point(0, size)
            };
            Polygon.Fill = color;
            Polygon.Stroke = Brushes.Black;
            Polygon.StrokeThickness = 1;
        }
    }
}
