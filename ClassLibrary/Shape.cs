global using System.Numerics;

namespace ClassLibrary
{
    public abstract class Shape
    {
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }
        public static Shape GenerateShape()
        {
            Random rand = new Random();
            Vector3 position = new Vector3(rand.Next(-20, 20), rand.Next(-20, 20), rand.Next(-20, 20));

            return InstantiateShape(position);
        }

        public static Shape GenerateShape(Vector3 position)
        {
            //overload provides a center pos. as an argument
            //returns a randomly generated shape with provided center pos.

            return InstantiateShape(position);   
        }

        //InstantiateShape(Vector3 centerV3) can only be accessed from this abstraction.
        private static Shape InstantiateShape(Vector3 centerV3)
        {
            //Handles the logic for actually generating the shape to prevent code reuse.

            Random rand = new Random();

            Vector2 centerV2 = new Vector2(centerV3.X, centerV3.Y);

            
            //randomise switch case expression to return a randomly generated shape 
            int randomiseShape = rand.Next(0, 7);
            switch (randomiseShape)
            {
                case 0:
                    Shape newCircle = new Circle(centerV2, (float)rand.Next(2, 10));
                    return newCircle;
                case 1:
                    Shape newRectangle = new Rectangle(centerV2, new Vector2(rand.Next(2, 20), rand.Next(2, 20)));
                    return newRectangle;
                case 2:
                    Shape newSquare = new Rectangle(centerV2, (float)rand.Next(2, 20));
                    return newSquare;
                case 3:
                    //only randomises 2/3 points in the triangle
                    Vector2 p1 = new Vector2(rand.Next(-20, 20), rand.Next(-20, 20));
                    Vector2 p2 = new Vector2(rand.Next(-20, 20), rand.Next(-20, 20));

                    //third point is calculated based on the center
                    //(center is either random or pre-provided depending on which overload executes this method)
                    float p3x = (3 * centerV2.X) - (p1.X + p2.X);
                    float p3y = (3 * centerV2.Y) - (p1.Y + p2.Y);
                    Vector2 p3 = new Vector2(p3x, p3y);

                    Shape newTriangle = new Triangle(p1, p2, p3);
                    return newTriangle;
                case 4:
                    Shape newCuboid = new Cuboid(centerV3, new Vector3(rand.Next(2, 20), rand.Next(2, 20), rand.Next(2, 20)));
                    return newCuboid;
                case 5:
                    Shape newCube = new Cuboid(centerV3, (float)rand.Next(2, 20));
                    return newCube;
                case 6:
                    Shape newSphere = new Sphere(centerV3, (float)rand.Next(2, 10));
                    return newSphere;
                default:
                    return new Circle(Vector2.Zero, 0.0f);
            }
        }

    }
}