namespace APBD_Z_CW2_s26611.Domain;

public abstract class Container(double height, double weight, double depth, string name, double maxLoadWeights)
{
    public double cargoWeight { get; set; } = 0.0;

}