public abstract class AShapeSide : IShape
{
    public double Longueur { get; set; }
    public double Largeur { get; set; }

    public double GetArea(){
        return Longueur*Largeur; 
    } 

    public double GetPerimeter(){
        return (Longueur+Largeur)*2; 
    }

    public void Print(){
    Console.WriteLine(Longueur); 
    Console.WriteLine(Largeur); 
    var horizontalLine = new string('-', (int)Longueur);
    var verticalLine = "|" + new string(' ', (int)Longueur-2) + "|";
    var lines = Enumerable.Repeat(horizontalLine,1).Concat(Enumerable.Repeat(verticalLine, (int)Largeur)).Concat(Enumerable.Repeat(horizontalLine,1));
    Console.WriteLine(string.Join("\n", lines));
    Console.WriteLine("\n"); 
    }

}