using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Circle : Shape2D
    {
        private float area;
        public override float Area { get => area; }

        private float circumference;
        public override float Circumference { get => circumference; }

        private Vector3 center;
        public override Vector3 Center { get => center; }

        private float radius;
        public float Radius { get => radius; }
        public Circle(Vector2 center, float radius)
        {
            this.center = new Vector3(center, 0.0f);
            this.radius = radius;
            this.circumference = (float)(2 * Math.PI * radius);
            this.area = (float)(Math.PI * (radius*radius));
        }

        public override string ToString()
        {
            return $"circle @({Center.X:f1}, {Center.Y:f1}): r = {radius:f1}";
        }
    }
}
