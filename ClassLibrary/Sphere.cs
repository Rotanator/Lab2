using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Sphere : Shape3D
    {
        private float area;
        public override float Area { get => area; }

        private float volume;
        public override float Volume { get => volume; }

        private Vector3 center;
        public override Vector3 Center { get => center; }

        private float radius;
        public float Radius { get => radius; }

        public Sphere(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = radius;
            this.volume = (float)(4.18879 * radius * radius * radius);
            this.area = (float)(4*Math.PI* Math.Pow(radius, 2));
        }

        public override string ToString()
        {
            return $"sphere @({Center.X:f1}, {Center.Y:f1}, {Center.Z:f1}): r = {radius:f1}";
        }
    }
}
