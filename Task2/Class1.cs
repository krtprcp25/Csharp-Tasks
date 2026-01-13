using System;

public class Task2
{
    public static void Main()
    {
        // Row 0: Even numbers
        // Row 1: Odd numbers
        int[][] numberMatrix = new int[][]
        {
            new int[] { 2, 4, 6, 8, 10 },
            new int[] { 1, 3, 5, 7, 9 }
        };

        Console.WriteLine("The number matrix has been initialized.");

        // Extract digits per puzzle clues
        int digit1 = numberMatrix[1][3]; // Row 1, Index 3 => 7
        int digit2 = numberMatrix[0][0]; // Row 0, Index 0 => 2
        int digit3 = numberMatrix[1][4]; // Row 1, Index 4 => 9

        // Combine into the 3-digit key
        string finalKey = string.Concat(digit1, digit2, digit3);

        // Final output as the password/key
        Console.WriteLine("Password: " + finalKey);
    }
}