using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightswitch
{
    internal class LightSwitch
    {
        int id;

        string name;
        public string Name { get => name; set => name = value; }

        bool isOn;
        public bool IsOn { get => isOn; set => isOn = value; }


        List<Lamp> lamps = new List<Lamp>();
        public List<Lamp> Lamps { get => lamps; set => lamps = value; }

        public LightSwitch(int id, string name)
        {
            this.id = id;
            this.Name = name;
            IsOn = false;
        }


        public void ConnectLamp(Lamp theLamp)
        {
            Lamps.Add(theLamp);
            theLamp.ConntectLightSwitch(this);
        }

        public void Toggle()
        {
            // zet de lampen aan
            foreach (var lamp in Lamps)
            {
                lamp.Aanzetten();
            }
        }
    }
}
