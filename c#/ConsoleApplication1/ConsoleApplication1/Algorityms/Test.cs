using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can use Console.WriteLine for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public static int solution(int X, int Y, int D)
    {

        int jumps = 0;
        while (X <= Y)
        {
            X +=D;
            jumps++;
        }
         

        return jumps;
    }

    public static void Main1(string[] args)
    {
        int j = solution(10, 85, 30);
        Console.WriteLine(j);
        Console.ReadKey();
    }
}