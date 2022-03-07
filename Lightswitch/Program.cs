// See https://aka.ms/new-console-template for more information
using Lightswitch;

Console.WriteLine("Lamp and Lightswitch example");

Lamp regularLamp = new Lamp(1, "Normale lamp");
Lamp regularLamp2 = new Lamp(2, "Normale lamp 2");

Lamp stroboscoop = new Stoboscoop(3, "Stroboscoop", 100);
LightSwitch theSwitch = new LightSwitch(1, "De schakelaar");
theSwitch.ConnectLamp(regularLamp);
theSwitch.ConnectLamp(regularLamp2);
theSwitch.ConnectLamp(stroboscoop);
theSwitch.Toggle();
