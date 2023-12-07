using System;

class AutoDrivingCarSimulation
{
    static void Main()
    {
        Console.WriteLine("Welcome to Tesla Auto Driving Car Simulation");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Please enter field size (width<space>height)");

        // 10 10
        // 1 2 N
        // FFRFFFRRLF

        string[] fieldSize = Console.ReadLine().Split(' ');
        int width = int.Parse(fieldSize[0]);
        int height = int.Parse(fieldSize[1]);

        //Console.WriteLine(int.Parse(fieldSize[0]));

        string[] initialPosition = Console.ReadLine().Split(' ');
        int x = int.Parse(initialPosition[0]);
        int y = int.Parse(initialPosition[1]);
        char direction = char.Parse(initialPosition[2]);

        

        string commands = Console.ReadLine();

        // Simulating the car movement
        Console.WriteLine(width);
        Console.WriteLine(height);
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine(direction);


        SimulateCar(width, height, x, y, direction, commands);
    }

    static void SimulateCar(int width, int height, int x, int y, char direction, string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'L':
                    direction = RotateLeft(direction);
                    break;
                case 'R':
                    direction = RotateRight(direction);
                    break;
                case 'F':
                    (int newX, int newY) = MoveForward(x, y, direction);
                    if (IsValidMove(newX, newY, width, height))
                    {
                        x = newX;
                        y = newY;
                    }
                    break;
            }
        }
        Console.WriteLine($"{x} {y} {direction}");
        Console.ReadLine();
    }

    static char RotateLeft(char currentDirection)
    {
        switch (currentDirection)
        {
            case 'N':
                return 'W';
            case 'E':
                return 'N';
            case 'S':
                return 'E';
            case 'W':
                return 'S';
            default:
                return currentDirection;
        }
    }

    static char RotateRight(char currentDirection)
    {
        switch (currentDirection)
        {
            case 'N':
                return 'E';
            case 'E':
                return 'S';
            case 'S':
                return 'W';
            case 'W':
                return 'N';
            default:
                return currentDirection;
        }
    }

    static (int, int) MoveForward(int x, int y, char direction)
    {
        switch (direction)
        {
            case 'N':
                return (x, y + 1);
            case 'E':
                return (x + 1, y);
            case 'S':
                return (x, y - 1);
            case 'W':
                return (x - 1, y);
            default:
                return (x, y);
        }
    }

    static bool IsValidMove(int x, int y, int width, int height)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}