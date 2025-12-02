using System;

// 4.15: Computerization of Health Records (Revize)
class HealthProfile
{
    // Özellikler
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }

    public int BirthDay { get; set; }
    public int BirthMonth { get; set; }
    public int BirthYear { get; set; }

    public double HeightInInches { get; set; }
    public double WeightInPounds { get; set; }

    // Kurucu Metot
    public HealthProfile(string first, string last, string g,
                         int month, int day, int year,
                         double heightInch, double weightLb)
    {
        FirstName = first;
        LastName = last;
        Gender = g;

        BirthMonth = month;
        BirthDay = day;
        BirthYear = year;

        HeightInInches = heightInch;
        WeightInPounds = weightLb;
    }

    // Yaş Hesabı
    public int GetAge()
    {
        DateTime today = DateTime.Today;
        int age = today.Year - BirthYear;

        if (BirthdayStillComing(today))
            age--;

        return age;
    }

    // Yardımcı kontrol
    private bool BirthdayStillComing(DateTime today)
    {
        return today.Month < BirthMonth
               || (today.Month == BirthMonth && today.Day < BirthDay);
    }

    // Maksimum Kalp Atışı
    public int GetMaxHeartRate() => 220 - GetAge();

    // Hedef Kalp Atış Aralığı
    public string GetTargetHeartRateRange()
    {
        double max = GetMaxHeartRate();
        double low = max * 0.50;
        double high = max * 0.85;

        return $"{Math.Round(low)} - {Math.Round(high)} bpm";
    }

    // BMI
    public double GetBMI()
    {
        if (HeightInInches <= 0)
            return 0;

        return (WeightInPounds * 703) /
               (HeightInInches * HeightInInches);
    }
}

class HealthProfileTest
{
    static void Main()
    {
        Console.WriteLine("=== SAGLIK PROFILI ===\n");

        Console.Write("Ad: ");
        string first = Console.ReadLine();

        Console.Write("Soyad: ");
        string last = Console.ReadLine();

        Console.Write("Cinsiyet: ");
        string gen = Console.ReadLine();

        Console.Write("Dogum Yili: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Dogum Ayi (1-12): ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Dogum Gunu: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Boy (inch): ");
        double height = double.Parse(Console.ReadLine());

        Console.Write("Kilo (pound): ");
        double weight = double.Parse(Console.ReadLine());

        // Nesne oluşturma
        var hp = new HealthProfile(first, last, gen, month, day, year, height, weight);

        Console.WriteLine("\n--- RAPOR ---");
        Console.WriteLine($"Isim: {hp.FirstName} {hp.LastName}");
        Console.WriteLine($"Dogum Tarihi: {hp.BirthDay}/{hp.BirthMonth}/{hp.BirthYear}");
        Console.WriteLine($"Yas: {hp.GetAge()}");
        Console.WriteLine($"Boy: {hp.HeightInInches} inch");
        Console.WriteLine($"Kilo: {hp.WeightInPounds} lbs");

        Console.WriteLine(new string('-', 32));

        Console.WriteLine($"Maksimum Kalp Atisi: {hp.GetMaxHeartRate()} bpm");
        Console.WriteLine($"Hedef Aralik: {hp.GetTargetHeartRateRange()}");
        Console.WriteLine($"BMI: {hp.GetBMI():F1}");

        Console.WriteLine("\n--- BMI TABLOSU ---");
        Console.WriteLine("Zayif:          < 18.5");
        Console.WriteLine("Normal:         18.5 - 24.9");
        Console.WriteLine("Fazla Kilo:     25 - 29.9");
        Console.WriteLine("Obez:           30+");

        Console.WriteLine("\nDevam etmek icin bir tusa basin...");
        Console.ReadKey();
    }
}
