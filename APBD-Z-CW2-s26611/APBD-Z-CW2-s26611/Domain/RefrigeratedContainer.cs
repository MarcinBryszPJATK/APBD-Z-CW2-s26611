using APBD_Z_CW2_s26611.ENUMS;
using APBD_Z_CW2_s26611.Exceptions;

namespace APBD_Z_CW2_s26611.Domain;

public class RefrigeratedContainer(double height, double weight, double depth, string name, double maxLoadWeights, ProductType productType, double temperature) : Container(height, weight, depth, name, maxLoadWeights)
{
    public ProductType ProductType { get; protected set; } = productType;

    private double _temperature = temperature;
    public double Temperature
    {
        get => _temperature;
        set
        {
            double defaultTemperature = TemperatureDict[ProductType];
            if (value < defaultTemperature)
            {
                throw new Exception(
                    $"Temperatura nie może być niższa niż {defaultTemperature}°C dla produktu {ProductType}.");
            }

            _temperature = value;
        }
    }
    
    private static readonly Dictionary<ProductType, double> TemperatureDict = new Dictionary<ProductType, double>()
    {
        { ProductType.EGGS, 19.0},
        { ProductType.FISH, 2.0},
        { ProductType.CHOCOLATE, 18.0},
        { ProductType.MILK, 19.0},
        { ProductType.BUTTER, 20.5},
        { ProductType.ICE_CREAM, -18.0},
    };
    
    private static readonly Dictionary<ProductType, double> PotentialWeightDict = new Dictionary<ProductType, double>()
    {
        { ProductType.EGGS, 1000.0 },
        { ProductType.FISH, 800.0 },
        { ProductType.CHOCOLATE, 1200.0 },
        { ProductType.MILK, 1500.0 },
        { ProductType.BUTTER, 700.0 },
        { ProductType.ICE_CREAM, 900.0 }
    };


    public void LoadCargo(ProductType product)
    {
        if (product != ProductType)
            throw new Exception($"Ten kontener przyjmuje tylko produkty typu {ProductType}");
        
        double cargoWeight = PotentialWeightDict[product];
        
        base.LoadCargo(cargoWeight);
    }
}