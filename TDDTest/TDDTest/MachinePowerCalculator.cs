namespace TDDTest;

public class MachinePowerCalculator
{
    private Dictionary<string, double> powerConsumption = new Dictionary<string, double>()
    {
        {"MillingMachine", 5.0},
        {"Press", 7.2},
        {"Lathe", 3.5}
    };
    
    public double GetPowerConsumption(string machineType, int duration, bool isEnergySaving)
    {
        if (String.IsNullOrEmpty(machineType))
        {
            throw new ArgumentException("Machine type cannot be empty.");
        }
        
        if(duration <= 0)
        {
            throw new ArgumentException("Duration must be greater than zero.");
        }
        
        if (!powerConsumption.TryGetValue(machineType, out var basePowerConsumption))
        {
            throw new ArgumentException("Invalid machine type.");
        }
            
        var multiplier = isEnergySaving ? 0.8 : 1.0;
        
        return multiplier * basePowerConsumption * double.Log10(duration + 1);
    }
}