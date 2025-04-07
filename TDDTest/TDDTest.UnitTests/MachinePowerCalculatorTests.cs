using Xunit;
using ArgumentException = System.ArgumentException;

namespace TDDTest.UnitTests;

public class MachinePowerCalculatorTests
{
    MachinePowerCalculator sut;
    
    public MachinePowerCalculatorTests()
    {
        sut = new MachinePowerCalculator();
    }
    
    [Fact]
    public void GetPowerConsumption_TypeIsNull_ThrowsArgumentException()
    {
        // Arrange
        string machineType = null;
        int duration = 10;
        bool isEnergySaving = false;
        
        // Act
        Action act = () => sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Machine type cannot be empty.", exception.Message);
    }
    
    [Fact]
    public void GetPowerConsumption_TypeIsEmpty_ThrowsArgumentException()
    {
        // Arrange
        string machineType = "";
        int duration = 10;
        bool isEnergySaving = false;
        
        // Act
        Action act = () => sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Machine type cannot be empty.", exception.Message);
    }
    
    [Fact]
    public void GetPowerConsumption_DurationIsZero_ThrowsArgumentException()
    {
        // Arrange
        string machineType = "MillingMachine";
        int duration = 0;
        bool isEnergySaving = false;
        
        // Act
        Action act = () => sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Duration must be greater than zero.", exception.Message);
    }
    
    [Fact]
    public void GetPowerConsumption_DurationIsLessThanZero_ThrowsArgumentException()
    {
        // Arrange
        string machineType = "MillingMachine";
        int duration = -1;
        bool isEnergySaving = false;
        
        // Act
        Action act = () => sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Duration must be greater than zero.", exception.Message);
    }
    
    [Fact]
    public void GetPowerConsumption_TypeIsMillingMachine_ReturnsAppropriatePowerConsumption()
    {
        // Arrange
        string machineType = "MillingMachine";
        int duration = 10;
        bool isEnergySaving = false;
        double expected = 5.0 * double.Log(duration + 1);
        
        // Act
        var res = sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        Assert.Equal(expected, res);
    }
    
    [Fact]
    public void GetPowerConsumption_TypeIsPress_ReturnsAppropriatePowerConsumption()
    {
        // Arrange
        string machineType = "Press";
        int duration = 10;
        bool isEnergySaving = false;
        double expected = 7.2 * double.Log(duration + 1);
        
        // Act
        var res = sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        Assert.Equal(expected, res);
    }
    
    [Fact]
    public void GetPowerConsumption_TypeIsLathe_ReturnsAppropriatePowerConsumption()
    {
        // Arrange
        string machineType = "Lathe";
        int duration = 10;
        bool isEnergySaving = false;
        double expected = 3.5 * double.Log(duration + 1);
        
        // Act
        var res = sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        Assert.Equal(expected, res);
    }
    
    [Fact]
    public void GetPowerConsumption_TypeIsUnknown_ThrowsArgumentException()
    {
        // Arrange
        string machineType = "Ivalid";
        int duration = 10;
        bool isEnergySaving = false;
        double expected = 7.2 * double.Log(duration + 1);
        
        // Act
        Action act = () => sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Invalid machine type.", exception.Message);
    }
    
    [Fact]
    public void GetPowerConsumption_IsEnergySaving_PowerConsumptionIsReduced()
    {
        // Arrange
        string machineType = "MillingMachine";
        int duration = 10;
        bool isEnergySaving = false;
        double expected = 5.0 * 0.8 * double.Log(duration + 1);
        
        // Act
        var res = sut.GetPowerConsumption(machineType, duration, isEnergySaving);

        // Assert
        Assert.Equal(expected, res);
    }
}