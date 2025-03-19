namespace APBD_Z_CW2_s26611.Domain;
using APBD_Z_CW2_s26611.Interfaces;

public class LiquidContainer(double height, double weight, double depth, string name, double maxLoadWeights) : Container(height, weight, depth, name, maxLoadWeights), IHazardNotifier
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }
}