// See https://aka.ms/new-console-template for more information

using GloeilampSysteem.BusinessLayer;

Console.WriteLine("Lamp and Lightswitch example");


// Create lightswitch
LightSwitch lswitch = new LightSwitch(10, "Test A1D1");
lswitch.CreateInDb();

// Show data
foreach (var s in LightSwitch.GetLightSwitchesFromDb())
{
    Console.WriteLine("-----------");
    Console.WriteLine($"Switch {s.Name}");
    foreach (var lamp in s.Lamps)
    {
        Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
    }
}


// Update data
foreach (var s in LightSwitch.GetLightSwitchesFromDb())
{
    s.Toggle();
    s.Name = $"Nieuwe naam voor schakelaar {s.Id}";
    s.UpdateInDb();
}

// Show data
foreach (var s in LightSwitch.GetLightSwitchesFromDb())
{
    Console.WriteLine("-----------");
    Console.WriteLine($"Switch {s.Name}");
    foreach (var lamp in s.Lamps)
    {
        Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
    }
}






