using System;

class GlobalWarmingTrivia
{
    static void Main()
    {
        const int totalQuestions = 5;
        int score = 0;

        Console.WriteLine("=== Kuresel Isinma Bilgi Testi ===");
        Console.WriteLine("Her soru icin 1, 2, 3 veya 4 giriniz.\n");

        // Soru 1
        Console.WriteLine("1) Asagidakilerden hangisi baslica sera gazlarindan biridir?");
        Console.WriteLine("1) Azot (Nitrogen)");
        Console.WriteLine("2) Oksijen (Oxygen)");
        Console.WriteLine("3) Karbondioksit (Carbon Dioxide)"); // doğru
        Console.WriteLine("4) Argon");
        if (ReadChoice() == 3) score++;

        // Soru 2
        Console.WriteLine("\n2) 1997'de sera gazlarini azaltmayi hedefleyen hangi uluslararasi anlasma imzalanmistir?");
        Console.WriteLine("1) Paris Anlasmasi");
        Console.WriteLine("2) Kyoto Protokolu"); // doğru
        Console.WriteLine("3) Montreal Protokolu");
        Console.WriteLine("4) Cenevre Sozlesmesi");
        if (ReadChoice() == 2) score++;

        // Soru 3
        Console.WriteLine("\n3) IPCC'ye gore son onyillardaki kuresel isinmanin baskin nedeni nedir?");
        Console.WriteLine("1) Gunes lekeleri ve aktivitesi");
        Console.WriteLine("2) Volkanik patlamalar");
        Console.WriteLine("3) Insan kaynakli (antropojenik) etkiler"); // doğru
        Console.WriteLine("4) Dunyanin yorbunge degisiklikleri");
        if (ReadChoice() == 3) score++;

        // Soru 4
        Console.WriteLine("\n4) Kuresel isinma skeptiklerinin sik kullandigi dogal aciklamalardan biri hangisidir?");
        Console.WriteLine("1) CO2'nin sera gazi olmamasi");
        Console.WriteLine("2) Gezegenin aslinda sogumakta olmasi");
        Console.WriteLine("3) Iklim degisiminin gunes donguleri ve dogal yorbunge degisikliklerinden kaynaklanmasi"); // doğru (arguman)
        Console.WriteLine("4) Deniz seviyelerinin dusmesi");
        if (ReadChoice() == 3) score++;

        // Soru 5
        Console.WriteLine("\n5) Kuresel isinma devam ederse en olasi sonuc hangisidir?");
        Console.WriteLine("1) Kutup buz tabakalarinin genislemesi");
        Console.WriteLine("2) Asiri hava olaylarinin azalmasi");
        Console.WriteLine("3) Ortalama deniz seviyelerinin yukselmesi"); // doğru
        Console.WriteLine("4) Okyanus asitliginin degismemesi");
        if (ReadChoice() == 3) score++;

        // Sonuç
        Console.WriteLine($"\nTest tamamlandi. {totalQuestions} sorudan {score} dogru yaptiniz.");

        switch (score)
        {
            case 5:
                Console.WriteLine("Sonuc: Mukemmel! (Excellent)");
                break;

            case 4:
                Console.WriteLine("Sonuc: Cok iyi, konuya hakimsiniz. (Very good)");
                break;

            default:
                Console.WriteLine("Sonuc: Kuresel isinma konusunda biraz daha calisman gerekiyor.");
                Console.WriteLine("\nBakabilecegin bazi kaynaklar:");
                Console.WriteLine("- https://climate.nasa.gov/");
                Console.WriteLine("- https://www.ipcc.ch/");
                Console.WriteLine("- https://skepticalscience.com/");
                break;
        }

        Console.WriteLine("\nKapatmak icin bir tusa basin...");
        Console.ReadKey(true);
    }

    // Kullanıcıdan 1-4 arası geçerli seçenek okur
    static int ReadChoice()
    {
        int answer;
        do
        {
            Console.Write("Cevabiniz (1-4): ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out answer) && answer >= 1 && answer <= 4)
            {
                return answer;
            }

            Console.WriteLine("Gecersiz giris. Lutfen 1, 2, 3 veya 4 giriniz.");
        } while (true);
    }
}
