using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.BusinessLayer
{
    internal class Stroboscoop : Lamp
    {
        int frequency;

        public Stroboscoop(int id, string name, int freq) : base(id, name)
        {
            frequency = freq;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            int msPauze = 1000 / frequency;

            while (true)
            {
                Thread.Sleep(msPauze);
                if (IsOn)
                {
                    base.TurnOff();
                }
                else
                {
                    base.TurnOn();
                }
            }
           
            // eigen implementatie
          
        }

        public override void TurnOff()
        {
            base.TurnOff();
        }
    }
}
