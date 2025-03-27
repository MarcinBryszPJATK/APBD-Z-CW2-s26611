using System;
using APBD_Z_CW2_s26611.Domain;
using APBD_Z_CW2_s26611.ENUMS;
using APBD_Z_CW2_s26611.Exceptions;

public class Program
{
    public static void Main()
    {
        // Tworzymy kontenerowiec (statek)
        ContainerShip ship1 = new ContainerShip(20, 10, 20000);
        
        // Tworzymy kilka kontenerów różnych typów
        // GasContainer: (height, weight, depth, maxLoadWeights, preasure)
        GasContainer gasContainer = new GasContainer(250, 3000, 100, 5000, 1.5);
        
        // LiquidContainer: (height, weight, depth, maxLoadWeights, cargoType)
        LiquidContainer liquidContainer = new LiquidContainer(200, 2800, 90, 4000, CargoType.NORMAL);
        
        // RefrigeratedContainer: (height, weight, depth, maxLoadWeights, productType)
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(220, 3200, 110, 4500, ProductType.MILK);
        
        // Testy metod na kontenerac
        // GasContainer: Ładowanie i rozładowanie ładunku.
        // Ładujemy 1000 kg – metoda LoadCargo z klasy bazowej.
        gasContainer.LoadCargo(1000);
        Console.WriteLine("GasContainer po załadowaniu 1000 kg:");
        Console.WriteLine(gasContainer);
        Console.WriteLine("");
        // Rozładowujemy 500 kg – metoda ClearCargo w GasContainer dodaje 5% ładunku po opróżnieniu.
        gasContainer.ClearCargo(500);
        Console.WriteLine("GasContainer po rozładowaniu 500 kg (plus 5% dodatku):");
        Console.WriteLine(gasContainer);
        Console.WriteLine("");
        // LiquidContainer: Ładowanie ładunku.
        try
        {
            // Ładujemy 300 kg ładunku normalnego – powinno się udać (limit to 90% z maxLoadWeights, czyli 3600 kg).
            liquidContainer.LoadCargo(300, CargoType.NORMAL);
            Console.WriteLine("LiquidContainer po załadowaniu 300 kg ładunku normalnego:");
            Console.WriteLine(liquidContainer);
            
            // Próba załadowania ładunku innego typu – powinno rzucić wyjątek.
            liquidContainer.LoadCargo(100, CargoType.DANGEROUS);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wyjątek przy ładowaniu w LiquidContainer: {ex.Message}");
        }
        Console.WriteLine("");
        // RefrigeratedContainer: Ładowanie ładunku i ustawianie temperatury.
        try
        {
            // Ładowanie ładunku – metoda LoadCargo korzysta z wstępnie zdefiniowanej masy dla MILK (np. 1500 kg).
            refrigeratedContainer.LoadCargo(ProductType.MILK);
            Console.WriteLine("RefrigeratedContainer po załadowaniu mleka:");
            Console.WriteLine(refrigeratedContainer);
            
            // Próba ustawienia temperatury poniżej dozwolonej (dla MILK minimalna to 19 stopni) – powinno rzucić wyjątek.
            refrigeratedContainer.Temperature = 15.0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wyjątek w RefrigeratedContainer: {ex.Message}");
        }
        Console.WriteLine("");
        // Dodawanie kontenerów do statku
        try
        {
            ship1.AddContainer(gasContainer);
            ship1.AddContainer(liquidContainer);
            ship1.AddContainer(refrigeratedContainer);
            Console.WriteLine("Dodano wszystkie kontenery do ship1.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wyjątek przy dodawaniu kontenerów do ship1: {ex.Message}");
        }
        Console.WriteLine("");
        Console.WriteLine("\nInformacje o statku (ship1):");
        Console.WriteLine(ship1);
        Console.WriteLine("Lista kontenerów na ship1:");
        foreach (var container in ship1.Containers)
        {
            Console.WriteLine(container);
        }
        Console.WriteLine("");
        // Usuwanie kontenera ze statku
        ship1.RemoveContainer(liquidContainer);
        Console.WriteLine("\nLista kontenerów na ship1 po usunięciu LiquidContainer:");
        foreach (var container in ship1.Containers)
        {
            Console.WriteLine(container);
        }
        
        // Przeniesienie kontenera między statkami
        ContainerShip ship2 = new ContainerShip(15, 5, 15000);
        // Przenosimy GasContainer z ship1 do ship2 (wykorzystując metodę SwitchShip)
        gasContainer.SwitchShip(ship2);
        
        Console.WriteLine("\nPo przeniesieniu GasContainer:");
        Console.WriteLine("Ship1 kontenery:");
        foreach (var container in ship1.Containers)
        {
            Console.WriteLine(container);
        }
        Console.WriteLine("Ship2 kontenery:");
        foreach (var container in ship2.Containers)
        {
            Console.WriteLine(container);
        }
    }
}
