using System;
using System.Collections.Generic;
using System.Text;

namespace GloeilampSysteem
{
    class Dimschakelaar : Schakelaar
    {

        /// <summary>
        /// De stand waarin de schakelaar zich bevindt, 0..4
        /// </summary>
        private int Stand { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Dimschakelaar() : base() //let op: base constructor wordt ook uitgevoerd
        {
            this.Stand = 0;
            UitgaandeSpanning = this.Stand * 55;
        }
        

        /// <summary>
        /// Verlaag de dimmer met een stand
        /// </summary>
        public void Lager()
        {
            Stand = Stand > 0 ? Stand-1 : 0;
            UitgaandeSpanning = this.Stand * 55;
            UpdateSpanningOpLampen();
        }

        /// <summary>
        /// Verhoog de dimmer met een stand
        /// </summary>
        public void Hoger()
        {
            Stand = Stand < 4 ? Stand+1 : 4;
            UitgaandeSpanning = this.Stand * 55;
            UpdateSpanningOpLampen();
        }

        private void UpdateSpanningOpLampen()
        {
            foreach (var lamp in Lampen)
            {
                lamp.ZetSpanningOpPolen(UitgaandeSpanning);
            }
        }
    }
}
