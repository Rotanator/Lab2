using ClassLibrary;


//Creates and fills an array with random shapes

Shape[] shapesArray = new Shape[20];

for (int i = 0; i < shapesArray.Length; i++)
{
    shapesArray[i] = Shape.GenerateShape();
}

//Dictionary containing KVPs with a arbitriary string name as key and int value that increments 
//for each instance of that shape generated

Dictionary<string, int> shapeOccurenceCounter = new Dictionary<string, int>
{
    {"circle", 0},
    {"rectangle", 0},
    {"square", 0},
    {"triangle", 0},
    {"cuboid", 0},
    {"cube", 0 },
    {"sphere", 0}
};

//For triangles in array
float circumferenceTotal = 0;
//For all shapes in array
float areaTotal = 0;
//Compare all Shape3D shapes .Volume for greatest volume
float highestVolume = 0;
int highestVolumeIndex = 0;
Type highestVolumeShapeType = null;


//Loops through all 20 shapes in shapesArray
for (int i = 0; i < shapesArray.Length; i++)
{
    var currentShape = shapesArray[i];
    Type currentShapeType = currentShape.GetType();
    
    //Calls method that will increase one of the values in shapeOccurenceCounter
    //corresponding to the shape of currentShape
    IncrementShapeOccurence(currentShape);

    Console.WriteLine();
    Console.WriteLine($"{currentShapeType} #{i+1}");
    Console.WriteLine(shapesArray[i]);

    //If statement for finding the shape with the highest volume
    if (currentShape is Shape3D Shape3D)
    {
        Console.WriteLine($"Shape Volume: {Shape3D.Volume}");
        if (Shape3D.Volume > highestVolume)
        {
            highestVolume = Shape3D.Volume;
            highestVolumeIndex = i+1;
            highestVolumeShapeType = currentShapeType;
        }
    }

    areaTotal += currentShape.Area;
    Console.WriteLine($"Shape Area: {currentShape.Area}");
}

Console.WriteLine("\n-----");
Console.WriteLine($"Total circumference of all triangles: {circumferenceTotal} units");
Console.WriteLine($"Average area of any given shape: {areaTotal/shapesArray.Length} units");
Console.WriteLine($"{highestVolumeShapeType} (shape #{highestVolumeIndex}) has the highest volume of: {highestVolume} units");
Console.WriteLine("-----\n");

Console.WriteLine("OCCURENCE OF ALL SHAPES");

//Displays all KVPs in shapeOccurenceCounter
foreach (KeyValuePair<string, int> kvp in shapeOccurenceCounter)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

Console.WriteLine();

PrintMostOccuringShapes();







void IncrementShapeOccurence(Shape currentShape)
{
    switch (currentShape)
    {
        case Circle:
            shapeOccurenceCounter["circle"]++;
            break;
        case Rectangle:
            bool isSquare = (currentShape as Rectangle).IsSquare;
            if (isSquare) { shapeOccurenceCounter["square"]++; }
            else { shapeOccurenceCounter["rectangle"]++; }
            break;
        case Triangle:
            shapeOccurenceCounter["triangle"]++;
            // Add circumference of triangle to total circumferences
            circumferenceTotal += (currentShape as Triangle).Circumference;
            break;
        case Cuboid:
            bool isCube = (currentShape as Cuboid).IsCube;
            if (isCube) { shapeOccurenceCounter["cube"]++; }
            else { shapeOccurenceCounter["cuboid"]++; }
            break;
        case Sphere:
            shapeOccurenceCounter["sphere"]++;
            break;
    }
}

void PrintMostOccuringShapes()
{
    int maxValue = shapeOccurenceCounter.Values.Max();
    var keyValues = shapeOccurenceCounter.Where(kv => kv.Value == maxValue);
    Console.WriteLine("Most occuring shape(s)");
    foreach (KeyValuePair<string, int> kvp in keyValues)
    {
        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
    }
}






