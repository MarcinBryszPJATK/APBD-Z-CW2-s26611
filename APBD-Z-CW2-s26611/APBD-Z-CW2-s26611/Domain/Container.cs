namespace APBD_Z_CW2_s26611.Domain;
using APBD_Z_CW2_s26611.ENUMS;

public abstract class Container(double height, double weight, double depth, string name, double maxLoadWeights)
{
    public double Height { get; set; } = height;
    public double Weight { get; set; } = weight;
    public double Depth { get; set; } = depth;
    public string Name { get; set; } = name;
    public double MaxLoadWeights { get; set; } = maxLoadWeights;
    public double ContainerCargoWeight { get; set; } = 0;

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
        return $"Wysokosc: {Height}, Waga: {Weight}, Glebokosc: {Depth}, Nazwa: {Name}";
    }
}