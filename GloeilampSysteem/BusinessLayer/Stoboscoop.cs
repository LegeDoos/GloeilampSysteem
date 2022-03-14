using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloeilampSysteem.BusinessLayer
{
    internal class Stoboscoop : Lamp
    {
        int frequency;

        public Stoboscoop(int id, string name, int freq) : base(id, name)
        {
            frequency = freq;
        }

        public override void Aanzetten()
        {
            base.Aanzetten();
            int msPauze = 1000 / frequency;

            while (true)
            {
                Thread.Sleep(msPauze);
                if (IsOn)
                {
                    base.Uitzetten();
                }
                else
                {
                    base.Aanzetten();
                }
            }
           
            // eigen implementatie
          
        }

        public override void Uitzetten()
        {
            base.Uitzetten();
        }
    }
}
