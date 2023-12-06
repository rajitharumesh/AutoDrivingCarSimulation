using System;

class AutoDrivingCarSimulation
{
    static void Main()
    {
        Console.WriteLine("Welcome to Tesla Auto Driving Car Simulation");
        Console.WriteLine("Please enter field size (width<space>height)");
        // reading inputs
        string[] fieldSize = Console.ReadLine().Split(' ');
        int width = int.Parse(fieldSize[0]);
        int height = int.Parse(fieldSize[1]);

        Console.WriteLine("Please enter Position with Direction (X<space>Y<space>D");
        string[] currentPosition = Console.ReadLine().Split(' ');
        int x = int.Parse(currentPosition[0]);
        int y = int.Parse(currentPosition[1]);
        char direction = char.Parse(currentPosition[2]);

        Console.WriteLine("Please enter Subsequent Commands");
        string commands = Console.ReadLine();
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
                    //TBD
                    break;
            }
        }
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

    static char MoveForward()
    {
        return 'N';
    }
}