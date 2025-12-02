using System;

class AirlineReservationSystem
{
    static void Main()
    {
        // 10 koltuk: false = bos, true = dolu
        bool[] seatMap = new bool[10];
        int occupiedCount = 0;

        Console.WriteLine("=== Havayolu Rezervasyon Sistemi ===");

        // Ucak tamamen dolana kadar devam et
        while (occupiedCount < seatMap.Length)
        {
            Console.WriteLine("\nBirinci sinif (First Class) icin 1");
            Console.WriteLine("Ekonomi (Economy) icin 2 tuslayin.");
            Console.Write("Seciminiz: ");

            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
            {
                if (choice == 1) // First Class istegi
                {
                    if (!AssignFirstClassSeat(seatMap))
                    {
                        // First class dolu, ekonomi kontrolü
                        if (IsCabinFull(seatMap, 6, 10))
                        {
                            Console.WriteLine("Uzgunuz, ucaktaki tum koltuklar dolu. Bir sonraki ucus 3 saat sonra.");
                            break;
                        }

                        Console.Write("First Class dolu. Economy bolumune gecmek ister misiniz? (E/H): ");
                        string resp = Console.ReadLine().ToUpper();

                        if (resp == "E" || resp == "Y")
                        {
                            AssignEconomySeat(seatMap);
                        }
                        else
                        {
                            Console.WriteLine("Bir sonraki ucus 3 saat sonra.");
                        }
                    }
                }
                else // choice == 2, Economy istegi
                {
                    if (!AssignEconomySeat(seatMap))
                    {
                        // Economy dolu, first class kontrolü
                        if (IsCabinFull(seatMap, 1, 5))
                        {
                            Console.WriteLine("Uzgunuz, ucaktaki tum koltuklar dolu. Bir sonraki ucus 3 saat sonra.");
                            break;
                        }

                        Console.Write("Economy dolu. First Class bolumune gecmek ister misiniz? (E/H): ");
                        string resp = Console.ReadLine().ToUpper();

                        if (resp == "E" || resp == "Y")
                        {
                            AssignFirstClassSeat(seatMap);
                        }
                        else
                        {
                            Console.WriteLine("Bir sonraki ucus 3 saat sonra.");
                        }
                    }
                }

                // Dolu koltuk sayisini yeniden hesapla
                occupiedCount = CountOccupiedSeats(seatMap);
            }
            else
            {
                Console.WriteLine("Gecersiz giris. Lutfen 1 veya 2 giriniz.");
            }
        }

        if (occupiedCount == seatMap.Length)
        {
            Console.WriteLine("\nTum koltuklar rezerve edildi. Tesekkur ederiz.");
        }

        Console.WriteLine("\nCikmak icin Enter'a basin...");
        Console.ReadLine();
    }

    // First Class (1-5 → index 0-4)
    static bool AssignFirstClassSeat(bool[] seats)
    {
        for (int i = 0; i < 5; i++)
        {
            if (!seats[i])
            {
                seats[i] = true;
                PrintTicket(i + 1, "First Class");
                return true;
            }
        }
        return false;
    }

    // Economy (6-10 → index 5-9)
    static bool AssignEconomySeat(bool[] seats)
    {
        for (int i = 5; i < 10; i++)
        {
            if (!seats[i])
            {
                seats[i] = true;
                PrintTicket(i + 1, "Economy");
                return true;
            }
        }
        return false;
    }

    // Belirli koltuk araligi tamamen dolu mu? (startSeat & endSeat: 1-bazli, dahil)
    static bool IsCabinFull(bool[] seats, int startSeat, int endSeat)
    {
        for (int i = startSeat - 1; i < endSeat; i++)
        {
            if (!seats[i])
                return false;
        }
        return true;
    }

    // Doluluk sayisini hesapla
    static int CountOccupiedSeats(bool[] seats)
    {
        int count = 0;
        foreach (bool s in seats)
        {
            if (s) count++;
        }
        return count;
    }

    // Bilet/biniş kartı
    static void PrintTicket(int seatNumber, string cabin)
    {
        Console.WriteLine("\n*********************************");
        Console.WriteLine("*        BOARDING  PASS         *");
        Console.WriteLine($"* Koltuk No : {seatNumber,-3}             *");
        Console.WriteLine($"* Bolum     : {cabin,-14} *");
        Console.WriteLine("*********************************");
    }
}
