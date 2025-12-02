using System;

class BodyMassIndexCalculator
{
    static void Main()
    {
        Console.WriteLine("--- Body Mass Index (BMI) Calculator ---");
        Console.WriteLine("Reference: Exercise 1.27 (Research & Test Drive)\n");

        Console.Write("Enter your weight in pounds: ");
        double weightInPounds = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter your height in inches: ");
        double heightInInches = Convert.ToDouble(Console.ReadLine());

        // BMI artık ayrı bir metotta hesaplanıyor
        double bmi = CalculateBmi(weightInPounds, heightInInches);

        Console.WriteLine($"\nYour Body Mass Index (BMI): {bmi:F1}");

        Console.WriteLine("\n--- BMI VALUES ---");
        Console.WriteLine("Underweight:  less than 18.5");
        Console.WriteLine("Normal:       between 18.5 and 24.9");
        Console.WriteLine("Overweight:   between 25 and 29.9");
        Console.WriteLine("Obese:        30 or greater");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static double CalculateBmi(double weight, double height)
    {
        return (weight * 703) / (height * height);
    }
}
