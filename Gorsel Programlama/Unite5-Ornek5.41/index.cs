using System;

class WorldPopulationGrowth
{
    static void Main()
    {
        // 1. Güncel Verilerin Tanımlanması (Tahmini 2024-2025 Verileri)
        // Dünya nüfusu yaklaşık 8.2 Milyar
        double currentPopulation = 8200000000; 
        
        // Yıllık büyüme oranı yaklaşık %0.91 (veya 0.0091)
        // Not: Büyüme oranı yıllar geçtikçe azalmaktadır ancak soru 
        // bu oranın sabit kalacağı varsayımıyla (constant growth rate) çözüm istemiştir.
        double growthRate = 0.0091; 

        double initialPopulation = currentPopulation;
        int doubleYear = 0; // Nüfusun ikiye katlandığı yılı tutmak için
        bool doubled = false;

        Console.WriteLine("--- Dunya Nufus Artisi Hesaplayici (Gelecek 75 Yil) ---");
        Console.WriteLine($"Mevcut Nufus: {currentPopulation:N0}");
        Console.WriteLine($"Yillik Artis Orani: {growthRate:P2}");
        Console.WriteLine();

        // Tablo Başlıkları (Sütun hizalaması ile)
        // {0, -10}: Sola dayalı 10 karakter
        // {1, 25}: Sağa dayalı 25 karakter
        Console.WriteLine("{0, -10} {1, 25} {2, 25}", "Yil", "Tahmini Nufus", "Sayisal Artis");
        Console.WriteLine(new string('-', 65));

        // 2. 75 Yıllık Döngü
        for (int year = 1; year <= 75; year++)
        {
            // O yılki sayısal artış miktarı
            double populationIncrease = currentPopulation * growthRate;
            
            // Yıl sonundaki yeni nüfus
            currentPopulation += populationIncrease;

            // Sonuçları Yazdırma (F0 formatı: Ondalık basamak yok)
            Console.WriteLine("{0, -10} {1, 25:F0} {2, 25:F0}", 
                year, currentPopulation, populationIncrease);

            // 3. İkiye Katlanma Kontrolü
            if (!doubled && currentPopulation >= (initialPopulation * 2))
            {
                doubleYear = year;
                doubled = true;
            }
        }

        Console.WriteLine(new string('-', 65));
        
        // İkiye katlanma bilgisini göster
        if (doubled)
        {
            Console.WriteLine($"\nBU BUYUME ORANIYLA:");
            Console.WriteLine($"Nufus bugunku degerinin iki katina {doubleYear}. yilda ulasacaktir.");
        }
        else
        {
            Console.WriteLine($"\nBU BUYUME ORANIYLA:");
            Console.WriteLine("Nufus gelecek 75 yil icinde bugunku degerinin iki katina ulasmayacaktir.");
        }

        Console.WriteLine("\nCikmak icin bir tusa basin...");
        Console.Read();
    }
}
