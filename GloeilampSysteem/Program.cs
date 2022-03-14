// See https://aka.ms/new-console-template for more information

using GloeilampSysteem.BusinessLayer;

Console.WriteLine("Lamp and Lightswitch example");

// Create data
List<LightSwitch> lightSwitches = LightSwitch.GetLightSwitchesFromDb();


    foreach (var s in lightSwitches)
    {
        Console.WriteLine("-----------");
        Console.WriteLine($"Switch {s.Name}");
        foreach (var lamp in s.Lamps)
        {
            Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
        }
    }





