namespace SimpleConsole;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");
        WriteLine($"There are {args.Length} string values sent into this program");
        // If there are values sent into my Main method, I will display them here.
        if(args.Length > 0)
        {
            for(int index = 0; index < args.Length; index++)
            {
                WriteLine(args[index]);
            }
        }
        // Declare an array
        double[] myValues = new double[4];
        myValues[0] = 7.5;
        myValues[1] = 8.3;
        myValues[2] = 4.6;
        myValues[3] = 9.2;
        WriteLine(CalculateTotal(myValues));
        // TODO: Demo a method that you can call CalculateAverage(double[] numbers)
    } // end of Main()

    static double CalculateTotal(double[] numbers)
    {
        double total = 0;
        for(int i = 0; i < numbers.Length; i++)
            total += numbers[i];
        return total;
    }
}