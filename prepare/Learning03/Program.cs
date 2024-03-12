using System;

class Program
{
    static void Main(string[] args)
    {
        // Setting values for f1 - Should be blank
        Fraction f = new Fraction();
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());

        // Setting values for f2 - 5 & 1
        f.SetTop(5);
        f.SetBottom(1);
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());

        // Setting values for f3 - 3 & 4
        f.SetTop(3);
        f.SetBottom(4);
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());

        // Setting values for f4 - 1 & 3
        f.SetTop(1);
        f.SetBottom(3);
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());

        // Setting values for f5 - 2 & 0
        //f.SetTop(2);
        //f.SetBottom(0);
        //Console.WriteLine(f.GetFractionString());
        //Console.WriteLine(f.GetDecimalValue());
    }
}