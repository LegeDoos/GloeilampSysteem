// See https://aka.ms/new-console-template for more information
using Lightswitch;

Console.WriteLine("Lamp and Lightswitch example");

// Create data

List<LightSwitch> lightSwitches = new List<LightSwitch>();
LightSwitch theSwitch = new LightSwitch(1, "De schakelaar");
theSwitch.ConnectLamp(new Lamp(1, "Lamp 1"));
theSwitch.ConnectLamp(new Lamp(2, "Lamp 2"));
theSwitch.ConnectLamp(new Lamp(3, "Lamp 3"));
lightSwitches.Add(theSwitch);

// Show data

foreach (var s in lightSwitches)
{
    Console.WriteLine("-----------");
    Console.WriteLine($"Switch {s.Name}");
    foreach (var lamp in s.Lamps)
    {
        Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
    }
}


