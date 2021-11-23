using System;
using System.Collections.Generic;
using System.Text;

namespace GloeilampSysteem
{
    /// <summary>
    /// Deze class definieerd het object lamp
    /// </summary>
    class Lamp
    {
        /// <summary>
        /// Geeft de status aan: true is aan, false is uit
        /// </summary>
        private bool Status
        {
            get
            {
                return LichtOpbrengstPercentage > 0;
            }
        }

        /// <summary>
        /// Geeft de lichtopbrengst in % van de lamp aan
        /// </summary>
        public int LichtOpbrengstPercentage { get; private set; }

        /// <summary>
        /// Zet de lamp aan of uit door spanning op de polen te veranderen
        /// </summary>
        /// <param name="_volt">Het voltage op de polen van de lamp</param>
        public void ZetSpanningOpPolen(int _volt)
        {
            if (_volt >= 0 && _volt <= 220)
            {
                LichtOpbrengstPercentage = 100 * _volt / 220;
            }
            else
            {
                LichtOpbrengstPercentage = 0;
            }           
        }

        /// <summary>
        /// Geef een string met de status van de lamp
        /// </summary>
        /// <returns></returns>
        public string ToonStatus()
        {
            if (this.Status)
            {
                return $"De lamp staat aan met lichtopbrenst {LichtOpbrengstPercentage} %";
            }
            else
            {
                return $"De lamp staat uit met lichtopbrengst {LichtOpbrengstPercentage} %";
            }
        }
    }
}
