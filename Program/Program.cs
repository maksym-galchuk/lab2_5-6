// See https://aka.ms/new-console-template for more information
using Task1;

while (true) {
    Console.WriteLine("Enter 'exit' to exit the program.");
    Console.WriteLine("Enter the coordinates of the first point:");
    string input1 = Console.ReadLine();
    if (input1 == "exit") break;
    double[] coords1 = readCoordinates(input1);
    
    Console.WriteLine("Enter the coordinates of the second point:");
    string input2 = Console.ReadLine();
    if (input2 == "exit") break;
    double[] coords2 = readCoordinates(input2);
    
    Point<double> p1 = new Point<double>(coords1[0], coords1[1]);
    Point<double> p2 = new Point<double>(coords2[0], coords2[1]);
    Line<double> line;
    
    try {
        line = new Line<double>(p1, p2);
    } catch (ArgumentException e) {
        Console.WriteLine(e.Message + "\n");
        continue;
    }

    Console.WriteLine(line + "\n");

    while (true) {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Change the first point");
        Console.WriteLine("2. Change the second point");
        Console.WriteLine("3. To stop changing points, and create a new line");
        
        char option = Console.ReadKey().KeyChar;
        Console.WriteLine();

        string inputNew;
        double[] coordsNew;
        switch (option) {
            case '1':
                Console.WriteLine("Enter the coordinates of the first point:");
                inputNew = Console.ReadLine();
                coordsNew = readCoordinates(inputNew);
                try {
                    line.ChangeP1(new Point<double>(coordsNew[0], coordsNew[1]));
                } catch (ArgumentException e) {
                    Console.WriteLine(e.Message + "\n");
                    continue;
                }
                Console.WriteLine(line + "\n");
                break;
            
            case '2':
                Console.WriteLine("Enter the coordinates of the second point:");
                inputNew = Console.ReadLine();
                coordsNew = readCoordinates(inputNew);
                try {
                    line.ChangeP2(new Point<double>(coordsNew[0], coordsNew[1]));
                } catch (ArgumentException e) {
                    Console.WriteLine(e.Message + "\n");
                    continue;
                }
                Console.WriteLine(line + "\n");
                break;
            
            case '3':
                break;
            
            default:
                Console.WriteLine("Invalid option. Try again:");
                break;
        }
        
        if (option == '3') break;
    }
}


double[] readCoordinates(string input) {
    string[] coords = input.Split(" ");
    
    while (coords.Length != 2 || !double.TryParse(coords[0], out _) || !double.TryParse(coords[1], out _)) {
        Console.WriteLine("Invalid input. Try again:");
        input = Console.ReadLine();
        coords = input.Split(" ");
    }

    return new double[] { double.Parse(coords[0]), double.Parse(coords[1]) };
}