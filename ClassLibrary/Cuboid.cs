using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Cuboid : Shape3D
    {
        private float area;
        public override float Area { get => area; }

        private float volume;
        public override float Volume { get => volume; }

        private Vector3 center;
        public override Vector3 Center { get => center; }

        private float width;
        public float Width { get => width; }

        private float height;
        public float Height { get => height; }

        private float length;
        public float Length { get => length; }

        public Cuboid(Vector3 center, Vector3 size)
        {
            this.center = center;

            this.width = size.X;
            this.height = size.Y;
            this.length = size.Z;

            this.volume = Length * Height * Width;
            this.area = 2 * ((Length * Width) + (Width * Height) + (Height * Length));

        }
        public Cuboid(Vector3 center, float width)
        {
            this.center = center;

            this.width = width;
            this.height = width;
            this.length = width;

            this.volume = (float)Math.Pow(width, 3);
            this.area = 6 * (float)Math.Pow(width, 2);
        }

        public bool IsCube
        {
            get
            {
                //Length == Width == Height
                if (Length == Width && Width == Height)
                {
                    return true;
                } else { return false; }
            }
        }

        public override string ToString()
        {
            if (IsCube)
            {
                return $"cube @({Center.X:f1}, {Center.Y:f1}, {Center.Z:f1}): w = {this.Width:f1}";
            }
            else
            {
                return $"cuboid @({Center.X:f1}, {Center.Y:f1}, {Center.Z:f1}): w = {this.Width:f1}, h = {this.Height:f1}, l = {this.Length:f1}";
            }
        }
    }
}
