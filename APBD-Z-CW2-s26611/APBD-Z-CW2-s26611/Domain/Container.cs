using System.Diagnostics;

namespace APBD_Z_CW2_s26611.Domain;
using APBD_Z_CW2_s26611.ENUMS;

public abstract class Container
{
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }
    public string Name { get; private set; }
    public double MaxLoadWeights { get; set; }
    public double ContainerCargoWeight { get; set; } = 0;

    public ContainerShip? Ship { get; set; } = null;

    private static Dictionary<string, int> serialCounters = new Dictionary<string, int>()
    {
        { "G", 1 },
        { "L", 1 },
        { "C", 1 }
    };

    protected abstract string ContainerExtension { get; }
    
    public Container(double height, double weight, double depth, double maxLoadWeights)
    {
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxLoadWeights = maxLoadWeights;

        Name = GenerateSerialNumber();
    }
    protected string GenerateSerialNumber()
    {
        string extension = ContainerExtension;
        int counter = serialCounters[extension];
        serialCounters[extension] = counter + 1;
        return $"KON-{extension}-{counter}";
    }

    public void LoadCargo(double cargoWeight)
    {
        if (ContainerCargoWeight + cargoWeight > MaxLoadWeights)
            throw new OverflowException("Masa ładunku przekracza dostępne miejsce załadunku");

        ContainerCargoWeight += cargoWeight;
    }

    public void ClearCargo(double cargoWeight)
    {
        if (cargoWeight > ContainerCargoWeight)
            throw new Exception("Próbujesz usunąć więcej ładunku niż jest dostępne w kontenerze");

        ContainerCargoWeight -= cargoWeight;
    }

    public override string ToString()
    {
        return $"Wysokosc: {Height}, Waga: {Weight}, Glebokosc: {Depth}, Nazwa: {Name}, Zaladowany ladunke: {ContainerCargoWeight}";
    }

    public void SwitchShip(ContainerShip destShitp)
    {
        int index = Ship.Containers.FindIndex(c => c.Name == Name);
        
        if (index != -1)
        {
            Ship.Containers.RemoveAt(index);
            destShitp.Containers.Add(this);
        }
        else
        {
            Console.WriteLine($"Kontener o nazwie {Name} nie został znaleziony");
        }
        
    }
}