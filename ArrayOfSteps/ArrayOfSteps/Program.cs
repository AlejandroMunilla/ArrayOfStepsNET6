// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static List<Vector2> listCoordinates = new List<Vector2>();
    static List<Vector2> listIntersections = new List<Vector2>();
    static Vector2 [] directions = new Vector2[4];
    static Vector2 currentPos = new Vector2(0, 0);
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        directions[0] = new Vector2(1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(-1, 0);
        directions[3] = new Vector2(0, 1);

        GetInput();
    }



    static void GetInput()
    {
        Console.WriteLine("Enter the integrers for array of steps. Max 9 integers. Only numbers/digits, as letters will be parsed to zeros. Enter OK or ok if you wish to finish entering integer");

        
        int[] answer = new int[9];
        for (int i = 0; i < answer.Length; i++)
        {
            string keyInput = Console.ReadLine();
            if (keyInput == "OK" || keyInput == "ok")
            {
                Console.WriteLine("I have got an OK");
                break;
            }
            else
            {
                answer[i] = SetNumber(keyInput);
              
                Console.WriteLine(answer);
            }           
        }

        Console.WriteLine("Execute segments____________________________________");
        ExecuteSegments(answer);

        Console.WriteLine("Intersections points________________________________");
        if (listIntersections.Count > 0)
        {
            for (int cnt = 0; cnt < listIntersections.Count; cnt++)
            {
                Console.WriteLine (listIntersections[cnt].X.ToString() + "/" + listIntersections[cnt].Y.ToString());        
            }
        }
        else
        {
            Console.WriteLine("Not intersections detected");
        }


        Console.WriteLine("Exit Application (Y)?");


            string inputKey = Console.ReadLine();
            if (inputKey == "Y" || inputKey == "N")
            {
                Console.WriteLine("I have got an OK");                
            }

    }

    
    static int SetNumber(string n)
    {
        int number = 0;
        bool success = int.TryParse(n, out number);
        if (success)
        {
            
            // if user input is negative
            if (number < 0)
            {
                // assign absolute version of user input
                number = Math.Abs(number);
            }
            Console.WriteLine($"Converted '{n}' to {number}.");
        }
        else
        {
            Console.WriteLine($"Attempted conversion of '{n ?? "<null>"}' failed.");
        }

        return number;
    }

    static void ExecuteSegments (int [] intArray)
    {
        currentPos = new Vector2(0, 0);
        listCoordinates.Clear();

        int directionIndex = 0;
        for (int cnt = 0; cnt < intArray.Length; cnt++)
        {
            if (directionIndex > 3)
            {
                directionIndex = 0;
            }

            for (int i = 0; i < intArray[cnt]; i++)
            {
                Vector2 newVector = new Vector2(currentPos.X + directions[directionIndex].X, currentPos.Y + directions[directionIndex].Y);
                Console.WriteLine(newVector.X + "/" + newVector.Y);
                currentPos = newVector;
                if (listCoordinates.Contains(currentPos) == true)
                {
                    listIntersections.Add(currentPos);

                }
                else
                {
                    listCoordinates.Add(currentPos);
                }
            }

            directionIndex++;
        }
    }
}





