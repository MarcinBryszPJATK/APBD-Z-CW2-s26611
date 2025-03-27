using APBD_Z_CW2_s26611.doubleerfaces;

namespace APBD_Z_CW2_s26611.Domain;

public class GasContainer(double height, double weight, double depth, double maxLoadWeights, double preasure) : Container(height, weight, depth, maxLoadWeights), IHazardNotifier
{
    private double Preasure { get; set; } = preasure;
    protected override string ContainerExtension => "G";
    public void Notify(string message, string cargoName)
    {
        Console.WriteLine(message);
    }

    public void ClearCargo(double cargoWeight)
    {
        if (cargoWeight > ContainerCargoWeight)
        {
            Notify("Nie możesz usunąć więcej niż jest dostępne w kontenerze", Name);
        }else
        {
            base.ClearCargo(cargoWeight);
            
            ContainerCargoWeight += cargoWeight * 0.05;
        }
    }
}