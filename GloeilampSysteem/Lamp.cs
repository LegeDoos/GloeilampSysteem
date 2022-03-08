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

        public string Name { get; set; }

        public bool IsOn { get; private set; }

        string state;
        public string State { get => state; }

        LightSwitch lightSwitch;

        public Lamp(int id, string _name)
        {
            this.Id = id;
            this.Name = _name;
            this.IsOn = false;
            state = "Leeg";
        }

        public virtual void Aanzetten()
        {
            IsOn = true;
            state = "Aan";
            Console.WriteLine($"Lamp {this.Name} staat {this.state}!");
        }

        public virtual void Uitzetten()
        {
            IsOn = false;
            state = "Uit";
            Console.WriteLine($"Lamp {this.Name} staat {this.state}!");

        }
        public void ConntectLightSwitch(LightSwitch theSwitch)
        {
            this.lightSwitch = theSwitch;
        }
    }
}
