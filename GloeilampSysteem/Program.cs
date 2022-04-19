// See https://aka.ms/new-console-template for more information

using GloeilampSysteem.BusinessLayer;

string stamp = "202204131344";
DateTime dt = DateTime.ParseExact(stamp, "yyyyMMddHHmm", null);

Console.WriteLine("Lamp and Lightswitch example");

// Create lightswitch 
Console.WriteLine("Create");
Lightswitch lswitch = new Lightswitch($"Test lightswitch {DateTime.Now}");
lswitch.ConnectLamp(new Lamp("Lamp 1"));
lswitch.ConnectLamp(new Lamp("Lamp 2"));
lswitch.Create();

// Show data
foreach (var s in Lightswitch.Read())
{
    Console.WriteLine("-----------");
    Console.WriteLine($"Switch {s.Name} (id: {s.Id})");
    foreach (var lamp in s.Lamps)
    {
        Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
    }
}
Console.ReadLine();
Console.Clear();

// Update lightswitch
Console.WriteLine("Update (toggle)");
lswitch.Toggle();
lswitch.Update();

// Show data
foreach (var s in Lightswitch.Read())
{
    Console.WriteLine("-----------");
    Console.WriteLine($"Switch {s.Name} (id: {s.Id})");
    foreach (var lamp in s.Lamps)
    {
        Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
    }
}
Console.ReadLine();
Console.Clear();


// Delete lightswitch
Console.WriteLine("Delete");
lswitch.Delete();

// Show data
foreach (var s in Lightswitch.Read())
{
    Console.WriteLine("-----------");
    Console.WriteLine($"Switch {s.Name} (id: {s.Id})");
    foreach (var lamp in s.Lamps)
    {
        Console.WriteLine($"  Lamp {lamp.Name} is aan: {lamp.IsOn}");
    }
}



/*
// Delete lightswitch 
Console.WriteLine("Geef id voor de te verwijderen switch:");
var value = Int32.Parse(Console.ReadLine());
var lightSwitchToDelete = Lightswitch.Read(value);
lightSwitchToDelete.Delete();

// show data
Console.Clear();
foreach (var s in Lightswitch.Read())
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




