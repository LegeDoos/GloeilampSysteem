// See https://aka.ms/new-console-template for more information

using GloeilampSysteem.BusinessLayer;

Console.WriteLine("Lamp and Lightswitch example");

//Create lightswitch
//LightSwitch lswitch = new LightSwitch(10, "Test A1D1 20220321");
//lswitch.ConnectLamp(new Lamp(1, "Lamp 1"));
//lswitch.ConnectLamp(new Lamp(2, "Lamp 2"));
//lswitch.CreateInDb();

// Create lightswitch (
LightSwitch lswitch = new LightSwitch(10, "Test A1D1");
lswitch.Delete();
lswitch.Create();

// Show data
foreach (var s in LightSwitch.Read())
{
    Console.WriteLine("-----------");
    Console.WriteLine($"Switch {s.Name} (id: {s.Id})");
    foreach (var lamp in s.Lamps)
    {
        Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
    }
}

// Delete lightswitch 
Console.WriteLine("Geef id voor de te verwijderen switch:");
var value = Int32.Parse(Console.ReadLine());
var lightSwitchToDelete = LightSwitch.Read(value);
lightSwitchToDelete.Delete();

// show data
Console.Clear();
foreach (var s in LightSwitch.Read())
{
    Console.WriteLine("-----------");
    Console.WriteLine($"Switch {s.Name} (id: {s.Id})");
    foreach (var lamp in s.Lamps)
    {
        Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
    }
}


/*

// Update data
var switches = LightSwitch.GetLightSwitchesFromDb();

foreach (var s in switches)
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

*/




