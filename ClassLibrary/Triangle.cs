using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Triangle : Shape2D
    {
        private float area;
        public override float Area { get => area; }

        private float circumference;
        public override float Circumference { get => circumference; }

        private Vector3 center;
        public override Vector3 Center { get => center; }

        private List<Vector2> points;
        public List<Vector2> Points { get => points; }

        //calculations for certain properties have been relegated to separate methods for readabilitys sake
        //values for p1-p3 are stored in property Points
        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.points = new List<Vector2>() { p1,p2,p3 };
            this.center = new Vector3(CalculateCentroid(), 0.0f);
            this.circumference = CalculateDistance(p1, p2) + CalculateDistance(p2, p3) + CalculateDistance(p3, p1);
            this.area = Math.Abs(CalculateArea());
        }

        private Vector2 CalculateCentroid()
        {
            Vector2 p1 = Points[0];
            Vector2 p2 = Points[1];
            Vector2 p3 = Points[2];

            float xresult = (float)(p1.X + p2.X + p3.X) / 3;
            float yresult = (float)(p1.Y + p2.Y + p3.Y) / 3;

            return new Vector2(xresult, yresult);
        }

        private float CalculateDistance(Vector2 point1, Vector2 point2)
        {
            return (float)Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));
        }

        private float CalculateArea()
        {
            Vector2 p1 = Points[0];
            Vector2 p2 = Points[1];
            Vector2 p3 = Points[2];

            var A = (p1.X * (p2.Y - p3.Y));
            var B = (p2.X * (p3.Y - p1.Y));
            var C = (p3.X * (p1.Y - p2.Y));

            // return (float)((p1.X * (p2.Y - p3.Y)) + (p2.X * (p3.Y) - p1.Y) + (p3.X * (p1.Y - p2.Y)) / 2);

            return (float)(A + B + C) / 2;
        }

        public override string ToString()
        {
            return $"triangle @({Center.X:f1}, {Center.Y:f1}): p1({Points[0].X:f1}, {Points[0].Y:f1}), p2({Points[1].X:f1}, {Points[1].Y:f1}), p3({Points[2].X:f1}, {Points[2].Y:f1})";             
        }
    }
}
