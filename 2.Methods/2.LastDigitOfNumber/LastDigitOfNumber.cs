//Write a method that returns the last digit of a given integer as an English word. 
//Test the method with different input values. 
//Ensure you name the method properly.

using System;

class LastDigitOfNumber
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine(GetLastDigitAsWord(a));
    }

    static string GetLastDigitAsWord(int a)
    {
        switch (a % 10)
        {
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            case 0: return "zero";
            default:
                break;
        }
        return "fail";
    }
}