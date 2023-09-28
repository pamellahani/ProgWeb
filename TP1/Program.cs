// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Rectangle rectangle = new Rectangle(10, 20);
// Console.WriteLine(rectangle.GetPerimeter());
// Console.WriteLine(rectangle.GetArea());

// Square square = new Square(10);
// Console.WriteLine(square.GetPerimeter());
// Console.WriteLine(square.GetArea());

var list = new List<IShape>
{
    new Rectangle(3, 2),
    new Square(5),
    new Rectangle(10, 20),
    new Rectangle(100, 20)
};

foreach (var shape in list)
{
    shape.Print(); 
}