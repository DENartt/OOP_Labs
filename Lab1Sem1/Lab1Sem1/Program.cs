namespace Lab1Sem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a method for creating the polygon:");
            Console.WriteLine("1, enter data manually using the keyboard");
            Console.WriteLine("2, use a test set of points");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();
            Polygon polygon;

            switch (choice)
            {
                case "1":
                    polygon = new Polygon();
                    polygon.Input();
                    break;

                case "2":
                    Point2D[] testPoints =
                    {
                        new Point2D(0, 0), new Point2D(0, 4), new Point2D(2, 4), new Point2D(3, 0)
                    };
                    polygon = new Polygon(testPoints);
                    break;

                default:
                    Console.WriteLine("Invalid selection, creating default");
                    polygon = new Polygon();
                    polygon.Input();
                    break;
            }
            polygon.Output();
        }
    }
}
