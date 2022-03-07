using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightswitch
{
    internal class Lamp
    {
        private int id;
        public int Id { get => id; private set => id = value; }
        public string name { get; set; }
        public bool isOn { get; private set; }
        string state;
        public string State { get => state; }

        LightSwitch lightSwitch;

        public Lamp(int id, string _name)
        {
            this.Id = id;
            this.name = _name;
            this.isOn = false;
            state = "Leeg";
        }

        public virtual void Aanzetten()
        {
            isOn = true;
            state = "Aan";
            Console.WriteLine($"Lamp {this.name} staat {this.state}!");
        }

        public virtual void Uitzetten()
        {
            isOn = false;
            state = "Uit";
            Console.WriteLine($"Lamp {this.name} staat {this.state}!");

        }
        public void ConntectLightSwitch(LightSwitch theSwitch)
        {
            this.lightSwitch = theSwitch;
        }
    }
}
