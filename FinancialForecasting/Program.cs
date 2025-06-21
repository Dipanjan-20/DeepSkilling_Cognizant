using System;

class Program
{
    static void Main(string[] args)
    {
        double initialValue = 10000;   // Example: Rs. 10000
        double growthRate = 2.5;     // 2.5% growth per period
        int periods = 5;              // Predict for 5 periods

        double futureValueBasic = ForecastRecursive(initialValue, growthRate, periods);
        Console.WriteLine($"Future Value (basic recursion) after {periods} periods: {futureValueBasic:F2}");

        double futureValueOptimized = ForecastOptimizedRecursive(initialValue, growthRate, periods);
        Console.WriteLine($"Future Value (optimized recursion) after {periods} periods: {futureValueOptimized:F2}");
    }

    // Basic recursive method
    static double ForecastRecursive(double initialValue, double growthRate, int periods)
    {
        if (periods == 0)
            return initialValue;

        return ForecastRecursive(initialValue, growthRate, periods - 1) * (1 + growthRate);
    }

    //  Optimized recursive method 
    static double ForecastOptimizedRecursive(double initialValue, double growthRate, int periods)
    {
        return initialValue * PowerRecursive(1 + growthRate, periods);
    }

    static double PowerRecursive(double baseValue, int exponent)
    {
        if (exponent == 0)
            return 1;

        if (exponent % 2 == 0)
        {
            double halfPower = PowerRecursive(baseValue, exponent / 2);
            return halfPower * halfPower;
        }
        else
        {
            return baseValue * PowerRecursive(baseValue, exponent - 1);
        }
    }
}
