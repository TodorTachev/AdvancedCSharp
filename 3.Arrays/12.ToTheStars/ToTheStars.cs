using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ToTheStars
{
    static string[] star1 = new string[3];
    static string[] star2 = new string[3];
    static string[] star3 = new string[3];

    static void Main()
    {
        star1 = Console.ReadLine().Split(new char[] { ' ' });
        star2 = Console.ReadLine().Split(new char[] { ' ' });
        star3 = Console.ReadLine().Split(new char[] { ' ' });
        string[] ship = Console.ReadLine().Split(new char[] { ' ' });
        int moves = int.Parse(Console.ReadLine());

        double shipPositionX = double.Parse(ship[0]);
        double shipPositionY = double.Parse(ship[1]);
        PrintPosition(shipPositionX, shipPositionY);

        for (int count = 0; count < moves; count++)
        {
            shipPositionY++;
            PrintPosition(shipPositionX, shipPositionY);
        }
    }
    static void PrintPosition(double shipPositionX, double shipPositionY)
    {
        if (((shipPositionX >= double.Parse(star1[1]) - 1) && (shipPositionX <= double.Parse(star1[1]) + 1)) &&
            ((shipPositionY >= double.Parse(star1[2]) - 1) && (shipPositionY <= double.Parse(star1[2]) + 1)))
        {
            Console.WriteLine(star1[0].ToLower());
        }
        else if (((shipPositionX >= double.Parse(star2[1]) - 1) && (shipPositionX <= double.Parse(star2[1]) + 1)) &&
                 ((shipPositionY >= double.Parse(star2[2]) - 1) && (shipPositionY <= double.Parse(star2[2]) + 1)))
        {
            Console.WriteLine(star2[0].ToLower());
        }
        else if (((shipPositionX >= double.Parse(star3[1]) - 1) && (shipPositionX <= double.Parse(star3[1]) + 1)) &&
                 ((shipPositionY >= double.Parse(star3[2]) - 1) && (shipPositionY <= double.Parse(star3[2]) + 1)))
        {
            Console.WriteLine(star3[0].ToLower());
        }
        else
        {
            Console.WriteLine("space");
        }
    }
}