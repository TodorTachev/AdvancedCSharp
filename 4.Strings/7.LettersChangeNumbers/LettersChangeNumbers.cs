//This problem is from the Java Basics exam (8 February 2015). 
//https://judge.softuni.bg/Contests/Practice/Index/69#1 - gyrmi

using System;

class LettersChangeNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputArr = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        double sum = 0;

        while (true)
        {
            if (inputArr.Length < 1 || inputArr.Length > 10)
            {
                break;
            }

            double calc;
            for (int index = 0; index < inputArr.Length; index++)
            {
                calc = Calc(inputArr[index]);
                if (calc < 0)
                {
                    break;
                }
                else
                {
                    sum += calc;
                }
            }
            Console.WriteLine("{0:0.00}", sum);
            break;
        }
    }

    static double Calc(string nakovString)
    {
        char firstLetter = Convert.ToChar(nakovString.Substring(0, 1));
        char lastLetter = Convert.ToChar(nakovString.Substring(nakovString.Length - 1, 1));
        double number = Convert.ToDouble(nakovString.Substring(1, nakovString.Length - 2));

        if (number < 1 || number > Int32.MaxValue)
        {
            return -1;
        }

        if (char.IsUpper(firstLetter))
        {
            number = number / ((double)firstLetter % 32);
        }
        else
        {
            number = number * ((double)firstLetter % 32);
        }

        if (char.IsUpper(lastLetter))
        {
            number = number - ((double)lastLetter % 32);
        }
        else
        {
            number = number + ((double)lastLetter % 32);
        }
        return number;
    }
}