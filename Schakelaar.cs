using System;
using System.Collections.Generic;
using System.Text;

namespace GloeilampSysteem
{
    class Schakelaar
    {
        //properties
        /// <summary>
        /// Is het circuit gesloten (true) of open (false)
        /// </summary>
        public Boolean Ingeschakeld { get; private set; }

        /// <summary>
        /// Wat is de uitgaande spanning van de schakelaar?
        /// </summary>
        protected int UitgaandeSpanning { get; set; }

        /// <summary>
        /// Welke lampen worden bediend
        /// </summary>
        protected List<Lamp> Lampen = new List<Lamp>();

        /// <summary>
        /// Constructor van de class: wordt gebruikt om het object wat wordt gemaakt te instantieren
        /// </summary>
        public Schakelaar()
        {
            this.Ingeschakeld = false;
            this.UitgaandeSpanning = 220;
        }

        /// <summary>
        /// Koppel een lamp aan de schakelaar
        /// </summary>
        /// <param name="_lamp">De lamp om te koppelen</param>
        public void VoegLampToe(Lamp _lamp)
        {
            Lampen.Add(_lamp);
        }

        /// <summary>
        /// Toggle de schakelaar en zet de lampen aan of uit
        /// </summary>
        public void Toggle()
        {
            if (this.Ingeschakeld) // de schakelaar staat aan
            {
                this.Ingeschakeld = false;
                foreach (var lamp in this.Lampen)
                {
                    lamp.ZetSpanningOpPolen(0);
                }
            }
            else // de schakelaar staat uit
            {
                this.Ingeschakeld = true;
                foreach (var lamp in this.Lampen)
                {
                    lamp.ZetSpanningOpPolen(this.UitgaandeSpanning);
                }
            }
        }


        /// <summary>
        /// Toon de status van de lampen in de console
        /// </summary>
        public void ToonStatus()
        {
            Console.WriteLine($"De schakelaar heeft status {(this.Ingeschakeld ? "aan" : "uit")} en heeft een spanning van {this.UitgaandeSpanning} Volt");
            foreach (var lamp in this.Lampen)
            {
                Console.WriteLine(lamp.ToonStatus());
            }
            Console.WriteLine();
        }
    }
}
