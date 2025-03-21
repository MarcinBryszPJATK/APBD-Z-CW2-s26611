using APBD_Z_CW2_s26611.Exceptions;

namespace APBD_Z_CW2_s26611.Domain;

public class ContainerShip(double maxSpeed, double maxContainerNumber, double maxContainerWeights)
{
    List<Container> Containers = new List<Container>();

    double MaxSpeed {get; set; } = maxSpeed;
    double MaxContainerNumber {get; set; } = maxContainerNumber;
    double MaxContainerWeights {get; set; } = maxContainerWeights;

    public void AddContainer(Container container)
    {
        if (Containers.Count > MaxContainerNumber)
            throw new OverfillException($"Kontenerowiec jest juz przepelniony, posiada maksymalna liczbe kontenerow wynoszaca: {MaxContainerNumber}");
        
        if(GetAllContainersWeights(container) > MaxContainerWeights)
            throw new OverfillException($"Kontenerowiec jest juz przepelniony, posiada maksymalna wage: {MaxContainerWeights}");
        
        Containers.Add(container);
        
    }
    
    public void addContainers(List<Container> ContainersList)
    {
        if (Containers.Count + ContainersList.Count  > MaxContainerNumber)
            throw new OverfillException($"Kontenerowiec jest juz przepelniony, posiada maksymalna liczbe kontenerow wynoszaca: {MaxContainerNumber}");
        
        if(GetAllContainersWeights(ContainersList) > MaxContainerWeights)
            throw new OverfillException($"Kontenerowiec jest juz przepelniony, posiada maksymalna wage: {MaxContainerWeights}");
        
        Containers.AddRange(ContainersList);
        
    }

    private double GetAllContainersWeights(Container incomingContainer)
    {
        double result = incomingContainer.Weight;

        foreach (var Contaiener in Containers)
        {
            result += Contaiener.Weight;
        }

        return result;
    }
    
    private double GetAllContainersWeights(List<Container> ContainersList)
    {
        double result = 0;
        ContainersList.AddRange(Containers);
        
        foreach (var Contaiener in ContainersList)
        {
            result += Contaiener.Weight;
        }

        return result;
    }

    public void SwitchContainer(Container Container)
    {
        int index = Containers.FindIndex(c => c.Name == Container.Name);

        if (index != -1)
        {
            Containers[index] = Container;
        }
        else
        {
            Console.WriteLine("Kontener o nazwie 'X' nie został znaleziony.");
        }

    }

    public override string ToString()
    {
        return $"(Predkosc: {MaxSpeed}, Maksymalna liczba kontenerow: {MaxContainerNumber}, Maksymalna waga przewozonych kontenerow: {MaxContainerWeights})";
    }

}