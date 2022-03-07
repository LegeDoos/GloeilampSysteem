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
        bool isOn;
        List<Lamp> lamps = new List<Lamp> ();

        public LightSwitch(int id, string name)
        {
            this.id = id;
            this.name = name;
            isOn = false;
        }

        public void ConnectLamp(Lamp theLamp)
        {
            lamps.Add(theLamp);
            theLamp.ConntectLightSwitch(this);
        }

        public void Toggle()
        {
            // zet de lampen aan
            foreach (var lamp in lamps)
            {
                lamp.Aanzetten();
            }
        }
    }
}
