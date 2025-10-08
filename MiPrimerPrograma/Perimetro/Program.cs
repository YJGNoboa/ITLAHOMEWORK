int sidesPolygon;
double sidesSizes;
double perimeter;

Console.WriteLine("How many sides does the polygon have?");
sidesPolygon = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("How many size one sides");
sidesSizes = Convert.ToDouble(Console.ReadLine());

perimeter = sidesSizes * sidesPolygon;

Console.WriteLine(perimeter);   


