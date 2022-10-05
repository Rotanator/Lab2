using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ClassLibrary
{
    public class Rectangle : Shape2D
    {
        private float area;
        public override float Area { get => area; }

        private float circumference;
        public override float Circumference { get => circumference; }

        private Vector3 center;
        public override Vector3 Center { get => center; }

        private float width;
        public float Width { get => width; }

        private float height;
        public float Height { get => height; }

        public Rectangle(Vector2 center, Vector2 size)
        {
            this.center = new Vector3(center, 0.0f);
            this.width = size.X;
            this.height = size.Y;
            this.area = (float)size.X * size.Y;
            this.circumference = (float)(size.X + size.Y) * 2;
        }

        //this overload is for specifically instanciating a square, since all sides will have the same float value "width"
        //property IsSquare can still be true if size.x and .y in previous constructor are the same value
        public Rectangle(Vector2 center, float width)
        {
            this.center = new Vector3(center, 0.0f);
            this.width = width;
            this.height = width;
            this.area = (float)width*width;
            this.circumference = (float)width*4;
        }

        public bool IsSquare
        {
            get 
            {
                if (Width == Height) { return true; } else { return false; }
            }
        }

        public override string ToString()
        {
            if (IsSquare)
            {
                return $"square @({Center.X:f1}, {Center.Y:f1}): w = {this.Width:f1}";
            } else
            {
                return $"rectangle @({Center.X:f1}, {Center.Y:f1}): w = {this.Width:f1}, h = {this.Height:f1}";
            }
        }
    }
}
