using APBD_Z_CW2_s26611.Exceptions;

namespace APBD_Z_CW2_s26611.Domain;
using APBD_Z_CW2_s26611.doubleerfaces;
using APBD_Z_CW2_s26611.ENUMS;
public class LiquidContainer(double height, double weight, double depth, double maxLoadWeights, CargoType cargoType) : Container(height, weight, depth, maxLoadWeights), IHazardNotifier
{
    public CargoType CargoType { get; private set; } = cargoType;
    protected override string ContainerExtension => "L";
    public void Notify(string message, string cargoName)
    {
        Console.WriteLine(message);
    }

    public void LoadCargo(double additionalWeight, CargoType cargoType)
    {
        string cargoDescription = CargoType == CargoType.DANGEROUS ? "niebezpieczny" : "normalny";
        
        if (CargoType != cargoType)
            throw new Exception($"Ten kontener sluzy do przewozenia ladunku typu: {cargoDescription} ");
        double newTotalWeight = ContainerCargoWeight + additionalWeight;
        double limitFactor = cargoType == CargoType.DANGEROUS ? 0.5 : 0.9;
        double allowedLimit = maxLoadWeights * limitFactor;

        if (newTotalWeight > allowedLimit)
        {
            Notify(
                $"Ładunek jest {cargoDescription}, więc masa nie może przekraczać {limitFactor * 100}% maksymalnego załadunku.",
                Name);

            throw new OverfillException($"Ładunek jest {cargoDescription}, więc masa nie może przekraczać {limitFactor * 100}% maksymalnego załadunku.");
        }
        else
        {
            base.LoadCargo(additionalWeight);
        }
        
        
    }
    
    public override string ToString()
    {
        string cargoDescription = CargoType == CargoType.DANGEROUS ? "niebezpieczny" : "normalny";
        
        return base.ToString() + $"Przewozony ladunek: {cargoDescription}";
    }
}