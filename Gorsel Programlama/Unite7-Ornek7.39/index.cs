using System;

class MultiplicationTutor
{
    // Rastgele sayı üretici
    private static readonly Random rng = new Random();

    static void Main()
    {
        Console.WriteLine("=== Multiplication Practice ===");
        Console.WriteLine("(Programdan cikmak icin Ctrl + C)\n");

        // Sürekli yeni sorular üret
        while (true)
        {
            AskNewQuestion();
        }
    }

    // Yeni bir soru oluşturan metot
    static void AskNewQuestion()
    {
        int a = rng.Next(1, 10);
        int b = rng.Next(1, 10);
        int correct = a * b;

        PrintQuestion(a, b);

        while (true)
        {
            var input = Console.ReadLine();

            if (int.TryParse(input, out int answer))
            {
                if (answer == correct)
                {
                    Console.WriteLine("Nice work!\n");
                    return; // Main'e dön, yeni soruya geç
                }
                else
                {
                    Console.WriteLine("Incorrect. Try once more.");
                }
            }
            else
            {
                Console.WriteLine("Lutfen bir sayi giriniz.");
            }

            // Yanlış olduğunda soruyu tekrar göster
            PrintQuestion(a, b);
        }
    }

    // Soru yazdırma metodu
    static void PrintQuestion(int x, int y)
    {
        Console.Write($"What is {x} × {y}? ");
    }
}
